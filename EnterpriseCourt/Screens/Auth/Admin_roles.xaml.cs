using EnterpriseCourt.Screens;
using EnterpriseCourt.Screens.Auth;
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


namespace EnterpriseCourt
{
    /// <summary>
    /// Interaction logic for Admin_roles.xaml
    /// </summary>
    public partial class Admin_roles : Window
    {
        public Admin_roles()
        {
            InitializeComponent();
        }

        private void addtable_btn_Click(object sender, RoutedEventArgs e)
        {
            adding_table ad = new adding_table();
            ad.Show();
        }

        private void adduser_btn_Click(object sender, RoutedEventArgs e)
        {
            AddingUser addingUser = new AddingUser();
            addingUser.Show();
        }

        private void addcat_btn_Click(object sender, RoutedEventArgs e)
        {
            adding_category addcat = new adding_category();
            addcat.Show();
        }

        

        private void update_pass_btn(object sender, RoutedEventArgs e)
        {
            Update_admin_pass up = new Update_admin_pass();
            up.Show();
        }

        private void additem_btn_Click(object sender, RoutedEventArgs e)
        {
            adding_item ai = new adding_item();
            ai.Show();
        }

        private void addtable_btn_Copy_Click(object sender, RoutedEventArgs e)
        {
            edit_item ei = new edit_item();
            ei.Show();
        }

        private void cash_btn(object sender, RoutedEventArgs e)
        {
            Screens.CashierRoles.OrderType ot = new Screens.CashierRoles.OrderType();
            this.Hide();
            ot.Show();
        }
    }
}
