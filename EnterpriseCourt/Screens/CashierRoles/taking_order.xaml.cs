using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EnterpriseCourt.Screens.CashierRoles
{


    /// <summary>
    /// Interaction logic for taking_order.xaml
    /// </summary>
    public partial class taking_order : Window
    {

        //Utils.customer c = Utils.customer();
        PL.Actions actions = new PL.Actions();
        public taking_order()
        {
            InitializeComponent();
        }


        private void submit_order_btn_Click(object sender, RoutedEventArgs e)
        {
            DataTable DT = actions.add_customer(customer_name_txt.Text,customer_number_txt.Text);
            
            
            helper.customerName = customer_name_txt.Text;
            helper.customerNum = customer_number_txt.Text;
            helper.customerAdr = customer_address_txt.Text;
            helper.customerInfo = order_comment_txt.Text;
            helper.if_cancel = false;
            this.Close();

        }

        private void cancel_order_btn(object sender, RoutedEventArgs e)
        {
            helper.if_cancel = true;
            this.Close();   
        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }
    }
}
