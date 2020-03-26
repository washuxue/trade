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
    public partial class List : System.Web.UI.Page
    {
        string Point = null;
        string Var = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            Point = Request["point"];
            Var = Request["var"];
            if (!IsPostBack)
            {
                Bind();
            }
        }

        public void Bind()
        {
            DB db = new DB();
            string str = null;
            if (Point == "introduction")
            {
                str = "select * from GoodInfo where Recommend='true'";
            }
            else if(Point == "new")
            {
                str = "select * from GoodInfo where New='true'";
            }
            else if (Point == "seekname")
            {
                str = "select * from GoodInfo where GoodName='"+Var+"'";
            }
            else if (Point == "seekid")
            {
                str = "select * from GoodInfo where GoodID='" + Var + "'";
            }
            else if (Point == "seekprice")
            {
                str = "select * from GoodInfo where CurrentPrice='" + Var + "'";
            }
            else if (Point == "class")
            {
                str = "select * from GoodInfo where ClassID='" + Var + "'";
            }
            else
            {
                str = "select * from GoodInfo";
            }
            
            SqlCommand sc = db.GetSqlCommand(str);
            DataTable dsTable = db.GetDataSet(sc, "goodinfo");
            int curpage = Convert.ToInt32(this.labPage.Text);
            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = dsTable.DefaultView;
            ps.AllowPaging = true; //是否可以分页
            ps.PageSize = 8; //显示的数量
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
            this.DataList1.DataSource = ps;
            this.DataList1.DataKeyField = "GoodID";
            this.DataList1.DataBind();


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
                    int count = Convert.ToInt32(hashcar[e.CommandArgument].ToString());
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