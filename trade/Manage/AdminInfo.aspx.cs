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
    public partial class AdminInfo : System.Web.UI.Page
    {
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
          
            if (!IsPostBack)
            {
                if (Session["AdminID"] != null)
                {
                    Bind();



                }
            }
        }
        public void Bind()
        {
            int adminid = int.Parse(Session["AdminID"].ToString());


            SqlDataReader dr = db.redr("select * from Admin where AdminID=" + adminid);
            while (dr.Read())
            {

                TextBox1.Text = dr["AdminName"].ToString();
                TextBox2.Attributes["value"] = dr["PassWord"].ToString();
                TextBox3.Attributes["value"] = dr["PassWord"].ToString();
                TextBox4.Text = dr["RealName"].ToString();           
                TextBox5.Text = dr["Email"].ToString();
                
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int adminid = int.Parse(Session["AdminID"].ToString());
            if (TextBox2.Text.Trim() == TextBox3.Text.Trim())
            {
                string hash= TextBox2.Text.Trim();
                string password = BitConverter.ToString(MD5.Create().ComputeHash(Encoding.Default.GetBytes(hash))).Replace("-", "");
                string realname = TextBox4.Text.Trim();          
                string email = TextBox5.Text.Trim();          
                string sql = "update Admin set Password='" + password + "',RealName='" + realname + "',Email='" + email + "' where AdminID=" + adminid;
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