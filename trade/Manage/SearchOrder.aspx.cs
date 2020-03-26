using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using trade.function;

namespace trade.Manage
{
    public partial class SearchOrder : System.Web.UI.Page
    {
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
   
        }
        public void Bind(string s)
        {
            

            DataSet ds = db.reds(s);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "manage")
            {
                int orderid = int.Parse(e.CommandArgument.ToString());
                Response.Write("<script>window.open('ManageOrderDetail.aspx?OrderID=" + orderid + "')</script>");
            }
            else if (e.CommandName == "del")
            {
                int orderid = int.Parse(e.CommandArgument.ToString());
                string ordersql = "delete from [Order] where OrderID=" + orderid;
                string goodsql = "delete from OrderDetail where OrderID=" + orderid;

                if (db.exsql(ordersql) && db.exsql(goodsql))
                {
                    Response.Redirect("~/Manage/SearchOrder.aspx");

                }
                else
                {
                    Response.Write("<script>alert('删除失败')</script>");

                }
            }
        }
    

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            if (DropDownList1.SelectedValue == "订单编号")
            {
                int point = int.Parse(searchinput.Text.Trim());
                string str = "select * from [Order] where OrderID="+point;
                Bind(str);
            }
            else if(DropDownList1.SelectedValue == "收货人姓名")
            {
                string point = searchinput.Text.Trim();
                string str = "select * from [Order] where ReceiverName='" + point + "'";
                Bind(str);
            }
            
            
        }
    }
}