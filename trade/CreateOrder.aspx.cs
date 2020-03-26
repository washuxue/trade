using Aop.Api;
using Aop.Api.Domain;
using Aop.Api.Request;
using Aop.Api.Response;
using System;
using System.Collections;
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
    public partial class CreateOrder : System.Web.UI.Page
    {
        DB db = new DB();
        string str;
        DataTable dtTable;
        Hashtable hashcar;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["UserID"] == null)
            {
                
                
                Response.Write("<script>alert('请先登录');location.href='ShoppingCart.aspx';</script>");
            }
            if (!IsPostBack)
            {
                if (Session["UserID"] != null)
                {
                    str = "select RealName,Phone,Email,Address from [User] where UserID='" + Session["UserID"].ToString() + "'";
                    SqlCommand sc = db.GetSqlCommand(str);

                    //如果用户已登录，则显示用户的基本信息
                    DataTable dsTable = db.GetDataSet(sc, "tb");
                    this.TextBox4.Text = dsTable.Rows[0][0].ToString();
                    this.TextBox5.Text = dsTable.Rows[0][1].ToString();
                    this.TextBox6.Text = dsTable.Rows[0][2].ToString();
                    this.TextBox7.Text = dsTable.Rows[0][3].ToString();

                }
       
           
                if (Session["ShoppingCart"] == null)
                {
                    //如果没有购物，则给出相应信息，并隐藏按钮
                    this.Label1.Text = "您还没有购物！"; //显示提示信息
                    this.Button1.Visible = false;         //隐藏“确认”按钮
                }
                else
                {
                    hashcar = (Hashtable)Session["ShoppingCart"];
                    if (hashcar.Count == 0)
                    {
                        this.Label1.Text = "您的购物车中没有商品!";
                        this.Button1.Visible = false;

                    }
                    else
                    {
                        dtTable = new DataTable();
                        DataColumn column1 = new DataColumn("No");        //序号列
                        DataColumn column2 = new DataColumn("GoodID");    //商品ID
                        DataColumn column3 = new DataColumn("GoodName");  //商品名称
                        DataColumn column4 = new DataColumn("GoodNum");   //数量
                        DataColumn column5 = new DataColumn("GoodPrice"); //单价
                        DataColumn column6 = new DataColumn("TotalPrice");//总价
                        dtTable.Columns.Add(column1);  //添加新列            
                        dtTable.Columns.Add(column2);
                        dtTable.Columns.Add(column3);
                        dtTable.Columns.Add(column4);
                        dtTable.Columns.Add(column5);
                        dtTable.Columns.Add(column6);

                        DataRow dataRow;

                        foreach (object key in hashcar.Keys)
                        {
                            dataRow = dtTable.NewRow();
                            dataRow["GoodID"] = key.ToString();
                            dataRow["GoodNum"] = hashcar[key].ToString();
                            dtTable.Rows.Add(dataRow);
                        }
                        DataTable dsTable;
                        int i = 1;
                        float price;
                        int count;
                        float TotalPrice = 0;
                        int TotalCount = 0;
                        foreach (DataRow dtRow in dtTable.Rows)
                        {
                            str = "select GoodName,CurrentPrice from GoodInfo where GoodID='" + dtRow["GoodID"].ToString() + "'";
                            SqlCommand sc = db.GetSqlCommand(str);
                            dsTable = db.GetDataSet(sc, "tb");//需要修改
                            dtRow["No"] = i;
                            dtRow["GoodName"] = dsTable.Rows[0][0].ToString();
                            dtRow["GoodPrice"] = dsTable.Rows[0][1].ToString();
                            price = float.Parse(dsTable.Rows[0][1].ToString());
                            count = Int32.Parse(dtRow["GoodNum"].ToString());
                            dtRow["TotalPrice"] = price * count;
                            TotalPrice = TotalPrice + price * count;
                            TotalCount = TotalCount + count;
                            i++;
                        }
                        this.Label2.Text = TotalPrice.ToString();
                        this.Label3.Text = TotalCount.ToString();
                        this.GridView1.DataSource = dtTable.DefaultView;
                        this.GridView1.DataBind();
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int userid = int.Parse(Session["UserID"].ToString());
            float goodprice = float.Parse(this.Label2.Text);
            float carriageprice = float.Parse(this.DropDownList1.SelectedValue.ToString());
            float totalprice = goodprice + carriageprice;
            string receivername = this.TextBox4.Text.Trim();
            string receiverphone = this.TextBox5.Text.Trim();
            string receiveremail = this.TextBox6.Text.Trim();
            string receiveraddress = this.TextBox7.Text.Trim();
            string remark = this.TextBox8.Text.Trim();
            string generatetime = DateTime.Now.ToString();

            string sql = "insert into [Order] values('" + userid + "','" + goodprice + "','" + carriageprice + "','" + totalprice + "','" + receivername + "','" + receiveraddress + "','" + receiverphone + "','" + receiveremail + "','待付款','" + generatetime + "',null,null,'" + remark + "') select SCOPE_IDENTITY() as 'OrderID'";
            SqlDataReader dr = db.redr(sql);
            string orderid=null;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    orderid = dr["OrderID"].ToString();
                }
            }
            else
            {
                Response.Write("<script>alert('订单创建失败')</script>");
            }
            
            int goodid;
            int goodnum;
            float singleprice;
            float allprice;
            foreach(GridViewRow gridViewRow in this.GridView1.Rows)
            {
                goodid = int.Parse(gridViewRow.Cells[1].Text);
                goodnum = int.Parse(gridViewRow.Cells[3].Text);
                singleprice = float.Parse(gridViewRow.Cells[4].Text);
                allprice = float.Parse(gridViewRow.Cells[5].Text);
                sql="insert into OrderDetail values('"+goodid+"','"+goodnum+"','"+singleprice+
                    "','"+allprice+"','"+orderid+"')";
                if (!db.exsql(sql))
                {
                    Response.Write("<script>alert('订单创建失败')</script>");
                }
            }
            Session["ShoppingCart"] = null;
            Response.Write("<script>alert('下单成功,请尽快支付')</script>");



            DefaultAopClient client = new DefaultAopClient(config.gatewayUrl, config.app_id, config.private_key, "json", "1.0", config.sign_type, config.alipay_public_key, config.charset, false);

            // 外部订单号，商户网站订单系统中唯一的订单号
            string out_trade_no = orderid.ToString();

            // 订单名称
            string subject = "安徽大学校园物品交易系统结算中心";

            // 付款金额
            string total_amout = totalprice.ToString();

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
            request.SetReturnUrl(config.nataddress+"/Return_url.aspx");
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
}