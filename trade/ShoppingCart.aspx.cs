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
    public partial class ShoppingCart : System.Web.UI.Page
    {
        DB db = new DB();
        string str;
        DataTable dtTable;
        Hashtable hashcar;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ShoppingCart"] == null)
                {
                    //如果没有购物，则给出相应信息，并隐藏按钮
                    this.Label1.Text = "您还没有购物！";
                    this.Label1.Visible = true;
                    this.LinkButton3.Visible = false;        
                    this.LinkButton4.Visible = false;      
                    this.LinkButton5.Visible = false;      
                    this.LinkButton6.Visible = false;   
                }
                else
                {
                    hashcar = (Hashtable)Session["ShoppingCart"];
                    if (hashcar.Count == 0)
                    {
                        //如果没有购物，则给出相应信息，并隐藏按钮
                        this.Label1.Text = "您的购物车中没有商品！";
                        this.Label1.Visible = true;
                        this.LinkButton3.Visible = false;
                        this.LinkButton4.Visible = false;
                        this.LinkButton5.Visible = false;
                        this.LinkButton6.Visible = false;
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
                        DataRow row;
                        foreach(object key in hashcar.Keys)
                        {
                            row = dtTable.NewRow();
                            row["GoodID"] = key.ToString();
                            row["GoodNum"] = hashcar[key].ToString();
                            dtTable.Rows.Add(row);
                        }

                        DataTable dsTable;
                        int i = 1;
                        float price;
                        int count;
                        float TotalPrice = 0;
                        foreach(DataRow dtrow in dtTable.Rows)
                        {
                            int goodid = int.Parse(dtrow["GoodID"].ToString());
                            str = "select GoodName,CurrentPrice from GoodInfo where GoodID=" + goodid;
                            SqlCommand sc = db.GetSqlCommand(str);
                            dsTable = db.GetDataSet(sc, "goodinfo");
                            dtrow["No"] = i;
                            dtrow["GoodName"] = dsTable.Rows[0][0].ToString();
                            dtrow["GoodPrice"] = dsTable.Rows[0][1].ToString();
                            price = float.Parse(dsTable.Rows[0][1].ToString());
                            count = Int32.Parse(dtrow["GoodNum"].ToString());
                            dtrow["TotalPrice"] = price * count;
                            TotalPrice= TotalPrice+ price * count;
                            i++;
                        }
                        this.Label2.Text = "总价:" + TotalPrice.ToString();
                        this.GridView1.DataSource = dtTable.DefaultView;
                        this.GridView1.DataKeyNames = new string[] { "GoodID" };
                        this.GridView1.DataBind();
                    }
                }
            }
        }

        

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            hashcar = (Hashtable)Session["ShoppingCart"];
            foreach(GridViewRow gridViewRow in this.GridView1.Rows)
            {
                TextBox t = (TextBox)gridViewRow.FindControl("GoodNum");
                int count = Int32.Parse(t.Text);
                string GoodID = gridViewRow.Cells[1].Text;
                hashcar[GoodID] = count;

            }
            Session["ShopingCart"] = hashcar;
            Response.Redirect("~/ShoppingCart.aspx");
        }

        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
            hashcar = (Hashtable)Session["ShoppingCart"];//获取其购物车
                                                     //从Hashtable表中，将指定的商品从购物车中移除，其中，删除按钮(lnkbtnDelete)的CommandArgument参数值为商品ID代号
            hashcar.Remove(e.CommandArgument);
            Session["ShoppingCart"] = hashcar; //更新购物车
            Response.Redirect("~/ShoppingCart.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session["ShoppingCart"] = null;
            Response.Redirect("~/ShoppingCart.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Write("<script>alert('请先登录')</script>");
            }
            else
            {
                Response.Redirect("~/CreateOrder.aspx");
            }
            
        }

        public void Bind()
        {
            if (Session["ShoppingCart"] == null)
            {
                //如果没有购物，则给出相应信息，并隐藏按钮
                this.Label1.Text = "您还没有购物！";
                this.Label1.Visible = true;
                this.LinkButton3.Visible = false;
                this.LinkButton4.Visible = false;
                this.LinkButton5.Visible = false;
                this.LinkButton6.Visible = false;
            }
            else
            {
                hashcar = (Hashtable)Session["ShoppingCart"];
                if (hashcar.Count == 0)
                {
                    //如果没有购物，则给出相应信息，并隐藏按钮
                    this.Label1.Text = "您的购物车中没有商品！";
                    this.Label1.Visible = true;
                    this.LinkButton3.Visible = false;
                    this.LinkButton4.Visible = false;
                    this.LinkButton5.Visible = false;
                    this.LinkButton6.Visible = false;
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
                    DataRow row;
                    foreach (object key in hashcar.Keys)
                    {
                        row = dtTable.NewRow();
                        row["GoodID"] = key.ToString();
                        row["GoodNum"] = hashcar[key].ToString();
                        dtTable.Rows.Add(row);
                    }

                    DataTable dsTable;
                    int i = 1;
                    float price;
                    int count;
                    float TotalPrice = 0;
                    foreach (DataRow dtrow in dtTable.Rows)
                    {
                        str = "select GoodName,CurrentPrice from GoodInfo where GoodID='" + dtrow["GoodID"].ToString() + "'";
                        SqlCommand sc = db.GetSqlCommand(str);
                        dsTable = db.GetDataSet(sc, "tb");//需要修改
                        dtrow["No"] = i;
                        dtrow["GoodName"] = dsTable.Rows[0][0].ToString();
                        dtrow["GoodPrice"] = dsTable.Rows[0][1].ToString();
                        price = float.Parse(dsTable.Rows[0][1].ToString());
                        count = Int32.Parse(dtrow["GoodNum"].ToString());
                        dtrow["TotalPrice"] = price * count;
                        TotalPrice = TotalPrice + price * count;
                        i++;
                    }
                    this.Label2.Text = "总价:" + TotalPrice.ToString();
                    this.GridView1.DataSource = dtTable.DefaultView;
                    this.GridView1.DataKeyNames = new string[] { "GoodID" };
                    this.GridView1.DataBind();
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