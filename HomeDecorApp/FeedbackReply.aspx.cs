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
    public partial class FeedbackReply : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            string selAdminEmail = "select * from AdminRegister where AdminId=" + Session["loginId"] + "   ";
            SqlDataReader dr = obj.Fn_exereader(selAdminEmail);
            while(dr.Read())
            {
                TextBox1.Text = dr["AdminEmail"].ToString();
            }

            string selCustEmail = "select CustMail from CustomerRegister where CustId=" + Session["FeedbackCustomerId"] + "   ";
            SqlDataReader dr1 = obj.Fn_exereader(selCustEmail);
            while (dr1.Read())
            {
                TextBox2.Text = dr1["CustMail"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string arg1="", arg2, arg3, arg4="", arg5, arg6, arg7;
            string selAdminName = "select * from AdminRegister where AdminId=" + Session["loginId"] + "   ";
            SqlDataReader dr = obj.Fn_exereader(selAdminName);
            while (dr.Read())
            {
                arg1 = dr["AdminName"].ToString();
            }
            arg2 = TextBox1.Text;
            arg3 = "mius ivva pdcl goci";
            string selCustName = "select * from CustomerRegister where CustId=" + Session["FeedbackCustomerId"] + "   ";
            SqlDataReader dr1 = obj.Fn_exereader(selCustName);
            while (dr1.Read())
            {
                arg4 = dr1["CustName"].ToString();
            }

            arg5 = TextBox2.Text;
            arg6 = TextBox5.Text;
            arg7 = TextBox4.Text;

            SendEmail(arg1, arg2, arg3, arg4, arg5, arg6, arg7);
            Label3.Text = "Reply sent successfully";
            string updFbStatus = "update FeedbackRegister set FbStatus='inactive',FbReply='" + TextBox4.Text + "'    ";
            obj.Fn_exenonquery(updFbStatus);
        }

        public static void SendEmail(string yourName, string yourGmailUserName, string yourGmailPassword, string toName, string toEmail, string subject, string body)

        {
            string to = toEmail; //To address    
            string from = yourGmailUserName; //From address    
            MailMessage message = new MailMessage(from, to);

            string mailbody = body;
            message.Subject = subject;
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp    
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential(yourGmailUserName, yourGmailPassword);
            client.EnableSsl = true;
            client.UseDefaultCredentials = true;
            client.Credentials = basicCredential1;
            try
            {
                client.Send(message);
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}