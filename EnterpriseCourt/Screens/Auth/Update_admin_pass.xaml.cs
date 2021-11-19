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
    /// Interaction logic for Update_admin_pass.xaml
    /// </summary>
    public partial class Update_admin_pass : Window
    {
        PL.Actions actions = new PL.Actions();
        int x = helper.ID;
        public Update_admin_pass()
        {
            InitializeComponent();
        }

        private void update_pass_btn(object sender, RoutedEventArgs e)
        { if (old_pass_txt.Text != "" && new_pass_txt.Text != "")
            {
                if (old_pass_txt.Text == helper.password)
                {
                    DataTable DT = actions.Update_admin_pass(new_pass_txt.Text, x);
                    MessageBox.Show("Password changed successfully");
                }
                else
                {
                    MessageBox.Show("old password and new password not matched");
                }
            }
            else
            {
                MessageBox.Show("Please fill all labels");
            }

        }

        
    }
}
