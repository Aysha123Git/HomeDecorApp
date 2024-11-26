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
    public partial class EditProduct : System.Web.UI.Page
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
            string sel = "select categoryRegister.catName, productRegister.prodId,productRegister.prodName, productRegister.prodDesc ,productRegister.prodPrice ,productRegister.prodStock,productRegister.prodImage from categoryRegister inner join productRegister on categoryRegister.catId= productRegister.catId    ";
            DataSet ds = obj.Fn_exeadapter(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string upd = "update productregister set catId="+DropDownList1.SelectedItem.Value+", prodName='"+TextBox1.Text+"', prodDesc='"+TextBox2.Text+"',prodPrice="+TextBox3.Text+", prodStock="+TextBox4.Text+" where prodId="+ Session["sessProdId"] + "      ";
            obj.Fn_exenonquery(upd);
            BindTheGrid();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
            BindTheGrid();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Panel2.Visible = true;

            string selDdl = "select * from categoryregister";
            DataSet ds = obj.Fn_exeadapter(selDdl);
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "catName";
            DropDownList1.DataValueField = "catId";
            DropDownList1.DataBind();  

            int i = e.NewSelectedIndex;
            int getProductId = Convert.ToInt32(GridView1.DataKeys[i].Value);            
            Session["sessProdId"] = getProductId;
            string sel = "select categoryRegister.catName,categoryRegister.catId, productRegister.prodName, productRegister.prodDesc ,productRegister.prodPrice ,productRegister.prodStock,productRegister.prodImage from categoryRegister inner join productRegister on categoryRegister.catId= productRegister.catId and productRegister.prodId=" + Session["sessProdId"] + "    ";
            SqlDataReader dr = obj.Fn_exereader(sel);
            while(dr.Read())
            {
                TextBox1.Text = dr["prodName"].ToString();
                TextBox2.Text = dr["prodDesc"].ToString();
                TextBox3.Text = dr["prodPrice"].ToString();
                TextBox4.Text = dr["prodStock"].ToString();                
            }

           
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int i = e.RowIndex;
            int prodId = Convert.ToInt32(GridView1.DataKeys[i].Value);
            string del = "delete from productregister where prodid=" + prodId + "   ";
            obj.Fn_exenonquery(del);
            BindTheGrid();
        }
    }
}