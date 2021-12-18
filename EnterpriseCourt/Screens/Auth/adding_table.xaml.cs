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
    /// Interaction logic for adding_table.xaml
    /// </summary>
    public partial class adding_table : Window
    {
        PL.Actions actions = new PL.Actions();
        bool st = false;
        public adding_table()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void add_table(object sender, RoutedEventArgs e)
        {
            DataTable DT = actions.add_table(tbl_name_txt.Text,st );
            MessageBox.Show("table added successfully");
        }
    }
}
