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
    /// Interaction logic for voiding_item.xaml
    /// </summary>
    public partial class voiding_item : Window
    {
        PL.Actions actions = new PL.Actions();
        string order_id = "";
        string itemId = "";
        public voiding_item(string i_id,string o_id)
        {
            InitializeComponent();
             order_id=o_id;
             itemId=i_id;
        }

        private void delete_one_item(object sender, RoutedEventArgs e)
        {
           DataTable DT= actions.delete_one_item(Int32.Parse(p_txt.Password));
            if (DT.Rows.Count > 0)
            {
                actions.delete_one_item_from_order(Int32.Parse(order_id), Int32.Parse(itemId));

                DataTable dt = actions.get_orders_on_spacific_table(helper.selectedTableId);

                int count = dt.Rows.Count;
                if (count == 0)
                {
                    actions.update_table_status(helper.selectedTableId, false);
                }
                MessageBox.Show("deleted");
                p_txt.Password = "";
            }
            else
            {
                MessageBox.Show("password does not matched . ");
            }

               

        }
    }
}
