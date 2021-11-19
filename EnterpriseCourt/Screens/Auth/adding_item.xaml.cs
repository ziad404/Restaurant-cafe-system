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
    /// Interaction logic for adding_item.xaml
    /// </summary>
    public partial class adding_item : Window
    {
        PL.Actions actions = new PL.Actions();
        public adding_item()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        public void InitializeComboBox()
        {
            try
            {
                DataTable dt = actions.getAllCategories();
                foreach(DataRow DR in dt.Rows)
                {
                    type_menu.Items.Add(DR["Name"].ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
