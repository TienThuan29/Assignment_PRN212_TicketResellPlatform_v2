﻿using Service.Admin;
using Service.AdminService;
using BusinessObject;
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
    /// Interaction logic for ManagePolicyWindow.xaml
    /// </summary>
    public partial class ManagePolicyWindow : Window
    {
        private IAdminService iAdminService;
        private IPolicyService iPolicyService;
        public ManagePolicyWindow()
        {
            InitializeComponent();
            iAdminService = new AdminService();
            iPolicyService = new PolicyService();
        }

        private void ButtonClickHomePage(object sender, RoutedEventArgs e)
        {
            AdminDashboardWindow adminDashboardWindow = new AdminDashboardWindow();
            adminDashboardWindow.Show();
            this.Hide();
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

        private void ButtonClickExit(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            List<Policy> policies = iPolicyService.GetPolicies();
            this.tableManagePolicy.ItemsSource = policies;
        }

        private void ButtonClickSearch(object sender, RoutedEventArgs e)
        {
            if (txtSearchPolicy.Text.Equals(""))
            {
                this.ReloadDataGrid();
            }
            else
            {
                this.tableManagePolicy.ItemsSource = iPolicyService.Search(txtSearchPolicy.Text);
            }
        }

        public void ReloadDataGrid()
        {
            try
            {
                List<Policy> policies = iPolicyService.GetPolicies();
                this.tableManagePolicy.ItemsSource = policies;
            }
            catch (Exception ex) { }
        }

        private void ButtonClickAdd(object sender, RoutedEventArgs e)
        {
            AddPolicyWindow addPolicyWindow = new AddPolicyWindow(this);
            addPolicyWindow.Show();
        }

        private void ButtonClickChangeAble(object sender, RoutedEventArgs e)
        {
            switch (MessageBox.Show("Bạn muốn thay đổi trạng thái của chính sách ?",
    "Thông báo", MessageBoxButton.YesNo))
            {
                case MessageBoxResult.Yes:
                    var button = sender as Button;
                    string id = button?.Tag?.ToString();
                    if (iPolicyService.ChangeEnableOfPolicy(id))
                    {
                        MessageBox.Show("Thay đổi trạng thái chính sách thành công !");
                        this.ReloadDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("Thay đổi trạng thái chính sách thất bại !");
                    }
                    break;
                case MessageBoxResult.No:
                    this.ReloadDataGrid();
                    break;
            }
        }

        private void ButtonClickUpdatePolicy(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            int id = int.Parse(button?.Tag?.ToString());
            Policy policy = iPolicyService.GetPolicy(id);
            if (policy != null)
            {
                AddPolicyWindow policyWindow = new AddPolicyWindow(this, policy);
                policyWindow.Show();
            }
        }
    }
}
