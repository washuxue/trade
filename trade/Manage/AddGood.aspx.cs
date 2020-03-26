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
    public partial class AddGood : System.Web.UI.Page
    {
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClassBind(); //绑定商品类别
                ImageBind();

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
        protected void Button1_Click(object sender, EventArgs e)
        {
            string goodname = TextBox1.Text.Trim();
            int classid = int.Parse(DropDownList1.SelectedValue);
            float originalprice = float.Parse(TextBox2.Text.Trim());
            float currentprice = float.Parse(TextBox3.Text.Trim());
            string photo = DropDownList2.SelectedValue;
            string brand = TextBox4.Text.Trim();
            string introduction = TextBox5.Text.Trim();
            bool recommend = CheckBox1.Checked;
            bool New = CheckBox2.Checked;
            string loadtime = DateTime.Now.ToString();
            System.Diagnostics.Debug.Write("时间 " + loadtime);
            SqlDataReader dr = db.redr("select * from GoodInfo where GoodName='" + goodname + "'and Brand='" + brand + "'");


            if (dr.HasRows)
            {
                Response.Write("<script>alert('商品已存在')</script>");
            }
            else
            {
                string str = "insert into GoodInfo values('" + goodname + "'," + classid + "," + originalprice + "," + currentprice + ",'" + photo + "','" + brand + "','" + introduction + "','" + recommend + "','" + New + "','" + loadtime + "')";
               
                if (db.exsql(str))
                {
                    Response.Write("<script>alert('添加成功')</script>");
                }

            }
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Image1.ImageUrl = DropDownList2.SelectedValue;


        }


    }
}