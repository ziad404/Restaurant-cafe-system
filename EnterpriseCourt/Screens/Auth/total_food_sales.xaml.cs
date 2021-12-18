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
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using Window = Microsoft.Office.Interop.Excel.Window;
using GemBox.Spreadsheet;

namespace EnterpriseCourt.Screens.Auth
{
    /// <summary>s
    /// Interaction logic for total_food_sales.xaml
    /// </summary>
    public partial class total_food_sales : System.Windows.Window
    {
        PL.Actions actions = new PL.Actions();
        List<items> t = new List<items>();
        float total_price = 0;
        bool changed = false;

        public total_food_sales()
        {
            InitializeComponent();
            System.Data.DataTable DT = actions.get_food_total_sales();
            foreach (DataRow DR in DT.Rows)
            {
                t.Add(new items
                {
                    name = DR["name"].ToString(),
                    number_of_items = DR["items_number"].ToString(),
                    price=DR["itemPrice"].ToString(),
                    total_price=DR["total_price"].ToString()

                });
                total_price += float.Parse(DR["total_price"].ToString());
            }
            food_sales_grid.ItemsSource = t;
            InitializeComboBox();
        }
        public void InitializeComboBox()
        {
            try
            {
                System.Data.DataTable dt = actions.getAllorderstypes();
                Utils.ComboBoxPairItem comboBoxPairItem = new Utils.ComboBoxPairItem();
                comboBoxPairItem.Text = "المبيع الكلي";
                comboBoxPairItem.Value = "-1";
                filter_food.Items.Add(comboBoxPairItem);
                foreach (DataRow DR in dt.Rows)
                {


                    Utils.ComboBoxPairItem comboBoxPairItem1 = new Utils.ComboBoxPairItem();

                    comboBoxPairItem1.Text = DR["name"].ToString();
                    comboBoxPairItem1.Value = DR["id"].ToString();


                    filter_food.Items.Add(comboBoxPairItem1);
                }
                total.Content = total_price;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        class items
        {
            
            public string name { get; set; }
            public string number_of_items { get; set; }
            public string price { get; set; }
            public string total_price { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            System.Data.DataTable DT;

            if (changed == true)
            {
                DT = actions.get_food_sales_based_on_order_type(Int32.Parse
                          ((filter_food.SelectedItem as
                          Utils.ComboBoxPairItem).Value.ToString()));
            }
            else
            {
                DT = actions.get_food_total_sales();
            }

            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            var workbook = new ExcelFile();
            var worksheet = workbook.Worksheets.Add("Ma2kolat");


            worksheet.InsertDataTable(DT,
            new InsertDataTableOptions()
            {
                ColumnHeaders = true,
                StartRow = 1
            });

            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string[] user = userName.Split("\\");


            MessageBox.Show(user[1]);

            workbook.Save("C:\\Users\\" + user[1] + "\\Desktop\\Ma2kolat.xlsx");
        }

        private void filter_food_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (
                Int32.Parse
                      ((filter_food.SelectedItem as
                      Utils.ComboBoxPairItem).Value.ToString()) == -1
                      )
            {
                changed = false;
                System.Data.DataTable dt = actions.get_food_total_sales();
                t.Clear();
                total_price = 0;
                foreach (DataRow DR in dt.Rows)
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
                food_sales_grid.ItemsSource = t;
                food_sales_grid.Items.Refresh();
                total.Content = total_price;
            }
            else
            {
                changed = true;

                System.Data.DataTable dt = actions.get_food_sales_based_on_order_type(
                          Int32.Parse
                          ((filter_food.SelectedItem as
                          Utils.ComboBoxPairItem).Value.ToString())
                    );
                t.Clear();
                total_price = 0;
                foreach (DataRow DR in dt.Rows)
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
                food_sales_grid.ItemsSource = t;
                food_sales_grid.Items.Refresh();
                total.Content = total_price;
            }

        }
    }
}
