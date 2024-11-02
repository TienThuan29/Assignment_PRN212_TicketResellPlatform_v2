﻿using BusinessObject;
using Service.TicketService;
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

namespace Assignment_PRN212_TicketResellPlatform.StaffWindows
{
    /// <summary>
    /// Interaction logic for ManageSellingTicketRequestWindow.xaml
    /// </summary>
    public partial class ManageSellingTicketRequestWindow : Window
    {
        private Staff staff;
        private readonly GenericTicketService genericTicketService;
        private readonly TicketService ticketService;
        public ManageSellingTicketRequestWindow()
        {
            InitializeComponent();
        }

        public ManageSellingTicketRequestWindow(Staff staff)
        {
            InitializeComponent();
            this.staff = staff;
            this.genericTicketService = new GenericTicketService();
            this.ticketService = new TicketService();
        }

        public void OnWindowLoad(object sender, RoutedEventArgs e)
        {

        }

        private void StaffInfo_Click(object sender, RoutedEventArgs e)
        {
            StaffDashboardWindow staffDashboardWindow = new StaffDashboardWindow();
            this.Hide();
            staffDashboardWindow.Show();
        }

        private void ManageEvent_Click(object sender, RoutedEventArgs e)
        {
            ManageEventWindow manageEventWindow = new ManageEventWindow();
            this.Hide();
            manageEventWindow.Show();
        }

        private void ManageSellingRequest_Click(object sender, RoutedEventArgs e)
        {
            ManageSellingTicketRequestWindow manageSellingTicketRequestWindow = new ManageSellingTicketRequestWindow();
            this.Hide();
            manageSellingTicketRequestWindow.Show();
        }

        private void ViewInfoUser_Click(object sender, RoutedEventArgs e)
        {
            ViewUserInfoWindow viewUserInfoWindow = new ViewUserInfoWindow();
            this.Hide();
            viewUserInfoWindow.Show();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.Show();
        }
    }
}
