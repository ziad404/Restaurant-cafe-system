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

namespace EnterpriseCourt.Screens.CashierRoles
{
    /// <summary>
    /// Interaction logic for OrderType.xaml
    /// </summary>
    public partial class OrderType : Window
    {
        public OrderType()
        {
            InitializeComponent();
        }

        private void hall_btn_Click(object sender, RoutedEventArgs e)
        {
            Tables t = new Tables();
            t.Show();
        }

        private void takeaway_btn_Click(object sender, RoutedEventArgs e)
        {
            menu m = new menu();
         
            m.Show();
        }

        private void delivery_btn_Click(object sender, RoutedEventArgs e)
        {
            menu m = new menu();
          
            m.Show();
        }

        private void workers_meal_btn_Click(object sender, RoutedEventArgs e)
        {
            menu m = new menu();
       
            m.Show();
        }

        private void diafa_btn_Click(object sender, RoutedEventArgs e)
        {
            menu m = new menu();
         
            m.Show();
        }
    }
}
