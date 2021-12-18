using System;
using System.Collections;
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

namespace EnterpriseCourt.Screens.CashierRoles
{
    /// <summary>
    /// Interaction logic for Ordering.xaml
    /// </summary>
    public partial class Ordering : Window
    {
        PL.Actions actions = new PL.Actions();

        public Ordering()
        {
            InitializeComponent();
            InitializeUI();

        }
        private void InitializeUI()
        {
            DataTable dt = actions.getAllCategories();
            foreach (DataRow DR in dt.Rows)
            {
                Button button = new Button();
                button.Width = 190;
                button.Height = 30;
                button.Margin = new Thickness(10, 10, 10, 10);
                button.Content = DR["Name"].ToString();
                button.FontSize = 20;
                button.FontWeight = FontWeights.Medium;
                button.Click += new RoutedEventHandler(OnbClick);
                button.Name = "T" + DR["id"].ToString();
                CAt.Children.Add(button);

            }
        }
        private void OnbClick(object sender, RoutedEventArgs e)
        {
            Button bt = sender as Button;
            string btN = bt.Name;
            string id = "";
            for (int i = 1; i < btN.Length; i++)
            {
                id = id + btN[i];
            }
            NameOfCAt.Children.Clear();
            DataTable dt = actions.getAllItemsBasedOnCatId(Int32.Parse(id));
            List<Utils.Pair<string, string>> array = new List<Utils.Pair<string, string>>();

            foreach (DataRow DR in dt.Rows)
            {
                Utils.Pair<string, string> pair =
                    new Utils.Pair<string, string>(DR["Name"].ToString(), DR["id"].ToString());
                array.Add(pair);
            }
            for (int i = 0; i < array.Count - array.Count % 3; i += 3)
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;
                stackPanel.HorizontalAlignment = HorizontalAlignment.Left;
                stackPanel.VerticalAlignment = VerticalAlignment.Top;
                NameOfCAt.Children.Add(stackPanel);
                for (int j = 0; j < 3; j++)
                {
                    Button btn = new Button();
                    btn.Name = "T" + array.ElementAt(i + j).Second;
                    btn.Width = 200;
                    btn.Height = 70;
                    btn.Margin = new Thickness(10, 10, 10, 10);
                    btn.Content = array.ElementAt(i + j).First;
                    btn.FontSize = 15;
                    btn.FontWeight = FontWeights.Medium;
                    btn.Click += new RoutedEventHandler(OnbClick1);
                    stackPanel.Children.Add(btn);
                }
            }
            for (int i = 0; i < array.Count % 3; i += array.Count % 3)
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;
                stackPanel.HorizontalAlignment = HorizontalAlignment.Left;
                stackPanel.VerticalAlignment = VerticalAlignment.Top;
                NameOfCAt.Children.Add(stackPanel);
                for (int j = 0; j < array.Count % 3; j++)
                {
                    Button btn = new Button();
                    btn.Width = 200;
                    btn.Height = 70;
                    btn.FontSize = 15;
                    btn.FontWeight = FontWeights.Medium;
                    btn.Margin = new Thickness(10, 10, 10, 10);
                    btn.Click += new RoutedEventHandler(OnbClick1);
                    btn.Name = "T" + array.ElementAt(array.Count - array.Count % 3 + j).Second;
                    btn.Content = array.ElementAt(array.Count - array.Count % 3 + j).First;
                    stackPanel.Children.Add(btn);
                }
            }
        }
        public ArrayList foodOrder = new ArrayList();
        private void OnbClick1(object sender, RoutedEventArgs e)
        {
            Button bt = sender as Button;
            if (MessageBox.Show("هل تريد اضافة هذا العنصر", bt.Content.ToString(), MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
            {
            }
            else
            {
                //Yes 

                string id = "";

                for (int i = 1; i < bt.Name.ToString().Length; i++)
                {
                    id += bt.Name.ToString()[i];
                }
                foodOrder.Add(id);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (foodOrder.Count > 0)
            {




                if (helper.order_id == 1)
                {
                    DataTable DT = actions.get_table_status(helper.selectedTableId);

                    string status="";

                    foreach(DataRow DR in DT.Rows)
                    {
                        status = DR["status"].ToString();
                    }

                    MessageBox.Show(status);

                    if(status == "False")
                    {
                        DateTime dm = DateTime.Now;
                        int count = 0;

                        DataTable dt = actions.getCounter();

                        foreach (DataRow DR in dt.Rows)
                        {
                            count = Int32.Parse(DR["counter"].ToString());
                        }
                        DataTable order = actions.add_order(helper.order_id, count, dm);

                        actions.updateCounter(count + 1);
                        actions.update_table_status(helper.selectedTableId, true);

                        string order_id = "";

                        foreach (DataRow DR in order.Rows)
                        {
                            order_id = DR["id"].ToString();
                        }

                        for (int i = 0; i < foodOrder.Count; i++)
                        {
                            actions.add_item_to_order
                                (Int32.Parse(order_id), Int32.Parse(foodOrder[i].ToString()));
                        }
                        actions.add_order_to_table(Int32.Parse(order_id), helper.selectedTableId);
                        actions.insert_daily_order(Int32.Parse(order_id));

                        foodOrder.Clear();
                    }
                    else
                    {
                        DataTable order = actions.get_table_order(helper.selectedTableId);
                        string order_id = "";
                        foreach(DataRow DR in order.Rows)
                        {
                            order_id = DR["order_id"].ToString();
                        }
                        for (int i = 0; i < foodOrder.Count; i++)
                        {
                            actions.add_item_to_order
                                (Int32.Parse(order_id), Int32.Parse(foodOrder[i].ToString()));
                        }
                        MessageBox.Show(order_id);
                        foodOrder.Clear();

                    }

                }
                else
                {
                    MessageBox.Show(helper.order_id.ToString() + helper.selectedTableId.ToString());

                    int count = 0;

                    DataTable DT = actions.getCounter();

                    foreach (DataRow DR in DT.Rows)
                    {
                        count = Int32.Parse(DR["counter"].ToString());
                    }

                    DateTime dm = DateTime.Now;
                    DataTable order;


                    order = actions.add_order(helper.order_id, count, dm);



                    string order_id = "";

                    foreach (DataRow DR in order.Rows)
                    {
                        order_id = DR["id"].ToString();
                    }

                    for (int i = 0; i < foodOrder.Count; i++)
                    {
                        actions.add_item_to_order
                            (Int32.Parse(order_id), Int32.Parse(foodOrder[i].ToString()));
                    }

                    actions.insert_daily_order(Int32.Parse(order_id));



                    actions.updateCounter(count + 1);
                    foodOrder.Clear();


                }



            }
            else
            {
                MessageBox.Show("يجب اختيار بعض العناصر لطلب الاوردر");
            }
        }
    }
}
