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
    /// Interaction logic for voiding_reciept.xaml
    /// </summary>
    public partial class voiding_reciept : Window
    {
        PL.Actions actions = new PL.Actions();
        public voiding_reciept()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           DataTable DT= actions.delete_by_serial(int.Parse(serial_txt.Text));
            MessageBox.Show("Order deleted successfully");
        }
    }
}
