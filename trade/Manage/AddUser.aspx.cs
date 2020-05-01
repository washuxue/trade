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
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            string username = TextBox1.Text.Trim();
            string hash = TextBox2.Text.Trim();
            string password = BitConverter.ToString(MD5.Create().ComputeHash(Encoding.Default.GetBytes(hash))).Replace("-", "");
            string realname = TextBox3.Text.Trim();
            string sex = DropDownList1.SelectedValue;
            string phone = TextBox4.Text.Trim();
            string email = TextBox5.Text.Trim();
            string address = TextBox6.Text.Trim();

            SqlDataReader dr = db.redr("select * from [User] where UserName='" + username + "'");


            if (dr.HasRows)
            {
                Response.Write("<script>alert('名称已存在')</script>");
            }
            else
            {
                string str = "insert into [User] values('" + username + "','" + password + "','" + realname + "','" + sex + "','" + phone + "','" + email + "','" + address + "')";

                if (db.exsql(str))
                {
                    Response.Write("<script>alert('添加成功')</script>");
                }

            }
        }
    }
}