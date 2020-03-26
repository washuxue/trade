using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using trade.function;

namespace trade.Manage
{
    public partial class ManageImage : System.Web.UI.Page
    {
        DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        public void Bind()
        {           
            string str = "select * from Image";
            SqlCommand sc = db.GetSqlCommand(str);
            DataTable dsTable = db.GetDataSet(sc, "image");
            int curpage = Convert.ToInt32(this.labPage.Text);
            PagedDataSource ps = new PagedDataSource();
            ps.DataSource = dsTable.DefaultView;
            ps.AllowPaging = true; //是否可以分页
            ps.PageSize = 12; //显示的数量
            ps.CurrentPageIndex = curpage - 1; //取得当前页的页码
            this.lnkbtnUp.Enabled = true;
            this.lnkbtnNext.Enabled = true;
            this.lnkbtnBack.Enabled = true;
            this.lnkbtnOne.Enabled = true;
            if (curpage == 1)
            {
                this.lnkbtnOne.Enabled = false;//不显示第一页按钮
                this.lnkbtnUp.Enabled = false;//不显示上一页按钮
            }
            if (curpage == ps.PageCount)
            {
                this.lnkbtnNext.Enabled = false;//不显示下一页
                this.lnkbtnBack.Enabled = false;//不显示最后一页
            }
            this.labBackPage.Text = Convert.ToString(ps.PageCount);
            this.DataList1.DataSource = ps;
            this.DataList1.DataKeyField = "ImageID";
            this.DataList1.DataBind();


        }
        protected void lnkbtnOne_Click(object sender, EventArgs e)
        {
            this.labPage.Text = "1";
            Bind();

        }
        protected void lnkbtnUp_Click(object sender, EventArgs e)
        {
            this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) - 1);
            Bind();
        }
        protected void lnkbtnNext_Click(object sender, EventArgs e)
        {
            this.labPage.Text = Convert.ToString(Convert.ToInt32(this.labPage.Text) + 1);
            Bind();
        }
        protected void lnkbtnBack_Click(object sender, EventArgs e)
        {
            this.labPage.Text = this.labBackPage.Text;
            Bind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {                               
                if (FileUpload1.PostedFile.FileName == "")
                {
                    Response.Write("<script>alert('图片不允许为空')</script>");                    
                }
                else
                {
                    string filePath = FileUpload1.PostedFile.FileName;
                    string filename = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    string fileEx = filePath.Substring(filePath.LastIndexOf(".") + 1);
                    string serverpath = Server.MapPath(@"~\images\Good\") + filename;//@在c#中为强制不转义 的符号,在里面的转义字符无效
                    string relativepath = "~/images/Good/" + filename;
                    string str = "select * from Image where ImageName='" + filename + "'";

                    SqlCommand sc = db.GetSqlCommand(str);
                    DataTable dsTable = db.GetDataSet(sc, "image");
                    if (dsTable.Rows.Count > 0)
                    {
                        Response.Write("<script>alert('图片已存在')</script>");
                    }
                    else
                    {                       
                        if (fileEx == "jpg" || fileEx == "bmp" || fileEx == "gif")
                        {                   
                            FileUpload1.SaveAs(serverpath);                     
                            string sql = "insert into Image values('"+filename+"','"+relativepath+"')";
                            if (db.exsql(sql))
                            {
                                Response.Write("<script>alert('上传成功')</script>");
                                Bind();
                            }
                        }
                        else
                        {
                            Response.Write("<script>alert('上传的图片扩展名错误')</script>");

                        }
                    }
                }
            }
            catch (Exception error)
            {
                point.Text = "处理发生错误！原因：" + error.ToString();
            }
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            int imageid = int.Parse(e.CommandArgument.ToString());
            string str1 = "select ImageName from Image where ImageID=" + imageid;
            string str2 = "delete from Image where ImageID=" + imageid;
            string imagename = null;
            SqlDataReader dr = db.redr(str1);
            while (dr.Read())
            {
                imagename = dr["ImageName"].ToString();        
            }
            string filepath = Server.MapPath("~/images/Good/") + imagename;
            File.Delete(filepath);
            if (db.exsql(str2))
            {
                Response.Write("<script>alert('删除成功')</script>");
                Bind();
            }
        }
    }
}