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
    public partial class ShowInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string goodid = Request["GoodID"];
            DB db = new DB();

            SqlDataReader dr = db.redr("select * from GoodInfo,Class where GoodID='"+goodid+"'and GoodInfo.ClassID=Class.ClassID");
            while (dr.Read())
            {
                this.classname.Text = dr["ClassName"].ToString();
                this.goodname.Text = dr["GoodName"].ToString();
                this.originalprice.Text = dr["OriginalPrice"].ToString();
                this.currentprice.Text = dr["CurrentPrice"].ToString();
                this.brand.Text = dr["Brand"].ToString();
                this.photo.ImageUrl = dr["Photo"].ToString();
                this.checkrecommend.Checked = bool.Parse(dr["Recommend"].ToString());
                this.checknew.Checked = bool.Parse(dr["Recommend"].ToString());
                this.introduction.Text = dr["Introduction"].ToString();
                

            }


        }
    }
}