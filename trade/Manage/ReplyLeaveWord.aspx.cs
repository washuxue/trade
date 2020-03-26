using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using trade.function;

namespace trade.Manage
{
    public partial class ReplyLeaveWord : System.Web.UI.Page
    {
        DB db = new DB();
        int wordid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request["WordID"] != null)
            {
                wordid = int.Parse(Request["WordID"]);
            }
            string str = "select * from LeaveWord where WordID=" + wordid;
            SqlDataReader dr = db.redr(str);
            while (dr.Read())
            {              
                Label1.Text= dr["LeaveTheme"].ToString();
                Label2.Text = dr["LeaveContent"].ToString();
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {            
            int adminid = int.Parse(Session["AdminID"].ToString());
            string adminname = Session["AdminName"].ToString();
            string replycontent = TextBox1.Text.Trim();
            string replytime = DateTime.Now.ToString();
            string adminip = Request.UserHostAddress;
            string sql = "update LeaveWord set AdminID=" + adminid + ",AdminName='" +
                adminname + "',ReplyContent='" + replycontent + "',ReplyTime='" + replytime + 
                "',AdminIP='" + adminip + "' where WordID=" + wordid;
            if (db.exsql(sql))
            {
                Response.Write("<script>alert('回复成功')</script>");
                
            }


        }
    }
}