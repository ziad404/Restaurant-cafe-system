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

namespace EnterpriseCourt.Screens.Components
{
    /// <summary>
    /// Interaction logic for Optional_question.xaml
    /// </summary>
    public partial class Optional_question : Window
    {
        public Optional_question()
        {
            InitializeComponent();
        }

        private void cancel_btn(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CashierRoles.Ordering o = new CashierRoles.Ordering();
            o.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();
            CashierRoles.TableOrders tableOrders = new CashierRoles.TableOrders();
            tableOrders.Show();
        }
    }
}
