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
    public partial class CustomerHome : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string delOrder = "delete from orderregister where custId=" + Session["loginId"] + "   ";
                obj.Fn_exenonquery(delOrder);
                string delBill = "delete from billregister where custId=" + Session["loginId"] + "   ";
                obj.Fn_exenonquery(delBill);
                Label3.Text = Session["loginId"].ToString();
                string sel = "select * from CategoryRegister";
                DataSet ds = obj.Fn_exeadapter(sel);
                DataList1.DataSource = ds;
                DataList1.DataBind();
            }
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            int categoryId = Convert.ToInt32(e.CommandArgument);
            Session["selectedCategoryId"] = categoryId;
            Label3.Text = Session["selectedCategoryId"].ToString();
            Response.Redirect("ViewProducts.aspx");
        }

    }
}