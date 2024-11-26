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
    public partial class ViewBill : System.Web.UI.Page
    {
        ConnectionClass obj = new ConnectionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            string selCust = "select * from customerregister where custId=" + Session["loginId"] + "   ";
            DataSet ds1 = obj.Fn_exeadapter(selCust);
            DataList1.DataSource = ds1;
            DataList1.DataBind();

            string selBill = "select * from billregister where custId=" + Session["loginId"] + "   ";
            DataSet ds2 = obj.Fn_exeadapter(selBill);
            DataList2.DataSource = ds2;
            DataList2.DataBind();

            string selProdId = "select prodId from orderRegister where custId=" + Session["loginId"] + " and orderStatus='ordered' ";
            SqlDataReader dr = obj.Fn_exereader(selProdId);
            List<int> prodIdList = new List<int>();
            while (dr.Read())
            {
                int getProdId =Convert.ToInt32( dr["prodId"].ToString()  );
                prodIdList.Add(getProdId);
            }
            
            foreach (int item in prodIdList)
            {
                //string selProd = "select * from productregister where prodId=" + item + "     ";
                string selProd = "SELECT ProductRegister.prodName, ProductRegister.prodPrice, OrderRegister.ProdQty, orderRegister.orderPrice FROM ProductRegister JOIN OrderRegister ON productRegister.prodId = orderRegister.prodId ";
                DataSet ds3 = obj.Fn_exeadapter(selProd);
                GridView1.DataSource = ds3;
                GridView1.DataBind();
            }

            string selGrandTotal = "select sum(orderPrice) from orderRegister where custId=" + Session["loginId"] + " and orderStatus='ordered' ";
            String grandTotalStr = obj.Fn_exescalar(selGrandTotal);
            int grantTot = Convert.ToInt32(grandTotalStr);
            Session["grandTotalint"] = grantTot;
            Label13.Text = "Grand Total: "+grandTotalStr;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string accNumStr = TextBox1.Text;
            string pinStr = TextBox2.Text;            
            AccService.ServiceClient serviceObj = new AccService.ServiceClient();
            string accountBalanceStr = serviceObj.getBalance(accNumStr, pinStr);
            if (accountBalanceStr == "")
            {
                Label15.Text = "Incorrect account details";
            }
            else
            {
                int accountBalance = Convert.ToInt32(accountBalanceStr);
                int grandTotal = Convert.ToInt32(Session["grandTotalint"]);
                if (grandTotal > accountBalance)
                {
                    Label15.Text = "Insufficient balance ";
                }
                else if (grandTotal <= accountBalance)
                {
                    int newBalance = accountBalance - grandTotal;
                    string newBalanceStr = newBalance.ToString();
                    serviceObj.updateBalance(accNumStr, newBalanceStr);
                    Label15.Text = newBalanceStr;

                    string selProdId = "select prodId from orderRegister where custId=" + Session["loginId"] + " and orderStatus='ordered' ";
                    SqlDataReader dr = obj.Fn_exereader(selProdId);
                    List<int> prodIdList = new List<int>();
                    Console.Write(prodIdList);
                    while (dr.Read())
                    {
                        int getProdId = Convert.ToInt32(dr["prodId"].ToString());
                        prodIdList.Add(getProdId);
                    }
                    foreach (int item in prodIdList)
                    {                        
                        string updOrder = "update orderRegister set orderStatus='Paid' where ProdId=" + item + " and custId=" + Session["loginId"]+"  ";
                        obj.Fn_exenonquery(updOrder);
                        string selQty = "select prodQty from orderregister where orderStatus='Paid' and  ProdId=" + item + " and custId=" + Session["loginId"] + "    ";
                        String getProdQtyStr = obj.Fn_exescalar(selQty);
                        int getProdQty = Convert.ToInt32(getProdQtyStr);
                        string updStock = "update productregister set prodStock=prodStock-" + getProdQty + " where ProdId=" + item + "  ";
                        obj.Fn_exenonquery(updStock);
                    }
                    Response.Redirect("PaymentSuccess.aspx");
                }
            }
        }
    }
}