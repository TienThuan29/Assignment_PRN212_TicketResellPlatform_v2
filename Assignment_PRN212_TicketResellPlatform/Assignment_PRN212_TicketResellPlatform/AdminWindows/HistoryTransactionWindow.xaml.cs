using BusinessObject;
using Service.Admin;
using Service.AdminService;
using Service.Constant;
using Service.TransactionService;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assignment_PRN212_TicketResellPlatform.AdminWindows
{
    /// <summary>
    /// Interaction logic for HistoryTransactionWindow.xaml
    /// </summary>
    public partial class HistoryTransactionWindow : Window
    {

        private readonly IAdminService iAdminService;
        private readonly TransactionService transactionService;

        public HistoryTransactionWindow()
        {
            InitializeComponent();
            this.iAdminService = new AdminService();
            this.transactionService = new TransactionService();
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

        private void ButtonClickHomePage(object sender, RoutedEventArgs e)
        {
            AdminDashboardWindow adminDashboardWindow = new AdminDashboardWindow();
            adminDashboardWindow.Show();
            this.Hide();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            this.tableHistoryTransaction.ItemsSource = iAdminService.GetTransactions();
            Dictionary<string, string> transtypes = new Dictionary<string, string>
            {
                { TransactionType.WITHDRAWAL, "Rút tiền" },
                { TransactionType.BUYING, "Mua vé" },
                { TransactionType.SELLING, "Bán vé" },
                { TransactionType.DEPOSITE, "Nạp tiền" }
            };
            cmbTransType.ItemsSource = transtypes;
            cmbTransType.DisplayMemberPath = "Value";
            cmbTransType.SelectedValuePath = "Key";
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
            string date = dateSearchTransaction.Text;
            this.tableHistoryTransaction.ItemsSource = transactionService.SearchByDateOrType(date, cmbTransType.SelectedValue.ToString());
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            ReloadDataGrid();
        }
    }
}
