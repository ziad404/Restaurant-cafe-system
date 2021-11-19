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

namespace EnterpriseCourt.Screens
{
    /// <summary>
    /// Interaction logic for adding_category.xaml
    /// </summary>
    public partial class adding_category : Window
    {
        PL.Actions actions = new PL.Actions();
        public adding_category()
        {
            InitializeComponent();
        }

        private void add_cat(object sender, RoutedEventArgs e)
        {
            DataTable DT = actions.add_category(cat_name_txt.Text);
            MessageBox.Show(" New category added successfully");
        }

       
    }
}
