using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text;

namespace HomeDecorApp
{
    public partial class FeedbackForm : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string insFb = "insert into feedbackregister values(" + Session["loginId"] + ",'" + TextBox2.Text + "','No reply','active'     }";
            int status = obj.Fn_exenonquery(insFb);
            string selFromName = "select custName from customerRegister where custId=" + Session["loginId"] + "   ";
            SqlDataReader dr = obj.Fn_exereader(selFromName);
            string fromName="";
            while(dr.Read())
            {
                fromName = dr["custName"].ToString();
            }
            //string fromGmail = TextBox1.Text;
            string fromPwd = "";
            //sendEmail();
            if (status !=0)
            {
                Label3.Text = "Feedback sent successfully";
            }            
        }
        

    }
}