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
    public partial class ViewProducts : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Label3.Text = Session["loginId"].ToString();
                //Session["selectedCategoryId"] = 1003;
                string sel = "select * from productregister where catId=" + Session["selectedCategoryId"] + "    ";
                //Label3.Text = Session["selectedCategoryId"].ToString();
                //string sel = "select * from productregister ";
                DataSet ds = obj.Fn_exeadapter(sel);
                DataList1.DataSource = ds;
                DataList1.DataBind();
            }
        }

        protected void ImageButton1_Command(object sender, CommandEventArgs e)
        {
            Session["selectedProductId"] = Convert.ToInt32(e.CommandArgument);
            Response.Redirect("ViewSelectedProduct.aspx");
        }
    }
}