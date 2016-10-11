using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherAssistant_DAL
{
    public class DBHelper
    {
        private static string connString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=E:/TeacherAssistant/TeacherAssistant/App_Data/StuDB.accdb;Persist Security Info = False";

        private static OleDbConnection conn = null;

        //初始化数据库链接
        private static void InitConnection()
        {
            if (conn == null)
                conn = new OleDbConnection(connString);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            if (conn.State == ConnectionState.Broken)
            {
                conn.Close();
                conn.Open();
            }
        }

        //查询，获取DataSet
        public static DataSet GetDataSet(string sqlStr)
        {
            InitConnection();
            DataSet ds = new DataSet();
            OleDbDataAdapter dap = new OleDbDataAdapter(sqlStr, conn);
            dap.Fill(ds);
            conn.Close();
            return ds;
        }

        //查询，获取DataTable
        public static DataTable GetDataTable(string sqlStr)
        {
            return GetDataSet(sqlStr).Tables[0];
        }

        //增改删
        public static bool ExecuteNonQuery(string sqlStr)
        {
            InitConnection();
            OleDbCommand cmd = new OleDbCommand(sqlStr, conn);
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            return result > 0;
        }
    }
}
