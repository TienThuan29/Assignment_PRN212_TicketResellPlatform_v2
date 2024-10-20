using Service.TransactionService;
using Service.Utils.TienThuan;
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
    public partial class HistoryDepositeWindow : Window
    {
        private BusinessObject.User logedUser;

        private ITransactionService transactionService = new TransactionService();  

        public HistoryDepositeWindow()
        {
            InitializeComponent();
        }

        public HistoryDepositeWindow(BusinessObject.User user)
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
            balanceLabel.Content = balanceLabel.Content.ToString() + StringFormatUtil.FormatVND((long)logedUser.Balance);
        }


        // Show all transaction data of user
        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            transactionDataGrid.ItemsSource = transactionService.FindByUserID(logedUser.Id);
        }

        // Handle rediect other window

        private void ReturnBalanceManageWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BalanceManagementWindow balanceManagementWindow = new BalanceManagementWindow(logedUser);
            balanceManagementWindow.Show(); 
        }

        private void ToUserProfileWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            UserProfileWindow userProfileWindow = new UserProfileWindow(logedUser);
            userProfileWindow.Show();   
        }
    }
}
