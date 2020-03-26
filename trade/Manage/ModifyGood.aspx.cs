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
    public partial class ModifyGood : System.Web.UI.Page
    {
        DB db = new DB();
        int goodid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClassBind(); //绑定商品类别
                ImageBind();
                Bind();
            }

        }
        public void ClassBind()
        {
            string str = "select * from Class";
            SqlCommand sc = db.GetSqlCommand(str);
            DataTable dsTable = db.GetDataSet(sc, "class");
            DropDownList1.DataSource = dsTable.DefaultView;
            DropDownList1.DataTextField = dsTable.Columns[1].ToString();
            DropDownList1.DataValueField = dsTable.Columns[0].ToString();
            DropDownList1.DataBind();
        }
        public void ImageBind()
        {
            string str = "select * from Image";
            SqlCommand sc = db.GetSqlCommand(str);
            DataTable dsTable = db.GetDataSet(sc, "image");
            DropDownList2.DataSource = dsTable.DefaultView;
            DropDownList2.DataTextField = dsTable.Columns[1].ToString();
            DropDownList2.DataValueField = dsTable.Columns[2].ToString();
            DropDownList2.DataBind();
        }
        public void Bind()
        {
            goodid = int.Parse(Request.Params["GoodID"].ToString());


            SqlDataReader dr = db.redr("select * from GoodInfo,Class where GoodID=" + goodid + "and GoodInfo.ClassID=Class.ClassID");
            while (dr.Read())
            {
                string classname = dr["ClassName"].ToString();
                DropDownList1.Items.FindByText(classname).Selected = true;
                this.goodname.Text = dr["GoodName"].ToString();
                this.originalprice.Text = dr["OriginalPrice"].ToString();
                this.currentprice.Text = dr["CurrentPrice"].ToString();
                this.brand.Text = dr["Brand"].ToString();
                DropDownList2.Items.FindByValue(dr["Photo"].ToString()).Selected = true;
                this.photo.ImageUrl = dr["Photo"].ToString();
                this.checkrecommend.Checked = bool.Parse(dr["Recommend"].ToString());
                this.checknew.Checked = bool.Parse(dr["New"].ToString());
                this.introduction.Text = dr["Introduction"].ToString();


            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            goodid = int.Parse(Request.Params["GoodID"].ToString());
            string goodname = this.goodname.Text.Trim();
            int classid = int.Parse(DropDownList1.SelectedValue);
            float originalprice = float.Parse(this.originalprice.Text.Trim());
            float currentprice = float.Parse(this.currentprice.Text.Trim());
            string photo = DropDownList2.SelectedValue;
            string brand = this.brand.Text.Trim();
            string introduction = this.introduction.Text.Trim();
            bool recommend = checkrecommend.Checked;
            bool New = checknew.Checked;



            string str = "update GoodInfo set GoodName='" + goodname + "',ClassID=" + classid +
            ",OriginalPrice=" + originalprice + ",CurrentPrice=" + currentprice + ",Photo='" + photo +
            "',Brand='" + brand + "',Introduction='" + introduction + "',Recommend='" + recommend +
            "',New='" + New + "' where GoodID=" + goodid;
            if (db.exsql(str))
            {
                Response.Write("<script>alert('修改成功')</script>");
            }


        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.photo.ImageUrl = DropDownList2.SelectedValue;


        }
    }
}