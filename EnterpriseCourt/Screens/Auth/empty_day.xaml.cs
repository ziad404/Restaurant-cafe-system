using System;
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

namespace EnterpriseCourt.Screens.Auth
{
    /// <summary>
    /// Interaction logic for empty_day.xaml
    /// </summary>
    public partial class empty_day : Window
    {
        PL.Actions actions = new PL.Actions();
        List<items> t = new List<items>();
        float total_price = 0;
        public empty_day()
        {
            InitializeComponent();
            
            InitializeComboBox();
        }
        public void InitializeComboBox()
        {
            try
            {
                System.Data.DataTable dt = actions.getAllorderstypes();
               
                foreach (DataRow DR in dt.Rows)
                {


                    Utils.ComboBoxPairItem comboBoxPairItem1 = new Utils.ComboBoxPairItem();

                    comboBoxPairItem1.Text = DR["name"].ToString();
                    comboBoxPairItem1.Value = DR["id"].ToString();


                    filter_sales.Items.Add(comboBoxPairItem1);
                }
                total.Content = total_price;
            }
            catch (Exception ex)
            {
            }
        }

        class items
        {

            public string name { get; set; }
            public string number_of_items { get; set; }
            public string price { get; set; }
            public string total_price { get; set; }
        }

        private void filter_sales_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            System.Data.DataTable DT = actions.get_daily_sales(Int32.Parse
                          ((filter_sales.SelectedItem as
                          Utils.ComboBoxPairItem).Value.ToString()));
                t.Clear();
                total_price = 0;
            foreach (DataRow DR in DT.Rows)
            {
                t.Add(new items
                {
                    name = DR["name"].ToString(),
                    number_of_items = DR["items_number"].ToString(),
                    price = DR["itemPrice"].ToString(),
                    total_price = DR["total_price"].ToString()

                });
                total_price += float.Parse(DR["total_price"].ToString());
            }
            sales_grid.ItemsSource = t;
            sales_grid.Items.Refresh();
            total.Content = total_price;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = actions.empty_day();
            t.Clear();
            total_price = 0;
            sales_grid.Items.Refresh();
            total.Content = total_price;
            MessageBox.Show("end of day !");

        }
    }
}
