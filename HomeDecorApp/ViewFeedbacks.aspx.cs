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
    public partial class ViewFeedbacks : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            string selCustFb = "select CustomerRegister.CustName, CustomerRegister.CustId, FeedbackRegister.FBMsg from CustomerRegister join FeedbackRegister on CustomerRegister.CustId= FeedbackRegister.CustId ";
            DataSet ds = obj.Fn_exeadapter(selCustFb);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            int i = e.NewSelectedIndex;
            int getCustId = Convert.ToInt32(GridView1.DataKeys[i].Value);
            Session["FeedbackCustomerId"] = getCustId;
            Response.Redirect("FeedbackReply.aspx");
        }
    }
}