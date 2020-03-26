using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using trade.function;

namespace trade.Manage
{
    public partial class ManageAdmin : System.Web.UI.Page
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
            string str = "select * from Admin";

            DataSet ds = db.reds(str);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }



        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                int adminid = int.Parse(e.CommandArgument.ToString());
                string str = "delete from Admin where AdminID=" + adminid;



                if (db.exsql(str))
                {
                    Response.Redirect("~/Manage/ManageAdmin.aspx");

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