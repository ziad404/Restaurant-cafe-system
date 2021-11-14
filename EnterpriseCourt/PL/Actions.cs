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
    }
}
