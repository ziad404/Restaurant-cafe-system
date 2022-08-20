using System;
using System.Collections.Generic;
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
    /// Interaction logic for Supervisor_roles.xaml
    /// </summary>
    public partial class Supervisor_roles : Window
    {
        public Supervisor_roles()
        {
            InitializeComponent();
        }

        private void inventory_btn_Click(object sender, RoutedEventArgs e)
        {
            empty_day ee = new empty_day();
            ee.Show();
        }

        private void cash_btn_Click(object sender, RoutedEventArgs e)
        {
            Screens.CashierRoles.OrderType ot = new Screens.CashierRoles.OrderType();
            // this.Hide();
            ot.Show();
        }
    }
}
