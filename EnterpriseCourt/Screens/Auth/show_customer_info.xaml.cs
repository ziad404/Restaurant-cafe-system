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
    /// Interaction logic for show_customer_info.xaml
    /// </summary>
    public partial class show_customer_info : Window
    {
        PL.Actions actions = new PL.Actions();
        List<items> it = new List<items>();
        public show_customer_info()
        {
            InitializeComponent();
            DataTable DT = actions.get_customers();
            foreach (DataRow DR in DT.Rows)
            {
                it.Add(new items
                {
                    id = DR["id"].ToString(),
                    name = DR["name"].ToString(),
                    phone = DR["phone"].ToString()
                });
            }

            datagrid1.ItemsSource = it;
        }
        
        class items
        {
            public string id { get; set; }
            public string name { get; set; }
            public string phone { get; set; }
        }

        
    }
}
