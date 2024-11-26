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
    public partial class LoginPage : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string selCount = "select count(*) from LoginRegister where Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'    ";
            string i = obj.Fn_exescalar(selCount);
            if (i == "1")
            {
                string selid = "select regId from LoginRegister where  Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'     ";
                string reg_Id = obj.Fn_exescalar(selid);
                Session["loginId"] = reg_Id;
                string selLogtype = "select logtype from LoginRegister where  Username='" + TextBox1.Text + "' and Password='" + TextBox2.Text + "'     ";
                string log_Type = obj.Fn_exescalar(selLogtype);
                if (log_Type == "admin")
                {
                    Response.Redirect("AdminHome.aspx");                    
                }
                else if (log_Type == "customer")
                {
                    Response.Redirect("CustomerHome.aspx");
                }
            }
            else
            {
                Label3.Text = "Incorrect login credentials";
            }
        }
    }
}