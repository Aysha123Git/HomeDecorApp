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
    public partial class EditCategory : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindTheGrid();
            }
        }

        public void BindTheGrid()
        {
            string sel = "select * from CategoryRegister  ";
            DataSet ds = obj.Fn_exeadapter(sel);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            //string picPath = "~/Pics/" + FileUpload1.FileName;
            //FileUpload1.SaveAs(MapPath(picPath));
            //string upd="update categoryRegister set CatName='"+TextBox1.Text+"',CatDesc='"+TextBox2.Text+"',catImage='"+picPath+"' where catId="+Session["sessCatId"] +"    ";
            string upd = "update categoryRegister set CatName='" + TextBox1.Text + "',CatDesc='" + TextBox2.Text + "'  where catId=" + Session["sessCatId"] + "    ";
            obj.Fn_exenonquery(upd);
            BindTheGrid();

        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Panel1.Visible = true;
            int i = e.NewSelectedIndex;
            int getId = Convert.ToInt32(GridView1.DataKeys[i].Value);

            //session id used for update query in button click method
            Session["sessCatId"] = getId;
            //Label5.Text = getId.ToString();
            GridViewRow selectedRow = GridView1.Rows[i];
            TextBox1.Text = selectedRow.Cells[0].Text;
            TextBox2.Text = selectedRow.Cells[1].Text;
            //Image image = (Image)selectedRow.FindControl("Image1");
            //string imageUrl = image.ImageUrl;
            //Label5.Text = imageUrl;
            
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int r = e.RowIndex;
            int getId = Convert.ToInt32(GridView1.DataKeys[r].Value);
            string del = "delete from categoryRegister where catId=" + getId + "     ";
            obj.Fn_exenonquery(del);
            BindTheGrid();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
            BindTheGrid();
        }
    }
}