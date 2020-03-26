using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using trade.function;

namespace trade
{
    public partial class MyOrder : System.Web.UI.Page
    {
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Write("<script>alert('请先登录');location.href='Default.aspx';</script>");
            }

            if (!IsPostBack)
            {
                if (Session["UserID"] != null)
                {
                    Bind();

 

                }
            }
        }

        protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
        {       
            DataList dataList =(DataList)e.Item.FindControl("Datalist3");
            DataRowView dataRow =(DataRowView)e.Item.DataItem;
            Button button1 = (Button)e.Item.FindControl("Button1");
            Button button2 = (Button)e.Item.FindControl("Button2");
            if (dataRow["State"].ToString()=="待发货"|| dataRow["State"].ToString() == "待收货")
            {
                button1.Visible = true;
            }
            if (dataRow["State"].ToString() == "待付款")
            {
                button2.Visible = true;
            }
            int orderid = int.Parse(dataRow["OrderID"].ToString());
            DataSet ds2 = db.reds("select OrderDetail.*,GoodInfo.* from OrderDetail,GoodInfo" +
                " where OrderID="+orderid+"and OrderDetail.GoodID=GoodInfo.GoodID");
            dataList.DataSource = ds2;
            dataList.DataBind();
        }

        protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "receive")
            {
                int orderid = int.Parse(e.CommandArgument.ToString());
                string sql = "update [Order] set [State]='已成交' where OrderID="+orderid;
                if (db.exsql(sql))
                {
                    Response.Write("<script>alert('收货成功')</script>");

                    Bind();
                 
                }
            }
            if (e.CommandName == "pay")
            {
                int orderid = int.Parse(e.CommandArgument.ToString());
                string totalprice = ((Label)e.Item.FindControl("totalprice")).Text ;

                DefaultAopClient client = new DefaultAopClient(config.gatewayUrl, config.app_id, config.private_key, "json", "1.0", config.sign_type, config.alipay_public_key, config.charset, false);

                // 外部订单号，商户网站订单系统中唯一的订单号
                string out_trade_no = orderid.ToString();

                // 订单名称
                string subject = "安徽大学校园物品交易系统结算中心";

                // 付款金额
                string total_amout = totalprice;

                // 商品描述
                string body = "test";

                // 组装业务参数model
                AlipayTradePagePayModel model = new AlipayTradePagePayModel();
                model.Body = body;
                model.Subject = subject;
                model.TotalAmount = total_amout;
                model.OutTradeNo = out_trade_no;
                model.ProductCode = "FAST_INSTANT_TRADE_PAY";

                AlipayTradePagePayRequest request = new AlipayTradePagePayRequest();
                // 设置同步回调地址
                request.SetReturnUrl(config.nataddress + "/Return_url.aspx");
                // 设置异步通知接收地址
                request.SetNotifyUrl(config.nataddress + "/Notify_url.aspx");
                // 将业务model载入到request
                request.SetBizModel(model);

                AlipayTradePagePayResponse response = null;
                try
                {
                    response = client.pageExecute(request, null, "post");
                    Response.Write(response.Body);
                }
                catch (Exception exp)
                {
                    throw exp;
                }
            }
        }

        public void Bind()
        {
            int userid = int.Parse(Session["UserID"].ToString());
          

          
            string str = "select * from [Order] where UserID=" + userid+" order by OrderID desc";


            SqlCommand sc = db.GetSqlCommand(str);
            DataTable dsTable = db.GetDataSet(sc, "Order");
            int curpage = Convert.ToInt32(this.labPage.Text);
            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = dsTable.DefaultView;
            ps.AllowPaging = true; //是否可以分页
            ps.PageSize = 3; //显示的数量
            ps.CurrentPageIndex = curpage - 1; //取得当前页的页码
            this.lnkbtnUp.Enabled = true;
            this.lnkbtnNext.Enabled = true;
            this.lnkbtnBack.Enabled = true;
            this.lnkbtnOne.Enabled = true;
            if (curpage == 1)
            {
                this.lnkbtnOne.Enabled = false;//不显示第一页按钮
                this.lnkbtnUp.Enabled = false;//不显示上一页按钮
            }
            if (curpage == ps.PageCount)
            {
                this.lnkbtnNext.Enabled = false;//不显示下一页
                this.lnkbtnBack.Enabled = false;//不显示最后一页
            }
            this.labBackPage.Text = Convert.ToString(ps.PageCount);
            this.DataList2.DataSource = ps;
            this.DataList2.DataKeyField = "OrderID";
            this.DataList2.DataBind();


        }
        protected void lnkbtnOne_Click(object sender, EventArgs e)
        {
            this.labPage.Text = "1";
            Bind();

        }
        protected void lnkbtnUp_Click(object sender, EventArgs e)
        {
            this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) - 1);
            Bind();
        }
        protected void lnkbtnNext_Click(object sender, EventArgs e)
        {
            this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) + 1);
            Bind();
        }
        protected void lnkbtnBack_Click(object sender, EventArgs e)
        {
            this.labPage.Text = this.labBackPage.Text;
            Bind();
        }
    }
}