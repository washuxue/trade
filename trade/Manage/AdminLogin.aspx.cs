using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using trade.function;

namespace trade.Manage
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["AdminID"] = null;
            Session["AdminName"] = null;

        }

   

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
         


            //清空Session对象
            Session["AdminID"] = null;
            Session["AdminName"] = null;

            if (this.TextBox1.Text.Trim() == "" || this.TextBox2.Text.Trim() == "")
            {
                Response.Write("<script>alert('用户名或密码不能为空')</script>");
            }
            else
            {
                string adminname = TextBox1.Text.Trim();
                string hash = TextBox2.Text.Trim();
                string password = BitConverter.ToString(MD5.Create().ComputeHash(Encoding.Default.GetBytes(hash))).Replace("-", "");
                SqlDataReader dr = db.redr("select * from Admin where AdminName='" +
                    adminname + "'and Password='" + password + "'");
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Session["AdminID"] = dr["AdminID"].ToString();
                        Session["Adminname"] = dr["AdminName"].ToString();
                        Session["RealName"] = dr["RealName"].ToString();
                        Response.Redirect("~/Manage/ManageHome.aspx");
                    }
                }
                else
                {
                    Response.Write("<script>alert('用户名或密码错误')</script>");
                }
            }
        }
    }
}