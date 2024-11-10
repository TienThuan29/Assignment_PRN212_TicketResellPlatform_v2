using BusinessObject;
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
    /// Interaction logic for HistoryTransactionWindow.xaml
    /// </summary>
    public partial class HistoryTransactionWindow : Window
    {

        private readonly IAdminService iAdminService;
        
        public HistoryTransactionWindow()
        {
            InitializeComponent();
            this.iAdminService = new AdminService();
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
            this.tableHistoryTransaction.ItemsSource = iAdminService.GetTransactions();
        }

        private void ReloadDataGrid()
        {
            try
            {
                List<Transaction> list = iAdminService.GetTransactions();
                this.tableHistoryTransaction.ItemsSource = list;
            }
            catch (Exception ex) { }
        }

        private void ButtonClickSearch(object sender, RoutedEventArgs e)
        {
            if (!txtTransaction.Text.Equals(""))
            {
                List<Transaction> list = iAdminService.SearchTransaction(txtTransaction.Text);
                this.tableHistoryTransaction.ItemsSource = list;
            }
            else
            {
                this.ReloadDataGrid();
            }
        }
    }
}
