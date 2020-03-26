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
    public partial class MyLeaveWord : System.Web.UI.Page
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
        public void Bind()
        {
            
            int userid = int.Parse(Session["UserID"].ToString());
            string str = "select * from LeaveWord where UserID=" + userid+
                " order by LeaveTime desc";
            SqlCommand sc = db.GetSqlCommand(str);
            DataTable dsTable = db.GetDataSet(sc, "tb");
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
            this.DataList1.DataSource = ps;
            this.DataList1.DataKeyField = "WordID";
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            int userid = int.Parse(Session["UserID"].ToString());
            string username = Session["UserName"].ToString();
            string leavetheme = TextBox4.Text.Trim();
            string leavecontent = TextBox5.Text.Trim();
            string leavetime = DateTime.Now.ToString();
            string userip = Request.UserHostAddress;
            string sql = "insert into LeaveWord values(" + userid + ",'" + username + "','" + leavetheme + "','" + leavecontent + "','" + leavetime + "','" + userip + "',null,null,null,null,null)";
            if (db.exsql(sql))
            {
                Response.Write("<script>alert('留言已提交')</script>");
                Bind();
            }
        }
    }
}