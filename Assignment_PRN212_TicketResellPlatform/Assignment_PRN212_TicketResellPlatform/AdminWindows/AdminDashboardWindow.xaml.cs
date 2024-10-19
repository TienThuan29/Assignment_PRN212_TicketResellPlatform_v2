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
    /// Interaction logic for AdminDashboardWindow.xaml
    /// </summary>
    public partial class AdminDashboardWindow : Window
    {
        public AdminDashboardWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_Manage_User(object sender, RoutedEventArgs e)
        {
            ManageUserWindow manageUserWindow = new ManageUserWindow();
            manageUserWindow.Show();
            this.Hide();
        }

        private void Button_Click_Manage_Staff(object sender, RoutedEventArgs e)
        {
            ManageStaffWindow manageStaffWindow = new ManageStaffWindow();
            manageStaffWindow.Show();
            this.Hide();
        }

        private void Button_Click_Manage_Policy(object sender, RoutedEventArgs e)
        {
            ManagePolicyWindow managePolicyWindow = new ManagePolicyWindow();
            managePolicyWindow.Show();
            this.Hide();
        }

        private void Button_Click_History_Transaction(object sender, RoutedEventArgs e)
        {
            HistoryTransactionWindow historyTransactionWindow = new HistoryTransactionWindow();
            historyTransactionWindow.Show();
            this.Hide();
        }

        private void Button_Click_Withdrawal_List(object sender, RoutedEventArgs e)
        {
            WithdrawalListWindow withdrawalWindow = new WithdrawalListWindow();
            withdrawalWindow.Show();
            this.Hide();
        }

        private void Button_Click_Exit(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
        }
    }
}
