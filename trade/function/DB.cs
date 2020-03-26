using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace trade.function
{
    public class DB
    {
        public SqlConnection GetCon()
        {
            return new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"].ToString());
        }
        public SqlCommand GetSqlCommand(string str)
        {
            SqlConnection conn = GetCon();//连接数据库
            conn.Open();//并打开了连接
            SqlCommand com = new SqlCommand(str, conn);
            return com;
        }
        public DataTable GetDataSet(SqlCommand myCmd, string TableName)//TableName参数意义不大，但有助于调试时抓取数据
        {
            SqlDataAdapter adapt;
            DataSet ds = new DataSet();
            try
            {
                if (myCmd.Connection.State != ConnectionState.Open)
                {
                    myCmd.Connection.Open();
                }
                adapt = new SqlDataAdapter(myCmd);
                adapt.Fill(ds, TableName);
                return ds.Tables[TableName];

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);

            }
            finally
            {
                if (myCmd.Connection.State == ConnectionState.Open)
                {
                    myCmd.Connection.Close();

                }
            }

        }
        public SqlDataReader redr(string str)
        {
            SqlConnection conn = GetCon();//连接数据库
            conn.Open();//并打开了连接
            SqlCommand com = new SqlCommand(str, conn);
            SqlDataReader dr = com.ExecuteReader(CommandBehavior.CloseConnection);
            return dr;//返回SqlDataReader对象dr
        }

        public DataSet reds(string P_str_cmdtxt)
        {
            SqlConnection con = GetCon();//连接上数据库
            SqlDataAdapter da = new SqlDataAdapter(P_str_cmdtxt, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;//返回DataSet对象
        }

        public bool exsql(string P_str_cmdtxt)
        {
            SqlConnection con = GetCon();//连接数据库
            con.Open();//打开连接
            SqlCommand cmd = new SqlCommand(P_str_cmdtxt, con);
            try
            {
                cmd.ExecuteNonQuery();//执行SQL 语句并返回受影响的行数
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                con.Dispose();//释放连接对象资源
            }
        }


    }
}