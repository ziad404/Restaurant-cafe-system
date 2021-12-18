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
            MessageBox.Show("تم طلب الاوردر بنجاح");
        }
    }
}
