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
    /// Interaction logic for edit_item.xaml
    /// </summary>
    public partial class edit_item : Window
    {
        PL.Actions actions = new PL.Actions();
        public edit_item()
        {
            InitializeComponent();
            InitializeComboBox();
        }
        private void type_menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                
                    DataTable dt = actions.getAllItemsBasedOnCatId(
                    Int32.Parse((type_menu.SelectedItem as Utils.ComboBoxPairItem).Value.ToString())
                );
                    item_menu.Items.Clear();
                    foreach (DataRow DR in dt.Rows)
                    {
                        Utils.ComboBoxPairItem comboBoxPairItem = new Utils.ComboBoxPairItem();
                        comboBoxPairItem.Text = DR["Name"].ToString();
                        comboBoxPairItem.Value = DR["id"].ToString();
                        item_menu.Items.Add(comboBoxPairItem);
                    }
                
            }
            catch (Exception ex)
            {
            }
        }
        public void InitializeComboBox()
        {
            try
            {
                DataTable dt = actions.getAllCategories();
                foreach (DataRow DR in dt.Rows)
                {
                    Utils.ComboBoxPairItem comboBoxPairItem = new Utils.ComboBoxPairItem();
                    comboBoxPairItem.Text = DR["Name"].ToString();
                    comboBoxPairItem.Value = DR["id"].ToString();
                    type_menu.Items.Add(comboBoxPairItem);
                }

            }
            catch (Exception ex)
            {
            }
        }

        private void delete_item_btn(object sender, RoutedEventArgs e)
        {
            try
            {

                DataTable dt = actions.delete_item(Int32.Parse((item_menu.SelectedItem as Utils.ComboBoxPairItem).Value.ToString()));

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("deleted");
                }


            }
            catch (Exception)
            {
                MessageBox.Show("تم استخدام هذا العنصر في طلب من قبل لا يجب مسحة");
            }


        }



        private void edit(object sender, RoutedEventArgs e)
        {


            DataTable dt = actions.Update_item_price(float.Parse(edit_price_txt.Text),
                    Int32.Parse((item_menu.SelectedItem as Utils.ComboBoxPairItem).Value.ToString())
                );
            MessageBox.Show("Edited");


        }

        private void item_menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (item_menu.SelectedItem != null)
            {

                DataTable dt1 = actions.get_item_price(
                        Int32.Parse((item_menu.SelectedItem as Utils.ComboBoxPairItem).Value.ToString())
                );

                foreach (DataRow DR in dt1.Rows)
                {
                    edit_price_txt.Text = DR["price"].ToString();
                }
            }

            

        }
    }
}
