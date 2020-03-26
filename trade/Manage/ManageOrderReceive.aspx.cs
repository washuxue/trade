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
    public partial class ManageOrderReceive : System.Web.UI.Page
    {
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();

            }
        }
        public void Bind()
        {
            string str = "select * from [Order] where State='待收货'";

            DataSet ds = db.reds(str);
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
                    Bind();

                }
                else
                {
                    Response.Write("<script>alert('删除失败')</script>");

                }
            }
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Bind();
        }
    }
}