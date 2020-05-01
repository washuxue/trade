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

namespace trade
{
    public partial class UserInfo : System.Web.UI.Page
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


            SqlDataReader dr = db.redr("select * from [User] where UserID=" + userid);
            while (dr.Read())
            {
           
                TextBox3.Text = dr["UserName"].ToString();
                TextBox4.Attributes["value"] = dr["PassWord"].ToString();
                TextBox5.Attributes["value"] = dr["PassWord"].ToString();
                TextBox6.Text = dr["RealName"].ToString();
                TextBox7.Text = dr["Sex"].ToString();
                TextBox8.Text = dr["Phone"].ToString();
                TextBox9.Text = dr["Email"].ToString();
                TextBox10.Text = dr["Address"].ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int userid = int.Parse(Session["UserID"].ToString());
            if (TextBox4.Text.Trim() == TextBox5.Text.Trim())
            {
                string hash = TextBox4.Text.Trim();
                string password = BitConverter.ToString(MD5.Create().ComputeHash(Encoding.Default.GetBytes(hash))).Replace("-", "");
                string realname = TextBox6.Text.Trim();
                string sex = TextBox7.Text.Trim();
                string phone = TextBox8.Text.Trim();
                string email = TextBox9.Text.Trim();
                string address = TextBox10.Text.Trim();
                string sql = "update [User] set Password='" + password + "',RealName='" + realname + "',Sex='" + sex + "',Phone='" + phone + "',Email='" + email + "',Address='" + address + "' where UserID=" + userid;
                if (db.exsql(sql))
                {
                    Response.Write("<script>alert('修改成功');</script>");
                    Bind();
                }
                else
                {
                    Response.Write("<script>alert('修改失败');</script>");

                }


            }
            else
            {
                Response.Write("<script>alert('密码不一致');</script>");
            }
        }
    }
}