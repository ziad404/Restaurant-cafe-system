using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EnterpriseCourt.Screens.CashierRoles
{
    /// <summary>
    /// Interaction logic for moving_table.xaml
    /// </summary>
    public partial class moving_table : Window
    {
        PL.Actions actions = new PL.Actions();
        public moving_table()
        {
            InitializeComponent();
            intializeCompobox();

        }
        public void intializeCompobox()
        {
            try
            {
                System.Data.DataTable dt = actions.getAllTables();
                foreach (DataRow DR in dt.Rows)
                {

                    Utils.ComboBoxPairItem comboBoxPairItem = new Utils.ComboBoxPairItem();
                    comboBoxPairItem.Text = DR["name"].ToString();
                    Utils.ComboBoxPairItem comboBoxPairItem1 = comboBoxPairItem;
                    comboBoxPairItem1.Value = DR["id"].ToString();


                    from_box.Items.Add(comboBoxPairItem);
                    to_box.Items.Add(comboBoxPairItem);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = actions.get_orders_on_spacific_table
                (Int32.Parse((from_box.SelectedItem as
                Utils.ComboBoxPairItem).Value.ToString()));

            List<Utils.Pair<string, string>> array = new List<Utils.Pair<string, string>>();


            string order_id = "";

            foreach (DataRow DR in dt.Rows)
            {
                Utils.Pair<string, string> pair =
                    new Utils.Pair<string, string>(DR["item_id"].ToString(), DR["items_number"].ToString());
                array.Add(pair);
                order_id = DR["orderId"].ToString();
            }

            foreach (DataRow DR in dt.Rows)
            {
                actions.delete_one_item_from_order
                    (Int32.Parse(order_id), Int32.Parse(DR["item_id"].ToString()));

            }

            actions.delete_order_table(Int32.Parse(order_id));
            actions.update_table_status(Int32.Parse((from_box.SelectedItem as
                Utils.ComboBoxPairItem).Value.ToString()), false);



            DataTable DT = actions.get_table_status(
                Int32.Parse((to_box.SelectedItem as
                Utils.ComboBoxPairItem).Value.ToString()));

            string status = "";

            foreach (DataRow DR in DT.Rows)
            {
                status = DR["status"].ToString();
            }


            if (status == "False")
            {
                DateTime dm = DateTime.Now;
                
                DataTable order = actions.add_order(1, -1, dm);

                actions.update_table_status(
                    Int32.Parse((to_box.SelectedItem as
                Utils.ComboBoxPairItem).Value.ToString()), true);

                string new_order_id = "";

                foreach (DataRow DR in order.Rows)
                {
                    new_order_id = DR["id"].ToString();
                }


                for (int i = 0; i < array.Count; i++)
                {
                    for (int j = 0; j < Int32.Parse(array[i].Second); j++)
                    {
                        

                        actions.add_item_to_order
                            (Int32.Parse(new_order_id), Int32.Parse(array[i].First.ToString()));
                    }
                }
                actions.delete_from_daily_sales(Int32.Parse(order_id));
                actions.insert_daily_order(Int32.Parse(new_order_id));

                actions.add_order_to_table(Int32.Parse(new_order_id),
                    Int32.Parse((to_box.SelectedItem as
                    Utils.ComboBoxPairItem).Value.ToString()));

                MessageBox.Show("تم النقل .");
            }
            else
            {
                DataTable order = actions.get_table_order(
                    Int32.Parse((to_box.SelectedItem as
                    Utils.ComboBoxPairItem).Value.ToString()));
                string new_order_id = "";
                foreach (DataRow DR in order.Rows)
                {
                    new_order_id = DR["order_id"].ToString();
                }
                for (int i = 0; i < array.Count; i++)
                {
                    for (int j = 0; j < Int32.Parse(array[i].Second); j++)
                    {


                        actions.add_item_to_order
                            (Int32.Parse(new_order_id), Int32.Parse(array[i].First.ToString()));
                    }
                }

                // MessageBox.Show(new_order_id);
                MessageBox.Show("تم النقل ");

            }

        }
    }
}
