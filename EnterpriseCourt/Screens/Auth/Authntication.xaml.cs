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
using System.Data;

namespace EnterpriseCourt.Screens.Auth
{
    /// <summary>
    /// Interaction logic for Authntication.xaml
    /// </summary>
    public partial class Authntication : Window
    {
        PL.Actions actions = new PL.Actions();
        public Authntication()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            DataTable DT = actions.Login(userName_txt.Text, password_txt.Password);
            if (DT.Rows.Count > 0)
            {
                MessageBox.Show("zpy kosmak sh8alah");
            }
            else
            {
                MessageBox.Show("Login Failed");
            }
        }
    }
}
