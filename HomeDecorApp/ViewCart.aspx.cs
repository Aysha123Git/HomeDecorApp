using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace HomeDecorApp
{
    public partial class ViewCart : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTheGrid();
            }
        }

        public void BindTheGrid()
        {
            string sel = "select * from productregister right join cartregister on productregister.prodId= cartregister.prodId  ";
            DataSet ds = obj.Fn_exeadapter(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            BindTheGrid();
        }

        protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int getCartId = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string del = "delete from cartregister where cartId=" + getCartId + "    ";
            obj.Fn_exenonquery(del);
            BindTheGrid();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {            
            string upd = "update cartregister set ProdQty=" + TextBox1.Text + ", CartPrice=" + TextBox2.Text + " where cartId=" + Session["selectedCartId"] + "    ";
            obj.Fn_exenonquery(upd);
            //GridView1.EditIndex = -1;

            BindTheGrid();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Panel1.Visible = true;
            int i = e.NewSelectedIndex;
            int selCartId = Convert.ToInt32(GridView1.DataKeys[i].Value);            
            Session["selectedCartId"] = selCartId;
        }     

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            string sel = "select * from cartregister where cartId= " + Session["selectedCartId"] + " and custId="+ Session["loginId"] + " ";
            SqlDataReader dr = obj.Fn_exereader(sel);            
            int singlePrice = 1, oldQty = 1, oldTotal = 1, newQty = 1, newTotal = 1;
            while (dr.Read())
            {
                oldQty = Convert.ToInt32(dr["prodQty"].ToString());
                oldTotal = Convert.ToInt32(dr["cartPrice"].ToString());
            }
            singlePrice = oldTotal / oldQty;
            newQty = int.Parse(TextBox1.Text);
            newTotal = newQty * singlePrice;
            TextBox2.Text = newTotal.ToString();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string selCartId = "select max(cartId) from cartregister";
            int maxCartId = Convert.ToInt32(obj.Fn_exescalar(selCartId));
            string sysDate = DateTime.Now.ToString("yyyy-MM-dd");
            for (int i=1; i<= maxCartId; i++)
            {
                string sel = "select * from cartregister where cartid=" + i + " and CustId= " + Session["loginId"] + "    ";
                SqlDataReader dr = obj.Fn_exereader(sel);
                int productId=0, productQty=0, orderPrice=0;
                
                while(dr.Read())
                {
                    productId = Convert.ToInt32(dr["prodId"].ToString());
                    productQty= Convert.ToInt32(dr["prodQty"].ToString());
                    orderPrice = Convert.ToInt32(dr["cartPrice"].ToString());                    
                }
                string ins = "insert into orderregister values("+ Session["loginId"] + ","+productId+","+productQty+","+orderPrice+",'"+ sysDate + "','ordered'  )    ";
                obj.Fn_exenonquery(ins);
                string delCart = "delete from CartRegister where cartid=" + i + " and CustId= " + Session["loginId"] + "  ";
                obj.Fn_exenonquery(delCart);
            }
            string selGrandTotal = "select sum(orderPrice) from orderregister where custId="+ Session["loginId"] + "   "   ;
            int grandTotal = Convert.ToInt32(obj.Fn_exescalar(selGrandTotal));
            string insBill = "insert into billRegister values("+ Session["loginId"] + ","+grandTotal+ ",'" + sysDate + "' )    ";
            obj.Fn_exenonquery(insBill);
            Response.Redirect("ViewBill.aspx");
        }
    }
}