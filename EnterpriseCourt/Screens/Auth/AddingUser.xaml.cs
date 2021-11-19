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

namespace EnterpriseCourt.Screens.Auth
{
    /// <summary>
    /// Interaction logic for AddingUser.xaml
    /// </summary>
    public partial class AddingUser : Window
    {
        PL.Actions actions = new PL.Actions();
            string role = "";
        public AddingUser()
        {
            InitializeComponent();
        }

        private void submit_btn_Click(object sender, RoutedEventArgs e)
        {
            
             if (admin_box.IsChecked == true && cashier_box.IsChecked == false)
            {
                role = "Admin";
                
            }
            if (admin_box.IsChecked == false && cashier_box.IsChecked == true)
            {
                role = "Cashier";
               

            }
            if (admin_box.IsChecked == false && cashier_box.IsChecked == false)
            {
                //role = "Cashier";
                cashier_box.IsChecked = false;
                admin_box.IsChecked = false;
                MessageBox.Show("please select  mostly one role  ");

            }


            DataTable DT = actions.Add_User(name_txt.Text, pass_txt.Password,role);
            MessageBox.Show("new user added");
            
            
        }

        private void admin_box_Checked(object sender, RoutedEventArgs e)
        {
            if(admin_box.IsChecked == true)
            {
                cashier_box.IsChecked = false;
            }
        }

        private void cashier_box_Checked(object sender, RoutedEventArgs e)
        {
            if (cashier_box.IsChecked == true)
            {
                admin_box.IsChecked = false;
            }
        }
    }
}
