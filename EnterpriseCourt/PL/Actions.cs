using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

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
        public DataTable delete_item(int id)
        {
            DataTable DT = new DataTable();

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@Id", SqlDbType.Int);
            param[0].Value = id;

            DAL.Open();
            DT = DAL.SelectData("delete_item", param);
            return DT;

        }


        public DataTable get_item_price(int id)
        {
            DataTable DT = new DataTable();

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            DAL.Open();
            DT = DAL.SelectData("get_item_price", param);
            return DT;

        }


        public DataTable add_item(string name,float price,int cat_id, int type_id)
        {
            DataTable DT = new DataTable();

            try
            {
                DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
                SqlParameter[] param = new SqlParameter[4];
                param[0] = new SqlParameter("@name", SqlDbType.NVarChar, 100);
                param[0].Value = name;
                param[1] = new SqlParameter("@price", SqlDbType.Float);
                param[1].Value = price;
                param[2] = new SqlParameter("@cat_id", SqlDbType.Int);
                param[2].Value = cat_id;
                param[3] = new SqlParameter("@type_order_id", SqlDbType.Int);
                param[3].Value = type_id;
                DAL.Open();
                DT = DAL.SelectData("add-item", param);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return DT;


        }


        public DataTable Update_item_price(float price, int id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@price", SqlDbType.Float);
            param[0].Value = price;
            param[1] = new SqlParameter("@id", SqlDbType.Int);
            param[1].Value = id;
            DAL.Open();
            DataTable DT = new DataTable();
            DT = DAL.SelectData("update_item_price", param);
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

        public DataTable getAllItemsBasedOnCatId(int id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            DAL.Open();

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("get_items_based_on_cat_id", param);
            DAL.Colse();
            return Dt;
        }
        public DataTable getAllTypes()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("get_types", null);
            DAL.Colse();
            return Dt;
        }

        public DataTable getAllTables()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("get_tables", null);
            DAL.Colse();
            return Dt;
        }
    }
}
