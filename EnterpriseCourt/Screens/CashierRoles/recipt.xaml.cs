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
        public recipt(int id)
        {
          //  ImageViewer1.Source = new (new Uri("court.jpg", UriKind.Relative));
            InitializeComponent();
            System.Data.DataTable DT = actions.get_all_items_from_order(id);
            float total = 0;
            foreach (DataRow DR in DT.Rows)
            {
                t.Add(new items
                {
                    name = DR["ItemName"].ToString(),
                    number_of_items = DR["items_number"].ToString(),
                    price = DR["itemPrice"].ToString()
                  


                } );
                float total_of_item = Int32.Parse(DR["items_number"].ToString()) * Int32.Parse(DR["itemPrice"].ToString());
                total += total_of_item;
            }
            dg.ItemsSource = t;
            DateTime dm = DateTime.Now;
            time.Content = dm;
            serial.Content = id;
            DataTable dt = actions.get_order_number(id);
            int cntr = 0;
            foreach(DataRow dr in dt.Rows)
            {
                cntr = Int32.Parse(dr["order_number"].ToString());
            }

            counter.Content = cntr;
            cashier.Content = Utils.helper_user.cashiername;
            totalpr.Content = total.ToString() + " L.E";
            PrintDialog printDlg = new PrintDialog();
            printDlg.PrintVisual(reciept_pnl, "Window Printing.");
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }

        

        private void Window_Activated_1(object sender, EventArgs e)
        {
            

        }
    }
}
