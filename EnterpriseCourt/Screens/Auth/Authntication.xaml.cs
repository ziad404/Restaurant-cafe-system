﻿using System;
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
    /// Interaction logic for Authntication.xaml
    /// </summary>
    public partial class Authntication : Window
    {
        PL.Actions actions = new PL.Actions();
        public Authntication()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            DataTable DT = actions.Login(userName_txt.Text, password_txt.Password);
            if (DT.Rows.Count > 0)
            {
               
                helper.password = password_txt.Password;
                Utils.helper_user.cashiername = userName_txt.Text;
                helper.ID = Int16.Parse(DT.Rows[0]["id"].ToString());

                if(DT.Rows[0]["role"].ToString() == "Admin")
                {
                    Admin_roles admin_Roles = new Admin_roles();
                    this.Hide();
                    admin_Roles.Show();
                }
                else
                {
                    Screens.CashierRoles.OrderType ot = new Screens.CashierRoles.OrderType();
                    this.Hide();
                    ot.Show();
                }
            }
            else
            {
                MessageBox.Show("Login Failed");
                userName_txt.Text = "";
                password_txt.Password = "";
            }
        }
    }
}
