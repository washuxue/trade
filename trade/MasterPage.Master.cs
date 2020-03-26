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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {

                if (Session["UserID"] != null)
                {
                    //判断用户是否登录
                    this.nologin.Visible = false; 
                    this.login.Visible = true;
                    this.Label1.Text = Session["RealName"].ToString();

                }

                

                DataSet ds = db.reds("select * from Class");
                DataList1.DataSource = ds;
                DataList1.DataBind();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
           


            //清空Session对象
            Session["UserID"] = null;
            Session["Username"] = null;

            if (this.TextBox1.Text.Trim() == "" || this.TextBox2.Text.Trim() == "")
            {
                Response.Write("<script>alert('用户名或密码不能为空')</script>");
            }
            else
            {
                string username = TextBox1.Text.Trim();
                string password = TextBox2.Text.Trim();
                SqlDataReader dr = db.redr("select * from [User] where UserName='" +
                    username + "'and Password='" + password + "'");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    { 
                        Session["UserID"] = dr["UserID"].ToString();
                        Session["Username"] = dr["UserName"].ToString();
                        Session["RealName"] = dr["RealName"].ToString();
                        Response.Redirect("Default.aspx");          
                    }
                }
                else
                {
                    Response.Write("<script>alert('用户名或密码错误')</script>");
                }
            }


        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            
            
                string classid = e.CommandArgument.ToString();

                Response.Write("<script>window.open('List.aspx?point=class&&var="+ classid + "')</script>");
            
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            this.nologin.Visible = false;
            this.login.Visible = true;
            Session["UserID"] = null;
            Session["Username"] = null;
            Response.Redirect("~/Default.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/UserRegister.aspx");
        }
    }
}