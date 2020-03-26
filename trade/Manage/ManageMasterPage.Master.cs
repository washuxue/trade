using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace trade.Manage
{
    public partial class ManageMasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdminID"] == null|| Session["AdminName"] == null)
            {
                Response.Write("<script>alert('请先登录');location.href='AdminLogin.aspx';</script>");
            }
        }
    }
}