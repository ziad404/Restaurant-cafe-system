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

namespace EnterpriseCourt.Screens.CashierRoles
{
    /// <summary>
    /// Interaction logic for recipt.xaml
    /// </summary>
    public partial class recipt : Window
    {
        public int order_id;
        PL.Actions actions = new PL.Actions();
        List<items> t = new List<items>();
        class items
        {

            public string name { get; set; }
            public string number_of_items { get; set; }
            public string price { get; set; }

        }
        public recipt(int id, int type)
        {
            //  ImageViewer1.Source = new (new Uri("court.jpg", UriKind.Relative));



            InitializeComponent();


            if (id == -1 && type == -1)
            {
                adr_pnl.Visibility = Visibility.Hidden;
                info_pnl.Visibility = Visibility.Hidden;
                name_pnl.Visibility = Visibility.Hidden;
                num_pnl.Visibility = Visibility.Hidden;
                mm.Visibility = Visibility.Hidden;
                xx.Visibility = Visibility.Hidden;
                total_pnl.Visibility = Visibility.Hidden;
                reciept_num.Visibility = Visibility.Hidden;
                cashier.Content = Utils.helper_user.cashiername;
                table_num.Content = helper.selectedTableNum;

                foreach(DataRow DR in helper.dt.Rows)
                {
                    t.Add(new items
                    {
                        name = DR["ItemName"].ToString(),
                        number_of_items = DR["items_number"].ToString(),
                        price = DR["itemPrice"].ToString()

                    });
                }
                dg.ItemsSource = t;
                DateTime dm = DateTime.Now;
                time.Content = dm;

                PrintDialog printDlg = new PrintDialog();
                printDlg.PrintVisual(reciept_pnl, "Window Printing.");
                printDlg.PrintVisual(reciept_pnl, "Window Printing.");


            }
            else
            {
                System.Data.DataTable DT = actions.get_all_items_from_order(id);
                float total = 0;
                foreach (DataRow DR in DT.Rows)
                {
                    t.Add(new items
                    {
                        name = DR["ItemName"].ToString(),
                        number_of_items = DR["items_number"].ToString(),
                        price = DR["itemPrice"].ToString()

                    });
                    float total_of_item = Int32.Parse(DR["items_number"].ToString()) * Int32.Parse(DR["itemPrice"].ToString());
                    total += total_of_item;
                }
                dg.ItemsSource = t;
                DateTime dm = DateTime.Now;
                time.Content = dm;
                serial.Content = id;
                table_num.Content = helper.selectedTableNum;
                DataTable dt = actions.get_order_number(id);
                int cntr = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    cntr = Int32.Parse(dr["order_number"].ToString());
                }

                counter.Content = cntr;
                cashier.Content = Utils.helper_user.cashiername;
                totalpr.Content = total.ToString() + " L.E";

                PrintDialog printDlg = new PrintDialog();
                if (type == 2)
                {
                    table_pnl.Visibility = Visibility.Hidden;
                    name.Content = helper.customerName;
                    info.Content = helper.customerInfo;
                    number.Content = helper.customerNum;
                    adr.Content = helper.customerAdr;
                    printDlg.PrintVisual(reciept_pnl, "Window Printing.");
                    printDlg.PrintVisual(reciept_pnl, "Window Printing.");
                    printDlg.PrintVisual(reciept_pnl, "Window Printing.");
                }
                else if (type == 3)
                {
                    adr_pnl.Visibility = Visibility.Hidden;

                    table_num.Visibility = Visibility.Hidden;
                    lbl_name.Content = "تيك اواي ";
                    name.Content = helper.customerName;
                    info.Content = helper.customerInfo;
                    number.Content = helper.customerNum;
                    printDlg.PrintVisual(reciept_pnl, "Window Printing.");
                    printDlg.PrintVisual(reciept_pnl, "Window Printing.");
                    // printDlg.PrintVisual(reciept_pnl, "Window Printing.");

                }
                else if (type == 4)
                {
                    adr_pnl.Visibility = Visibility.Hidden;
                    num_pnl.Visibility = Visibility.Hidden;
                    table_pnl.Visibility = Visibility.Hidden;
                    info_pnl.Visibility = Visibility.Hidden;
                    name.Content = helper.customerName;
                    printDlg.PrintVisual(reciept_pnl, "Window Printing.");
                    printDlg.PrintVisual(reciept_pnl, "Window Printing.");


                }
                else if (type == 5)
                {
                    adr_pnl.Visibility = Visibility.Hidden;
                    num_pnl.Visibility = Visibility.Hidden;
                    table_pnl.Visibility = Visibility.Hidden;
                    name.Content = helper.customerName = "الحاج علام";
                    printDlg.PrintVisual(reciept_pnl, "Window Printing.");
                    printDlg.PrintVisual(reciept_pnl, "Window Printing.");


                }
                else if (type == 1)
                {

                    adr_pnl.Visibility = Visibility.Hidden;
                    num_pnl.Visibility = Visibility.Hidden;
                    name_pnl.Visibility = Visibility.Hidden;
                    info_pnl.Visibility = Visibility.Hidden;
                    xx.Visibility = Visibility.Hidden;
                    mm.Visibility = Visibility.Hidden;
                    
                    printDlg.PrintVisual(reciept_pnl, "Window Printing.");
                    printDlg.PrintVisual(reciept_pnl, "Window Printing.");
                }


                //  printDlg.PrintVisual(reciept_pnl, "Window Printing.");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }



        private void Window_Activated_1(object sender, EventArgs e)
        {


        }
    }
}
