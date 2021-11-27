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

namespace EnterpriseCourt.Screens.CashierRoles
{
    /// <summary>
    /// Interaction logic for Tables.xaml
    /// </summary>
    public partial class Tables : Window
    {
            PL.Actions actions = new PL.Actions();
        public Tables()
        {

            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            TextBlock textBlock2 = new TextBlock();
            textBlock2.Text = "ألاخضر = فاضي و ألاحمر = مليان";
            textBlock2.FontSize = 18;
            textBlock2.FontWeight = FontWeights.Medium;
            textBlock2.Padding = new Thickness(5);
            textBlock2.Background = new SolidColorBrush(Colors.DarkRed);
            textBlock2.TextAlignment = TextAlignment.Center;
            TablesPanel.Children.Add(textBlock2);
            TextBlock textBlock1 = new TextBlock();
            textBlock1.Text = "المقاعد";
            textBlock1.FontSize = 18;
            textBlock1.FontWeight = FontWeights.Medium;
            textBlock1.Padding = new Thickness(5);
            textBlock1.Background = new SolidColorBrush(Colors.DarkKhaki);
            textBlock1.TextAlignment = TextAlignment.Center;
            TablesPanel.Children.Add(textBlock1);

            DataTable DT = actions.getAllTables();

            Dictionary<string ,Utils.Pair<string, string>> TablesData;
            TablesData = new Dictionary<string,Utils.Pair<string, string>>();

            foreach (DataRow DR in DT.Rows)
            {
                Utils.Pair<string, string> pair =
                    new Utils.Pair<string, string>(DR["name"].ToString(), DR["status"].ToString());
                TablesData.Add(DR["id"].ToString() , pair);
            }

            int n = TablesData.Count();
            int counter = 0;

            for (int i = 0; i < n - n % 4; i += 4)
            {
                StackPanel stackPanel;
                stackPanel = new StackPanel();
                stackPanel.Width = 900;
                stackPanel.Height = 110;
                stackPanel.Orientation = Orientation.Horizontal;
                stackPanel.VerticalAlignment = VerticalAlignment.Top;
                stackPanel.Margin = new Thickness(10);
                TablesPanel.Children.Add(stackPanel);

                for (int j = 0; j < 4; j++)
                {
                    Button b1 = new Button();
                    b1.Name = "T" + TablesData.ElementAt(counter).Key;
                    b1.Height = 90;
                    b1.Content = TablesData.ElementAt(counter).Value.First;
                    b1.Margin = new Thickness(10);
                    b1.Width = 200;
                    b1.FontSize = 20;

                    if(TablesData.ElementAt(counter).Value.Second == "False")
                    {
                        b1.Background = Brushes.LightGreen;
                    }
                    else{
                        b1.Background = Brushes.Red;
                    }
                    b1.FontSize = 20;
                    b1.FontWeight = FontWeights.Medium;
                    b1.Click += new RoutedEventHandler(OnbClick);
                    stackPanel.Children.Add(b1);
                    counter++;
                }

            }
            for (int i = 0; i < n % 4; i += n % 4)
            {
                StackPanel stackPanel;
                stackPanel = new StackPanel();
                stackPanel.Width = 900;
                stackPanel.Height = 100;
                stackPanel.Orientation = Orientation.Horizontal;
                stackPanel.VerticalAlignment = VerticalAlignment.Top;
                stackPanel.Margin = new Thickness(10);
                TablesPanel.Children.Add(stackPanel);
                for (int j = 0; j < n % 4; j++)
                {
                    Button b1 = new Button();
                    b1.Name = "T"+TablesData.ElementAt(counter).Key;
                    b1.Height = 90;
                    b1.Content = TablesData.ElementAt(counter).Value.First;
                    b1.Margin = new Thickness(10);
                    b1.Width = 200;
                    b1.FontSize = 20;
                    if (TablesData.ElementAt(counter).Value.Second == "False")
                    {
                        b1.Background = Brushes.LightGreen;
                    }
                    else
                    {
                        b1.Background = Brushes.Red;
                    }
                    b1.FontSize = 20;
                    b1.FontWeight = FontWeights.Medium;
                    b1.Click += new RoutedEventHandler(OnbClick);
                    stackPanel.Children.Add(b1);
                    counter++;
                }
            }
         }
        void OnbClick(object sender, RoutedEventArgs e)
        {
            Button bt = sender as Button;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TablesPanel.Children.Clear();
            InitializeUI();
        }
    }
}
