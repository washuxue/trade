using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
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
    public partial class ManageOrderDetail : System.Web.UI.Page
    {
        DB db = new DB();
        int orderid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["OrderID"] != null)
            {
                orderid = int.Parse(Request["OrderID"]);
            }
            
            if (!IsPostBack)
            {
                Bind();

            }
        }
        public void Bind()
        {
            id.Text = orderid.ToString();
            string str1 = "select * from OrderDetail,GoodInfo,Class where OrderDetail.OrderID="+orderid+" and OrderDetail.GoodID=GoodInfo.GoodID and Class.ClassID=GoodInfo.ClassID";

            DataSet ds1 = db.reds(str1);
            GridView1.DataSource = ds1;
            GridView1.DataBind();
            string str2 = "select * from [Order] where OrderID="+orderid;
            DataSet ds2 = db.reds(str2);
            foreach(DataRow row in ds2.Tables[0].Rows)
            {
                generatetime.Text = ds2.Tables[0].Rows[0]["GenerateTime"].ToString();
                state.Text = ds2.Tables[0].Rows[0]["State"].ToString();
                goodprice.Text = ds2.Tables[0].Rows[0]["GoodPrice"].ToString();
                carriageprice.Text = ds2.Tables[0].Rows[0]["CarriagePrice"].ToString();
                totalprice.Text = ds2.Tables[0].Rows[0]["TotalPrice"].ToString();                
                receivername.Text = ds2.Tables[0].Rows[0]["ReceiverName"].ToString();
                receiverphone.Text = ds2.Tables[0].Rows[0]["ReceiverPhone"].ToString();
                receiveremail.Text = ds2.Tables[0].Rows[0]["ReceiverEmail"].ToString();
                receiveraddress.Text = ds2.Tables[0].Rows[0]["ReceiverAddress"].ToString();
                remark.Text = ds2.Tables[0].Rows[0]["Remark"].ToString();
            }
            if (carriageprice.Text == "0")
            {
                carriageway.Text = "自取";

            }
            if (carriageprice.Text == "5")
            {
                carriageway.Text = "送货上门";
            }
            if (state.Text == "待付款"|| state.Text == "待收货" || state.Text == "已成交" || state.Text == "已退款")
            {
                Button1.Visible = false;
            }
            if (state.Text == "待付款" || state.Text == "已退款")
            {
                Button2.Visible = false;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (state.Text == "待发货")
            {
                string str = "update [Order] set State='待收货' where OrderID=" + orderid;
                if (db.exsql(str))
                {
                    Response.Write("<script>alert('订单状态已更改')</script>");
                    Bind();
                }
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DefaultAopClient client = new DefaultAopClient(config.gatewayUrl, config.app_id, config.private_key, "json", "1.0", config.sign_type, config.alipay_public_key, config.charset, false);

            // 商户订单号，和交易号不能同时为空
            string out_trade_no = orderid.ToString();

            // 支付宝交易号，和商户订单号不能同时为空
            string trade_no = "";

            // 退款金额，不能大于订单总金额
            string refund_amount = totalprice.Text.Trim();

            // 退款原因
            string refund_reason = "退款";

            // 退款单号，同一笔多次退款需要保证唯一，部分退款该参数必填。
            string out_request_no = "";

            AlipayTradeRefundModel model = new AlipayTradeRefundModel();
            model.OutTradeNo = out_trade_no;
            model.TradeNo = trade_no;
            model.RefundAmount = refund_amount;
            model.RefundReason = refund_reason;
            model.OutRequestNo = out_request_no;

            AlipayTradeRefundRequest request = new AlipayTradeRefundRequest();
            request.SetBizModel(model);

            AlipayTradeRefundResponse response = null;
            try
            {
                response = client.Execute(request);
                
                string str = response.Body;
                string mark = "\"msg\":\"";
                int count = str.IndexOf(mark);
                string flag = str.Substring(count + 7, 7);
                System.Diagnostics.Debug.WriteLine(flag);
                if (flag == "Success")
                {
                    string sql = "update [Order] set State='已退款' where OrderID=" + orderid;
                    if (db.exsql(sql))
                    {
                        Response.Write("<script>alert('退款成功')</script>");
                        Bind();

                        
                       

                    }
                }
                else
                {
                    Response.Write("<script>alert('退款失败')</script>");
                }

            }
            catch (Exception exp)
            {
                throw exp;
            }
        }
    }
}