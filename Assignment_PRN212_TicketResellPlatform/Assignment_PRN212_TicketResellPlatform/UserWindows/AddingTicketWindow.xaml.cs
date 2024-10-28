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

namespace Assignment_PRN212_TicketResellPlatform.UserWindows
{
    /// <summary>
    /// Interaction logic for AddingTicketWindow.xaml
    /// </summary>
    public partial class AddingTicketWindow : Window
    {
        private BusinessObject.User logedUser;


        public AddingTicketWindow()
        {
            InitializeComponent();
        }

        public AddingTicketWindow(BusinessObject.User user)
        {
            InitializeComponent();
            this.logedUser = user;
        }

        private void ShowHomeWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HomeWindow homeWindow = new HomeWindow(logedUser);
            homeWindow.Show();
        }
    }
}
