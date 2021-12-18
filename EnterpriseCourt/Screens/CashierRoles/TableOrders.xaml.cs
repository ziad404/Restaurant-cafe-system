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
    /// Interaction logic for TableOrders.xaml
    /// </summary>
    public partial class TableOrders : Window
    {
        PL.Actions actions = new PL.Actions();
        public TableOrders()
        {
            InitializeComponent();
            initializeUI();
            initializeButtonUI();
        }
        public ArrayList myList = new ArrayList();
        public string order_id;
        private void initializeUI()
        {
            TextBlock textBlock1 = new TextBlock();
            textBlock1.Text = "الفاتورة";
            textBlock1.FontSize = 20;
            textBlock1.FontWeight = FontWeights.Normal;
            textBlock1.Padding = new Thickness(5);
            textBlock1.Background = new SolidColorBrush(Colors.AliceBlue);
            textBlock1.TextAlignment = TextAlignment.Center;

            resetPanel.Children.Add(textBlock1);

            TextBlock textBlock2 = new TextBlock();
            textBlock2.Text = helper.selectedTableNum + "  :مقعد رقم";
            textBlock2.FontSize = 18;
            textBlock2.FontWeight = FontWeights.Medium;
            textBlock2.Padding = new Thickness(5);
            textBlock2.Background = new SolidColorBrush(Colors.AliceBlue);
            textBlock2.TextAlignment = TextAlignment.Center;
            resetPanel.Children.Add(textBlock2);

            DataTable dt = actions.get_orders_on_spacific_table(helper.selectedTableId);

            foreach (DataRow Dr in dt.Rows)
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.Width = 900;
                stackPanel.Height = 30;
                stackPanel.Orientation = Orientation.Horizontal;
                stackPanel.VerticalAlignment = VerticalAlignment.Top;
                stackPanel.Margin = new Thickness(10);

                TextBlock textBlock5 = new TextBlock();
                textBlock5.Text = Dr["totalitemPrice"] + "   :الكلي";
                textBlock5.TextAlignment = TextAlignment.Right;
                textBlock5.Margin = new Thickness(5, 0, 0, 1);
                textBlock5.Width = 100;
                textBlock5.FontSize = 18;
                textBlock5.FontWeight = FontWeights.Medium;
                textBlock5.Background = new SolidColorBrush(Colors.Azure);

                myList.Add(Dr["totalitemPrice"]);

                TextBlock textBlock3 = new TextBlock();
                textBlock3.Text = Dr["items_number"] + "   :الكمية";
                textBlock3.TextAlignment = TextAlignment.Right;
                textBlock3.Margin = new Thickness(5, 0, 0, 1);
                textBlock3.Width = 150;
                textBlock3.FontSize = 18;
                textBlock3.FontWeight = FontWeights.Medium;
                textBlock3.Background = new SolidColorBrush(Colors.Azure);

                TextBlock textBlock4 = new TextBlock();
                textBlock4.Text = Dr["itemPrice"] + "   :السعر";
                textBlock4.TextAlignment = TextAlignment.Right;
                textBlock4.Margin = new Thickness(5, 0, 0, 1);
                textBlock4.Width = 100;
                textBlock4.FontSize = 18;
                textBlock4.FontWeight = FontWeights.Medium;
                textBlock4.Background = new SolidColorBrush(Colors.Azure);

                TextBlock textBlock = new TextBlock();
                textBlock.Text = Dr["ItemName"].ToString();
                textBlock.TextAlignment = TextAlignment.Center;
                textBlock.Margin = new Thickness(5, 0, 0, 1);
                textBlock.Width = 350;
                textBlock.FontSize = 18;
                textBlock.FontWeight = FontWeights.Medium;
                textBlock.Background = new SolidColorBrush(Colors.Azure);


                Button button = new Button();
                button.Margin = new Thickness(0, 0, 50, 0);
                button.Name = "T" + Dr["item_id"].ToString();
                button.Width = 50;
                button.Content = "-1";
                button.FontSize = 18;
                button.FontWeight = FontWeights.Medium;
                button.Click += new RoutedEventHandler(OnbClick);

                order_id = Dr["orderId"].ToString();

                stackPanel.Children.Add(button);
                stackPanel.Children.Add(textBlock5);
                stackPanel.Children.Add(textBlock4);
                stackPanel.Children.Add(textBlock3);
                stackPanel.Children.Add(textBlock);
                resetPanel.Children.Add(stackPanel);
            }

        }
        void OnbClick(object sender, RoutedEventArgs e)
        {
            Button bt = sender as Button;
            
            string itemId = "";

            for (int i = 1; i < bt.Name.ToString().Length; i++)
            {
                itemId += bt.Name.ToString()[i];

            }
            Auth.voiding_item vi = new Auth.voiding_item(itemId , order_id);
            vi.ShowDialog();
            resetPanel.Children.Clear();
            totalPanel.Children.Clear();
            myList = new ArrayList();
            initializeUI();
            initializeButtonUI();

        }
        private void initializeButtonUI()
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Width = 900;
            stackPanel.Height = 30;
            stackPanel.Orientation = Orientation.Horizontal;
            stackPanel.VerticalAlignment = VerticalAlignment.Top;
            stackPanel.Margin = new Thickness(10);

            int totalPrice = 0;

            for (int i = 0; i < myList.Count; i++)
            {
                totalPrice += Int32.Parse(myList[i].ToString());
            }

            TextBlock textBlock2 = new TextBlock();
            textBlock2.Text = totalPrice.ToString();
            textBlock2.TextAlignment = TextAlignment.Right;
            textBlock2.Width = 120;
            textBlock2.FontSize = 18;
            textBlock2.FontWeight = FontWeights.Medium;

            TextBlock textBlock0 = new TextBlock();
            textBlock0.Text = "   :الاجمالي";
            textBlock0.TextAlignment = TextAlignment.Left;
            textBlock0.Width = 180;
            textBlock0.FontSize = 18;
            textBlock0.FontWeight = FontWeights.Medium;

            Button button = new Button();
            button.Margin = new Thickness(0, 0, 50, 0);
            button.Name = "c2";
            button.Width = 180;
            button.Content = "الفاتورة";
            button.FontSize = 18;
            button.FontWeight = FontWeights.Medium;
            button.Click += new RoutedEventHandler(OnbClick1);


            stackPanel.Children.Add(button);
            stackPanel.Children.Add(textBlock2);
            stackPanel.Children.Add(textBlock0);
            totalPanel.Children.Add(stackPanel);
        }
        void OnbClick1(object sender, RoutedEventArgs e)
        {
            recipt r = new recipt(Int32.Parse(order_id));
            r.Show();
        }
    }
}
