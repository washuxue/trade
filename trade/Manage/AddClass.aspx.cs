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
    public partial class ManageClass : System.Web.UI.Page
    {
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string str = "select * from Image";
                SqlCommand sc = db.GetSqlCommand(str);
                DataTable dsTable = db.GetDataSet(sc, "class");
                DropDownList1.DataSource = dsTable.DefaultView;
                DropDownList1.DataTextField = dsTable.Columns[1].ToString();
                DropDownList1.DataValueField = dsTable.Columns[2].ToString();
                DropDownList1.DataBind();


            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Image1.ImageUrl = DropDownList1.SelectedValue;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string classname = TextBox1.Text.Trim();
            string photo = DropDownList1.SelectedValue;
          
            
           
            SqlDataReader dr = db.redr("select * from Class where ClassName='" + classname + "'");


            if (dr.HasRows)
            {
                Response.Write("<script>alert('类别已存在')</script>");
            }
            else
            {
                string str = "insert into Class values('" + classname + "','" + photo + "')";
                
                if (db.exsql(str))
                {
                    Response.Write("<script>alert('添加成功')</script>");
                }

            }
        }
    }
}