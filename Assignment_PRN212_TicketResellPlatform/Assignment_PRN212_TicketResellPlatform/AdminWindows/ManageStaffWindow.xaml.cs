﻿using Service.Admin;
using Service.AdminService;
using Service.Staff;
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

namespace Assignment_PRN212_TicketResellPlatform.AdminWindows
{
    /// <summary>
    /// Interaction logic for ManageStaffWindow.xaml
    /// </summary>
    public partial class ManageStaffWindow : Window
    {
        private IAdminService adminService;
        public ManageStaffWindow()
        {
            adminService = new AdminService();
            InitializeComponent();
        }
        private void ButtonClickManageUser(object sender, RoutedEventArgs e)
        {
            ManageUserWindow manageUserWindow = new ManageUserWindow();
            manageUserWindow.Show();
            this.Hide();
        }

        private void ButtonClickManageStaff(object sender, RoutedEventArgs e)
        {
            ManageStaffWindow manageStaffWindow = new ManageStaffWindow();
            manageStaffWindow.Show();
            this.Hide();
        }

        private void ButtonClickManagePolicy(object sender, RoutedEventArgs e)
        {
            ManagePolicyWindow managePolicyWindow = new ManagePolicyWindow();
            managePolicyWindow.Show();
            this.Hide();
        }

        private void ButtonClickHistoryTransaction(object sender, RoutedEventArgs e)
        {
            HistoryTransactionWindow historyTransactionWindow = new HistoryTransactionWindow();
            historyTransactionWindow.Show();
            this.Hide();
        }

        private void ButtonClickWithdrawalList(object sender, RoutedEventArgs e)
        {
            WithdrawalListWindow withdrawalWindow = new WithdrawalListWindow();
            withdrawalWindow.Show();
            this.Hide();
        }

        private void ButtonClickExit(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            this.tableOfStaff.ItemsSource = adminService.GetListStaff();
        }

        private void ButtonClickSearch(object sender, RoutedEventArgs e)
        {
            if (txtSearchStaff.Text.Equals(""))
            {
                this.ReloadDataGrid();
            }
            else
            {
                this.tableOfStaff.ItemsSource = adminService.Search(txtSearchStaff.Text);
            }
            
        }

        private void ReloadDataGrid()
        {
            try
            {
                List<BusinessObject.Staff> list = adminService.GetListStaff();
                this.tableOfStaff.ItemsSource = list;
            }
            catch (Exception ex) { }
        }

        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            AddStaffWindow addStaffWindow = new AddStaffWindow();
            addStaffWindow.Show();
            this.Close();
        }
    }
}
