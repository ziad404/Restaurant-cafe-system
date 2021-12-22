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

        public DataTable add_to_salles(
            int item_id,
            string item_name,
            float item_price,
            int order_type,
            int order_kind,
            DateTime date,
            int order_id
            )
        {


            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[7];

            param[0] = new SqlParameter("@item_id", SqlDbType.Int);
            param[0].Value = item_id;

            param[1] = new SqlParameter("@item_name", SqlDbType.NVarChar, 50);
            param[1].Value = item_name;

            param[2] = new SqlParameter("@item_price", SqlDbType.Float);
            param[2].Value = item_price;

            param[3] = new SqlParameter("@order_type", SqlDbType.Int);
            param[3].Value = order_type;

            param[4] = new SqlParameter("@order_kind", SqlDbType.Int);
            param[4].Value = order_kind;

            param[5] = new SqlParameter("@date", SqlDbType.DateTime);
            param[5].Value = date;

            param[6] = new SqlParameter("@order_id", SqlDbType.Int);
            param[6].Value = order_id;

            DAL.Open();
            DataTable DT = new DataTable();
            DT = DAL.SelectData("add_to_salles", param);
            return DT;
        }
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
        public DataTable add_table(string name, bool status)
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
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = id;

            DAL.Open();

            DT = DAL.SelectData("delete_item", param);
            return DT;

        }
        public DataTable delete_one_item(int pass)
        {
            DataTable DT = new DataTable();

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@pass", SqlDbType.Int);
            param[0].Value = pass;

            DAL.Open();
            DT = DAL.SelectData("delete_one_item", param);
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

        public DataTable get_item(int id)
        {
            DataTable DT = new DataTable();

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;

            DAL.Open();
            DT = DAL.SelectData("get_item", param);
            return DT;

        }
        public DataTable get_drinks_sales_based_on_order_type(int id)
        {
            DataTable DT = new DataTable();

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_type_id", SqlDbType.Int);
            param[0].Value = id;

            DAL.Open();
            DT = DAL.SelectData("get_drinks_sales_based_on_order_type", param);
            return DT;

        }

        public DataTable get_food_sales_based_on_order_type(int id)
        {
            DataTable DT = new DataTable();

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_type_id", SqlDbType.Int);
            param[0].Value = id;

            DAL.Open();
            DT = DAL.SelectData("get_food_sales_based_on_order_type", param);
            return DT;

        }

        public DataTable get_orders_on_spacific_table(int table_id)
        {
            DataTable DT = new DataTable();

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@table_id", SqlDbType.Int);
            param[0].Value = table_id;

            DAL.Open();
            DT = DAL.SelectData("get_orders_on_spacific_table", param);
            return DT;

        }

        public DataTable get_order_number(int order_id)
        {
            DataTable DT = new DataTable();

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = order_id;

            DAL.Open();
            DT = DAL.SelectData("get_order_number", param);
            return DT;

        }
        public DataTable get_all_items_from_order(int order_id)
        {
            DataTable DT = new DataTable();

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = order_id;

            DAL.Open();
            DT = DAL.SelectData("get_all_items_from_order", param);
            return DT;

        }
        public DataTable update_table_status(int table_id, bool status)
        {
            DataTable DT = new DataTable();

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = table_id;

            param[1] = new SqlParameter("@status", SqlDbType.Int);
            param[1].Value = status;

            DAL.Open();
            DT = DAL.SelectData("update_status", param);
            return DT;

        }
        public DataTable add_item_to_order(int order_id, int item_id)
        {
            DataTable DT = new DataTable();

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = order_id;
            param[1] = new SqlParameter("@item_id", SqlDbType.Int);
            param[1].Value = item_id;

            DAL.Open();
            DT = DAL.SelectData("add_items_to_orders", param);
            return DT;

        }
        public DataTable update_counter_from_spacific_order(int order_id, int counter)
        {
            DataTable DT = new DataTable();

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@counter", SqlDbType.Int);
            param[0].Value = counter;
            param[1] = new SqlParameter("@order_id", SqlDbType.Int);
            param[1].Value = order_id;

            DAL.Open();
            DT = DAL.SelectData("update_counter_from-spacific_order", param);
            return DT;

        }
        public DataTable add_order_to_table(int order_id, int table_id)
        {
            DataTable DT = new DataTable();

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = order_id;
            param[1] = new SqlParameter("@table_id", SqlDbType.Int);
            param[1].Value = table_id;

            DAL.Open();
            DT = DAL.SelectData("add_order_to_table", param);
            return DT;

        }
        public DataTable empty_day()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable DT = new DataTable();
            DAL.Open();
            DT = DAL.SelectData("empty_day", null);
            DAL.Colse();
            updateCounter(1);
            return DT;
        }
        public DataTable get_daily_sales(int order_id)
        {
            DataTable DT = new DataTable();

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_type", SqlDbType.Int);
            param[0].Value = order_id;


            DAL.Open();
            DT = DAL.SelectData("get_daily_sales", param);
            return DT;

        }
        public DataTable insert_daily_order(int order_id)
        {
            DataTable DT = new DataTable();

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = order_id;


            DAL.Open();
            DT = DAL.SelectData("insert_daily_order", param);
            return DT;

        }
        public DataTable delete_from_daily_sales(int order_id)
        {
            DataTable DT = new DataTable();

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = order_id;


            DAL.Open();
            DT = DAL.SelectData("delete_from_daily_sales", param);
            return DT;

        }
        public DataTable add_item(string name, float price, int cat_id, int type_id)
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
            }
            return DT;


        }
        public DataTable add_order(int order_type_id, int order_number, DateTime dateTime)
        {
            DataTable DT = new DataTable();

            try
            {
                DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@order_type_id", SqlDbType.Int);
                param[0].Value = order_type_id;
                param[1] = new SqlParameter("@order_number", SqlDbType.Int);
                param[1].Value = order_number;
                param[2] = new SqlParameter("@Date", SqlDbType.DateTime);
                param[2].Value = dateTime;
                DAL.Open();
                DT = DAL.SelectData("add_order", param);
            }
            catch (Exception e)
            {
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
        public DataTable Update_admin_pass(string new_pass, int id)
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
        public DataTable delete_by_serial(int reciept_num)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = reciept_num;
            DAL.Open();
            DataTable DT = new DataTable();
            DT = DAL.SelectData("delete_order_by_serial", param);
            return DT;
        }
        public DataTable delete_from_salles_items_with_order(int reciept_num)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = reciept_num;
            DAL.Open();
            DataTable DT = new DataTable();
            DT = DAL.SelectData("delete_from_salles_items_with_order", param);
            return DT;
        }
        public DataTable delete_order_table(int order_id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = order_id;
            DAL.Open();
            DataTable DT = new DataTable();
            DT = DAL.SelectData("delete_order_table", param);

            return DT;
        }
        public DataTable delete_order_with_table(int table_id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@table_id", SqlDbType.Int);
            param[0].Value = table_id;
            DAL.Open();
            DataTable DT = new DataTable();
            DT = DAL.SelectData("delete_order_with_table", param);
            update_table_status(table_id, false);
            return DT;
        }
        public DataTable delete_one_item_from_order(int order_id, int item_id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@order_id", SqlDbType.Int);
            param[0].Value = order_id;
            param[1] = new SqlParameter("@item_id", SqlDbType.Int);
            param[1].Value = item_id;
            DAL.Open();
            DataTable DT = new DataTable();
            DT = DAL.SelectData("delete_one_item_from_order", param);
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
        public DataTable getAllorderstypes()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("get_all_orders_types", null);
            DAL.Colse();
            return Dt;
        }
        public DataTable get_customers()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("get_customers", null);
            DAL.Colse();
            return Dt;
        }
        public DataTable add_customer(string address, string phone)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@address", SqlDbType.NVarChar, 50);
            param[0].Value = address;
            param[1] = new SqlParameter("@phone", SqlDbType.NVarChar, 50);
            param[1].Value = phone;
            DAL.Open();
            DataTable DT = new DataTable();
            DT = DAL.SelectData("add_customer", param);
            return DT;
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

        public DataTable get_table_status(int id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@id", SqlDbType.Int);
            param[0].Value = id;
            DAL.Open();

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("get_status", param);
            DAL.Colse();
            return Dt;
        }

        public DataTable get_table_order(int id)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@tableId", SqlDbType.Int);
            param[0].Value = id;
            DAL.Open();

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("get-table_order", param);
            DAL.Colse();
            return Dt;
        }

        public DataTable update_void_pass(string NewPass, int x)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@pass", SqlDbType.NVarChar, 50);
            param[0].Value = NewPass;
            param[1] = new SqlParameter("@id", SqlDbType.Int);
            param[1].Value = x;
            DAL.Open();

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("change_void_pass", param);
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
        public DataTable getCounter()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("get_counter", null);
            DAL.Colse();
            return Dt;
        }
        public DataTable updateCounter(int counter)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@count", SqlDbType.Int);
            param[0].Value = counter;
            DAL.Open();

            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("update_counter", param);
            DAL.Colse();
            return Dt;
        }
        public DataTable get_food_total_sales()
        {
            DataTable DT = new DataTable();

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DT = DAL.SelectData("get_food_sales", null);
            DAL.Colse();
            return DT;
        }
        public DataTable get_drinks_total_sales()
        {
            DataTable DT = new DataTable();

            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DT = DAL.SelectData("get_drinks_sales", null);
            DAL.Colse();
            return DT;
        }

        public DataTable get_all_sales(int order_type_id, int order_kind_id, DateTime from_date, DateTime to_date)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@order_type_id", SqlDbType.Int);
            param[0].Value = order_type_id;
            param[1] = new SqlParameter("@order_kind_id", SqlDbType.Int);
            param[1].Value = order_kind_id;
            param[2] = new SqlParameter("@from_date", SqlDbType.DateTime);
            param[2].Value = from_date;
            param[3] = new SqlParameter("@to_date", SqlDbType.DateTime);
            param[3].Value = to_date;
            DAL.Open();
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("get_all_sales", param);
            DAL.Colse();
            return Dt;
        }
    }
}
