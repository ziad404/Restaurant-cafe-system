using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace EnterpriseCourt.DAL
{
    class DataAccessLayer
    {
        SqlConnection sqlConnection;
        public DataAccessLayer()
        {
            sqlConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS; Database=v2; Integrated Security=true");
        }
        public void Open()
        {
            if (sqlConnection.State != ConnectionState.Open)
            {
                sqlConnection.Open();
            }
        }
        public void Colse()
        {
            if (sqlConnection.State == ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        // Read Data
        public DataTable SelectData(string stored_procedure, SqlParameter[] param)
        {
            DataTable dt = new DataTable();
            try
            {

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = stored_procedure;
                sqlcmd.Connection = sqlConnection;

                if (param != null)
                {
                    sqlcmd.Parameters.AddRange(param);
                }
                SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
                da.Fill(dt);
            }
            catch (Exception)
            {
                MessageBox.Show("حدث شئ خطأ");
            }
            return dt;
        }

        // insert and update and delete query

        public void ExecuteCommand(string stored_procedure, SqlParameter[] param)
        {
            try
            {

                SqlCommand sqlcmd = new SqlCommand();
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.CommandText = stored_procedure;
                sqlcmd.Connection = sqlConnection;

                if (param != null)
                {
                    sqlcmd.Parameters.AddRange(param);
                }
                sqlcmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("حدث شئ خطأ");
            }
        }

    }
}
