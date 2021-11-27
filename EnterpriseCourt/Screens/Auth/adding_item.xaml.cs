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

                    Utils.ComboBoxPairItem comboBoxPairItem = new Utils.ComboBoxPairItem();
                    comboBoxPairItem.Text = DR["Name"].ToString();
                    comboBoxPairItem.Value = DR["id"].ToString();

                    type_menu.Items.Add(comboBoxPairItem);

                }

                DataTable dtTypes = actions.getAllTypes();
                foreach (DataRow DR in dtTypes.Rows)
                {

                    Utils.ComboBoxPairItem comboBoxPairItem = new Utils.ComboBoxPairItem();
                    comboBoxPairItem.Text = DR["type"].ToString();
                    comboBoxPairItem.Value = DR["id"].ToString();

                    type_order.Items.Add(comboBoxPairItem);

                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void add_item(object sender, RoutedEventArgs e)
        {
            //(type_menu.SelectedItem as Utils.ComboBoxPairItem).Value());
            DataTable DT = actions.add_item(
                item_name_txt.Text,
                float.Parse(price_txt.Text),
                Int32.Parse((type_menu.SelectedItem as Utils.ComboBoxPairItem).Value.ToString()),
                Int32.Parse((type_order.SelectedItem as Utils.ComboBoxPairItem).Value.ToString())
                );
            MessageBox.Show("new item added successfully");
            
        }
    }
}
