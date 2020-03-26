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
    public partial class ManageGood : System.Web.UI.Page
    {
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string str = "select * from GoodInfo";
                Bind(str);
 



            }
        }
        public void Bind(string str)
        {
            SqlCommand sc = db.GetSqlCommand(str);
            DataTable dsTable = db.GetDataSet(sc, "goodinfo");
            GridView1.DataSource = dsTable;
            GridView1.DataKeyNames = new string[] { "GoodID" };
            GridView1.DataBind();

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "modify")
            {

                Response.Redirect("~/Manage/ModifyGood.aspx?GoodID=" + e.CommandArgument.ToString());
            }
            if (e.CommandName == "del")
            {
                int goodid = int.Parse(e.CommandArgument.ToString());
                string str = "delete from GoodInfo where GoodID=" + goodid;
        
                SqlDataReader dr = db.redr("select * from OrderDetail where GoodID="+goodid);
               
                if (dr.HasRows)
                {
                    Response.Write("<script>alert('该商品包含在订单中，无法删除');location.href='ManageGood.aspx';</script>");
                }
                else
                {
                    if (db.exsql(str))
                    {
                        Response.Redirect("~/Manage/ManageGood.aspx");

                    }
                    else
                    {
                        Response.Write("<script>alert('删除失败')</script>");
                    }

                }

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str=null;
            if (DropDownList1.SelectedItem.ToString() == "ID")
            {

                str = "select * from GoodInfo where GoodID='" + TextBox1.Text.Trim() + "'";

            }
            else if(DropDownList1.SelectedItem.ToString() == "名称")
            {
                str = "select * from GoodInfo where GoodName='" + TextBox1.Text.Trim()+"'";
              
            }
            else if(DropDownList1.SelectedItem.ToString() == "类别")
            {
                str = "select GoodInfo.*,Class.ClassName from GoodInfo,Class where GoodInfo.ClassID=Class.ClassID and ClassName='" + TextBox1.Text.Trim() + "'";
            }
            Bind(str);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            Bind("select * from GoodInfo");
            
        }
    }
}