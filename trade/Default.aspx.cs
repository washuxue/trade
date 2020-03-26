using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using trade.function;

namespace trade
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                DB db = new DB();
                DataSet ds1 = db.reds("select top 8 * from GoodInfo where Recommend='true' order by LoadTime desc");
                DataList1.DataSource = ds1;
                DataList1.DataBind();
                DataSet ds2 = db.reds("select top 8 * from GoodInfo where New='true' order by LoadTime desc");
                DataList2.DataSource = ds2;
                DataList2.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = TextBox4.Text;
            if (Select1.Value == "商品名称")
            {
                Response.Write("<script>window.open('List.aspx?point=seekname&&var=" + str + "')</script>");
            }
            else if (Select1.Value == "商品条码")
            {
                Response.Write("<script>window.open('List.aspx?point=seekid&&var=" + str + "')</script>");
            }
            else if (Select1.Value == "商品价格")
            {
                Response.Write("<script>window.open('List.aspx?point=seekprice&&var=" + str + "')</script>");
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "DetailSee")
            {
                CheckGoodDetail(e);
            }
            else if (e.CommandName == "buy")
            {
                AddShoppingCart(e);
            }
        }

        protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "DetailSee")
            {
                CheckGoodDetail(e);
            }
            else if (e.CommandName == "buy")
            {
                AddShoppingCart(e);
            }
        }

        public void CheckGoodDetail(DataListCommandEventArgs e)
        {
            string goodid = e.CommandArgument.ToString();

            Response.Write("<script>window.open('ShowInfo.aspx?GoodID=" + goodid + "')</script>");
        }


        public void AddShoppingCart(DataListCommandEventArgs e)
        {
            Hashtable hashcar;
            if (Session["ShoppingCart"] == null)
            {
                hashcar = new Hashtable();
                hashcar.Add(e.CommandArgument, 1);
                Session["ShoppingCart"] = hashcar;

            }
            else
            {
                hashcar = (Hashtable)Session["ShoppingCart"];
                if (hashcar.Contains(e.CommandArgument))
                {
                    int count =Convert.ToInt32(hashcar[e.CommandArgument].ToString());
                    hashcar[e.CommandArgument] = count + 1;

                }
                else
                {
                    hashcar.Add(e.CommandArgument, 1);
                }
            }

            Response.Write("<script>alert('添加购物车成功')</script>");

        }
    }
}