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
    public partial class AddCategory : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string picPath = "~/Pics/"+FileUpload1.FileName ;
            FileUpload1.SaveAs(MapPath(picPath));
            string ins = "insert into CategoryRegister values('" + TextBox1.Text + "','"+picPath+"','" + TextBox2.Text + "','available')     ";
            int j = obj.Fn_exenonquery(ins);
            if (j == 1)
            {
                Label4.Text = "Category added successfully";               
            }
            else
            {
                Label4.Text = "Could not add category";
            }
        }
    }
}