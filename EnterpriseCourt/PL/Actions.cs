using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace EnterpriseCourt.PL
{
    class Actions
    {
        public DataTable Login(string userName, string password)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@userName", SqlDbType.VarChar, 50);
            param[0].Value = userName;

            param[1] = new SqlParameter("@password", SqlDbType.VarChar, 50);
            param[1].Value = password;

            DAL.Open();
            DataTable DT = new DataTable();
            DT = DAL.SelectData("login", param);
            return DT;
        }
        public DataTable Add_User(string userName, string password, string role)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[3];

            param[0] = new SqlParameter("@userName", SqlDbType.VarChar, 50);
            param[0].Value = userName;

            param[1] = new SqlParameter("@password", SqlDbType.VarChar, 50);
            param[1].Value = password;
            param[2] = new SqlParameter("@role", SqlDbType.VarChar, 50);
            param[2].Value = role;

            DAL.Open();
            DataTable DT = new DataTable();
            DT = DAL.SelectData("add_user", param);
            return DT;
        }
        public DataTable add_table(string name ,int status)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@name", SqlDbType.VarChar, 50);
            param[0].Value = name;

            param[1] = new SqlParameter("@status", SqlDbType.Bit);
            param[1].Value = status;
            DAL.Open();
            DataTable DT = new DataTable();
            DT = DAL.SelectData("add_table", param);
            return DT;

        }
        public DataTable add_category(string name)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 50);
            param[0].Value = name;
            DAL.Open();
            DataTable DT = new DataTable();
            DT = DAL.SelectData("add_category", param);
            return DT;

        }
        public DataTable Update_admin_pass(string new_pass,int id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@password", SqlDbType.VarChar, 50);
            param[0].Value = new_pass;
            param[1] = new SqlParameter("@id", SqlDbType.Int);
            param[1].Value = id;
            DAL.Open();
            DataTable DT = new DataTable();
            DT = DAL.SelectData("update_admin_pass", param);
            return DT;
        }
        public DataTable getAllCategories()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("get_categories", null);
            DAL.Colse();
            return Dt;
        }
    }
}
