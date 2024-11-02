using Service.TransactionService;
using Service.Utils;
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
            if (!string.IsNullOrEmpty(logedUser.Avatar))
            {
                Uri uri = new Uri(LocalPathSetting.ProfileImagePath + logedUser.Avatar, UriKind.Absolute);
                avatarImageBrush.ImageSource = new BitmapImage(uri);
                avatarImageBrushHeader.ImageSource = new BitmapImage(uri);
            }
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
        private void ShowHomeWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HomeWindow mainWindow = new HomeWindow(logedUser);
            mainWindow.Show();
        }

        private void ToMyShopWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MyShopWindow myShopWindow = new MyShopWindow(logedUser);
            myShopWindow.Show();
        }

        private void ToManageBalanceWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BalanceManagementWindow balanceManagementWindow = new BalanceManagementWindow(logedUser);
            balanceManagementWindow.Show();
        }

        private void ToChangePasswordWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow(logedUser);
            changePasswordWindow.Show();    
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
