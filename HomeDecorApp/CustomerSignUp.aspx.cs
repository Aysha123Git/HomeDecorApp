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
    public partial class CustomerSignUp : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string sel = "select max(RegId) from LoginRegister";
            string maxregid = obj.Fn_exescalar(sel);
            int reg_id = 0;
            if (maxregid == "")
            {
                reg_id = 1;
            }
            else
            {
                int newregid = Convert.ToInt32(maxregid);
                reg_id = newregid + 1;
            }
            string ins = "insert into customerRegister values(" + reg_id + ",'" + TextBox1.Text + "','" + TextBox2.Text + "',"+TextBox3.Text+",'active','"+TextBox7.Text+"')      ";
            int i = obj.Fn_exenonquery(ins);
            //int j=0;
            if (i == 1)
            {                
                string inslog = "insert into LoginRegister values(" + reg_id + ",'" + TextBox4.Text + "','" + TextBox5.Text + "','customer')     ";
                int j = obj.Fn_exenonquery(inslog);
                if (j == 1)
                {
                    //Label7.Text = "success";
                    Response.Redirect("LoginPage.aspx");
                }
                else
                {
                    Label7.Text = "Insertion failed";
                }
            }
        }
    }
}