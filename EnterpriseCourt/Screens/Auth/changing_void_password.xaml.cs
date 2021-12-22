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
    /// Interaction logic for changing_void_password.xaml
    /// </summary>
    public partial class changing_void_password : Window
    {
        PL.Actions actions = new PL.Actions();
        public changing_void_password()
        {
            InitializeComponent();
        }

        private void update_pass_btn(object sender, RoutedEventArgs e)
        {
            DataTable DT = actions.update_void_pass(np_txt.Password,1);
            MessageBox.Show("void password changed .");
        }
    }
}
