﻿using BusinessObject;
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

namespace Assignment_PRN212_TicketResellPlatform.UserWindows
{
    /// <summary>
    /// Interaction logic for UserProfileWindow.xaml
    /// </summary>
    public partial class UserProfileWindow : Window
    {
        private BusinessObject.User logedUser;

        public UserProfileWindow()
        {
            InitializeComponent();
        }

        public UserProfileWindow(BusinessObject.User user)
        {
            InitializeComponent();
            this.logedUser = user;
            this.InitDataOnWindow();
        }

        private void InitDataOnWindow()
        {
            // Init label
            fullnameLabel.Content = logedUser.Firstname + " " + logedUser.Lastname;
            fullnameHeaderLabel.Content = logedUser.Firstname + " " + logedUser.Lastname;
            balanceLabel.Content = balanceLabel.Content.ToString() + logedUser.Balance + "đ";
            // Init textbox
            firstnameTextBox.Text = logedUser.Firstname;
            lastnameTextBox.Text = logedUser.Lastname;
            emailTextBox.Text = logedUser.Email;    
            phoneTextBox.Text = logedUser.Phone;
        }

        private void ShowChangePasswordWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow();
            changePasswordWindow.Show();
        }

        private void ShowBalanceManagementWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BalanceManagementWindow balanceManagementWindow = new BalanceManagementWindow();
            balanceManagementWindow.Show();
        }

        private void ShowMyShopWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MyShopWindow myShopWindow = new MyShopWindow(); 
            myShopWindow.Show();    
        }
    }
}
