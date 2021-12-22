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
using GemBox.Spreadsheet;

namespace EnterpriseCourt.Screens.Auth
{
    /// <summary>
    /// Interaction logic for empty.xaml
    /// </summary>
    public partial class empty : Window
    {
        PL.Actions actions = new PL.Actions();
        List<items> t = new List<items>();
        System.Data.DataTable dt1 = new DataTable();
        class items
        {

            public string name { get; set; }
            public string number_of_items { get; set; }
            public string price { get; set; }
            public string total_price { get; set; }
        }
        public empty()
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

                    filter_orders.Items.Add(comboBoxPairItem1);
                }
                DataTable dtTypes = actions.getAllTypes();
                foreach (DataRow DR in dtTypes.Rows)
                {

                    Utils.ComboBoxPairItem comboBoxPairItem = new Utils.ComboBoxPairItem();
                    comboBoxPairItem.Text = DR["type"].ToString();
                    comboBoxPairItem.Value = DR["id"].ToString();

                    type_order.Items.Add(comboBoxPairItem);
                   
                }
                
            }
            catch (Exception ex)
            {
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            float total_price = 0;
            try {
                string simpleTime = "1/1/2000";
                DateTime DT_TO = DateTime.Parse(simpleTime);
                DateTime DT_FROM = DateTime.Parse(simpleTime);

                string To = date_to.SelectedDate.Value.ToString("MM/dd/yyyy");
                string From = from_date.SelectedDate.Value.ToString("MM/dd/yyyy");

                string hourTo = hour_to.Text.ToString();
                string minTo = min_to.Text.ToString();

                ComboBoxItem typeItem = (ComboBoxItem)AP_to.SelectedItem;


                string APTo = typeItem.Content.ToString();

                string hourFrom = hour_from.Text.ToString();
                string minFrom = min_from.Text.ToString();


                ComboBoxItem typeItem1 = (ComboBoxItem)AP_from.SelectedItem;


                string APFrom = typeItem1.Content.ToString();



                string timeTo = hourTo + ":" + minTo + " " + APTo;
                string timeFrom = hourFrom + ":" + minFrom + " " + APFrom;



                string d1 = To + " " + timeTo;
                string d2 = From + " " + timeFrom;

                DT_TO = DateTime.Parse(d1);
                DT_FROM = DateTime.Parse(d2);


                int result = DateTime.Compare(DT_TO, DT_FROM);

                if (result < 0)
                    MessageBox.Show("يجب اختيار تاريخ من اصغر من تاريخ الي ");
                else if (result == 0)
                    MessageBox.Show("يجب اختيار تاريخ من اصغر من تاريخ الي ");
                else
                {
                   dt1 = actions.get_all_sales(Int32.Parse((filter_orders.SelectedItem as Utils.ComboBoxPairItem).Value.ToString()),
                        Int32.Parse((type_order.SelectedItem as Utils.ComboBoxPairItem).Value.ToString())
                        , DT_FROM, DT_TO);
                    t.Clear();
                    foreach (DataRow DR in dt1.Rows)
                    {
                        t.Add(new items
                        {
                            name = DR["name"].ToString(),
                            number_of_items = DR["items_number"].ToString(),
                            price = DR["itemPrice"].ToString(),
                            total_price = DR["total_price"].ToString()
                        });
                        
                        total_price += float.Parse(DR["total_price"].ToString()) ;
                    }
                    drinks_sales_grid.ItemsSource = t;
                    total_lbl.Content = total_price.ToString();

                    drinks_sales_grid.Items.Refresh();

                    // MessageBox.Show(dt1.Rows.Count.ToString());
                }



            }
            catch(Exception ex)
            {
                MessageBox.Show("Error while filling data");
            }
            }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            if(dt1.Rows.Count == 0)
            {
                MessageBox.Show("يجب ان يكون الخانات ملئ بالبيانات");
            }
            else
            {
                SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

                var workbook = new ExcelFile();
                var worksheet = workbook.Worksheets.Add("Mashareep");

                worksheet.InsertDataTable(dt1,
                new InsertDataTableOptions()
                {
                    ColumnHeaders = true,
                    StartRow = 1
                });

                string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                string[] user = userName.Split("\\");

                //MessageBox.Show(userName);


                workbook.Save("C:\\Users\\" + user[1] + "\\Desktop\\Sales.xlsx");
            }
            MessageBox.Show("exported to desktop"); 

        }
    }
}
