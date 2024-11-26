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
    public partial class ViewSelectedProduct : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                
                string sel = "select prodName, prodImage, prodDesc, prodPrice from productregister where prodId=" + Session["selectedProductId"] + "     ";
                SqlDataReader dr = obj.Fn_exereader(sel);                
                while (dr.Read())
                {
                    Image1.ImageUrl = dr["prodImage"].ToString();
                    Label1.Text = dr["prodName"].ToString();
                    Label3.Text = dr["prodDesc"].ToString();
                    TextBox2.Text= dr["prodPrice"].ToString();
                    //singlePrice = Convert.ToInt32(dr["prodPrice"].ToString());                    
                }
                //qty = Convert.ToInt32(TextBox1.Text.ToString() );
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("CustomerHome.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string sel = "select max(cartId) from cartregister";
            string maxCartId = obj.Fn_exescalar(sel);
            int intCartId;
            if(maxCartId=="")
            {
                intCartId = 1;
            }
            else
            {
                intCartId = Convert.ToInt32(maxCartId);
                intCartId = intCartId + 1;
            }            
            string ins = "insert into cartRegister values("+intCartId+","+ Session["loginId"] + ","+ Session["selectedProductId"] + ","+TextBox1.Text+","+TextBox2.Text+"   )      ";
            int i=obj.Fn_exenonquery(ins);
            if(i!=0)
            {
                Label8.Text = "Item added to cart";
            }
            
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

            //int totalPrice = 0;
            string StrQty = TextBox1.Text;
            String StrPrice = TextBox2.Text.ToString();
            int qty = Convert.ToInt32(TextBox1.Text.ToString());
            int price = Convert.ToInt32(TextBox2.Text.ToString());
            if (qty >= 0)
            {
                price = qty * price;
                TextBox2.Text = price.ToString();
            }

        }
    }
}