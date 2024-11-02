using Service.TransactionService;
using Service.User;
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
    /// <summary>
    /// Interaction logic for BalanceManagementWindow.xaml
    /// </summary>
    public partial class BalanceManagementWindow : Window
    {
        private BusinessObject.User logedUser;

        private IUserService userService = new UserService();

        private ITransactionService transactionService = new TransactionService();

        private readonly string MESSAGE_BOX_HEADER_DEPOSITE = "Nạp tiền";

        public BalanceManagementWindow()
        {
            InitializeComponent();
        }

        public BalanceManagementWindow(BusinessObject.User user)
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
            balanceLabel.Content = "Số dư: " + StringFormatUtil.FormatVND((long)logedUser.Balance);
            balanceMainLabel.Content = "Số dư: " + StringFormatUtil.FormatVND((long)logedUser.Balance);
        }

        private void UpdateDataWindow()
        {
            balanceLabel.Content = "Số dư: " + StringFormatUtil.FormatVND((long)logedUser.Balance);
            balanceMainLabel.Content = "Số dư của bạn: " + StringFormatUtil.FormatVND((long)logedUser.Balance);
        }

        // Handle button click

        private void HandleDeposite(object sender, RoutedEventArgs e)
        {
            string[] amountDeposite = amountDepositeComboBox.Text.Split(".");
            long amount = long.Parse(amountDeposite[0]) * 1000;

            var result = MessageBox.Show("Xác nhận nạp " + StringFormatUtil.FormatVND(amount), MESSAGE_BOX_HEADER_DEPOSITE, 
                MessageBoxButton.YesNo, MessageBoxImage.Question
            );
            switch(result)
            {
                case MessageBoxResult.Yes:
                    // Add balance to user
                    this.logedUser.Balance = this.logedUser.Balance + amount;
                    bool flag = userService.SaveProfile(this.logedUser) && 
                                transactionService.SaveDepositeTransaction(this.logedUser.Id, amount);
                    if (flag) MessageBox.Show(
                        "Nạp tiền thành công!", MESSAGE_BOX_HEADER_DEPOSITE, MessageBoxButton.OK, MessageBoxImage.Information
                    );
                    UpdateDataWindow();
                    break;
                case MessageBoxResult.No:
                case MessageBoxResult.Cancel:
                    MessageBox.Show(
                        "Giao dịch bị hủy bỏ!", MESSAGE_BOX_HEADER_DEPOSITE, MessageBoxButton.OK, MessageBoxImage.Information
                    );
                    break;    
            }

        }

        // Redirect to other windows

        private void ToUserProfileWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            UserProfileWindow userProfileWindow = new UserProfileWindow(logedUser);
            userProfileWindow.Show();
        }

        private void ToHistoryDepositeWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HistoryDepositeWindow history = new HistoryDepositeWindow(logedUser);
            history.Show();
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

        private void ToChangePasswordWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow(logedUser);    
            changePasswordWindow.Show();    
        }
    }
}
