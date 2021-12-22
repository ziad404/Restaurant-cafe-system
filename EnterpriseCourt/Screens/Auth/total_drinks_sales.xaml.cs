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
using Microsoft.Office.Interop.Excel;
using Window = Microsoft.Office.Interop.Excel.Window;
using GemBox.Spreadsheet;
using System.IO;

namespace EnterpriseCourt.Screens.Auth
{
    /// <summary>
    /// Interaction logic for total_drinks_sales.xaml
    /// </summary>
    public partial class total_drinks_sales : System.Windows.Window
    {
        PL.Actions actions = new PL.Actions();
        List<items> t = new List<items>();
        float total_price = 0;
        bool changed = false;

        public total_drinks_sales()
        {
            InitializeComponent();
            System.Data.DataTable DT = actions.get_drinks_total_sales();
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
            drinks_sales_grid.ItemsSource = t;
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
                filter_drinks.Items.Add(comboBoxPairItem);

                foreach (DataRow DR in dt.Rows)
                {
                    Utils.ComboBoxPairItem comboBoxPairItem1 = new Utils.ComboBoxPairItem();

                    comboBoxPairItem1.Text = DR["name"].ToString();
                    comboBoxPairItem1.Value = DR["id"].ToString();

                    filter_drinks.Items.Add(comboBoxPairItem1);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Data.DataTable DT;

            if(changed == true)
            {
                DT = actions.get_drinks_sales_based_on_order_type(Int32.Parse
                          ((filter_drinks.SelectedItem as
                          Utils.ComboBoxPairItem).Value.ToString()));
            }
            else
            {
                DT = actions.get_drinks_total_sales();
            }


            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            var workbook = new ExcelFile();
            var worksheet = workbook.Worksheets.Add("Mashareep");


            worksheet.InsertDataTable(DT,
            new InsertDataTableOptions()
            {
                ColumnHeaders = true,
                StartRow = 1
            });

            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            string[] user = userName.Split("\\");

            //MessageBox.Show(userName);


            workbook.Save("C:\\Users\\" + user[1] + "\\Desktop\\Mashareep.xlsx");




        }

        private void filter_drinks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (
                Int32.Parse
                      ((filter_drinks.SelectedItem as
                      Utils.ComboBoxPairItem).Value.ToString()) == -1
                      )
            {
                changed = false;
                System.Data.DataTable dt = actions.get_drinks_total_sales();
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
                drinks_sales_grid.ItemsSource = t;
                drinks_sales_grid.Items.Refresh();
                total.Content = total_price;
            }
            else
            {
                changed = true;

                System.Data.DataTable dt = actions.get_drinks_sales_based_on_order_type(
                          Int32.Parse
                          ((filter_drinks.SelectedItem as
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
                drinks_sales_grid.ItemsSource = t;
                drinks_sales_grid.Items.Refresh();
                total.Content = total_price;
            }

        }
    }
}
