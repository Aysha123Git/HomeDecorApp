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
    public partial class AddProduct : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sel = "select CatId, CatName from CategoryRegister";
                DataSet ds = obj.Fn_exeadapter(sel);
                DropDownList1.DataSource = ds;
                DropDownList1.DataTextField = "CatName";
                DropDownList1.DataValueField = "CatId";
                DropDownList1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string picPath = "~/Pics/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(picPath));
            string ins = "insert into ProductRegister values(" + DropDownList1.SelectedItem.Value + ",'" + TextBox1.Text + "','" + picPath + "','" + TextBox2.Text + "','"+TextBox3.Text+"','available',"+TextBox4.Text+")     ";
            int j = obj.Fn_exenonquery(ins);
            if (j == 1)
            {
                Label6.Text = "Product added successfully";
                
            }
            else
            {
                Label6.Text = "Could not add the product";
            }
        }
    }
}