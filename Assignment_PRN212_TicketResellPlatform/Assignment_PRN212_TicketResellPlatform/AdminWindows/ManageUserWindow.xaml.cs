using Service.Admin;
using Service.AdminService;
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
    /// Interaction logic for ManageUserWindow.xaml
    /// </summary>
    public partial class ManageUserWindow : Window
    {
        private IAdminService adminService;
        public ManageUserWindow()
        {
            adminService = new AdminService();
            InitializeComponent();
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
            this.tableOfUser.ItemsSource = adminService.GetUsers();
        }

        private void ReloadDataGrid()
        {
            try
            {
                this.tableOfUser.ItemsSource = adminService.GetUsers();
            }
            catch (Exception ex) { }
        }

        private void ButtonClickSearch(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text.Equals(""))
            {
                this.ReloadDataGrid();
            }
            else
            {
                this.tableOfUser.ItemsSource = adminService.SearchUser(txtSearch.Text);
            }
        }

        private void ButtonClickChangeAble(object sender, RoutedEventArgs e)
        {
            switch(MessageBox.Show("Bạn muốn thay đổi trạng thái của tài khoản người dùng ?",
    "Thông báo", MessageBoxButton.YesNo))
            {
                case MessageBoxResult.Yes:
                    var button = sender as Button;
                    string id = button?.Tag?.ToString();
                    if (adminService.ChangeEnableOfUser(id))
                    {
                        MessageBox.Show("Thay đổi trạng thái tài khoản người dùng thành công !");
                        this.ReloadDataGrid();
                    }
                    else
                    {
                        MessageBox.Show("Thay đổi trạng thái tài khoản người dùng thất bại !");
                    }
                    break;
                case MessageBoxResult.No:
                    this.ReloadDataGrid();
                    break;
            }
            
        }    
    }
}
