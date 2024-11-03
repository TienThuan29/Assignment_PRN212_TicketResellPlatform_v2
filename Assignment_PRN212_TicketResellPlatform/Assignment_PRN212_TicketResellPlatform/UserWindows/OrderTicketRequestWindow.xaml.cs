using BusinessObject;
using Service.Utils.TienThuan;
using Service.Utils;
using System.Windows;
using System.Windows.Media.Imaging;


namespace Assignment_PRN212_TicketResellPlatform.UserWindows
{
    public partial class OrderTicketRequestWindow : Window
    {
        private  BusinessObject.User logedUser;

        public OrderTicketRequestWindow()
        {
            InitializeComponent();
        }

        public OrderTicketRequestWindow(BusinessObject.User user)
        {
            InitializeComponent();
            this.logedUser = user;
            InitDataWindow();
        }

        private void InitDataWindow()
        {
            if (!string.IsNullOrEmpty(logedUser.Avatar))
            {
                Uri uri = new Uri(LocalPathSetting.ProfileImagePath + logedUser.Avatar, UriKind.Absolute);
                avatarImageBrush.ImageSource = new BitmapImage(uri);
                avatarImageBrushHeader.ImageSource = new BitmapImage(uri);
            }
            fullnameLabel.Content = logedUser.Firstname + " " + logedUser.Lastname;
            fullnameHeaderLabel.Content = logedUser.Firstname + " " + logedUser.Lastname;
            balanceLabel.Content = balanceLabel.Content.ToString() + StringFormatUtil.FormatVND((long)logedUser.Balance);
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.Show();
        }

        private void ToChangePasswordWindow(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow(logedUser);
            this.Hide();
            changePasswordWindow.Show();
        }

        private void ToManageBalanceWindow(object sender, RoutedEventArgs e)
        {
            BalanceManagementWindow balanceManagementWindow = new BalanceManagementWindow(logedUser);
            this.Hide();
            balanceManagementWindow.Show();
        }

        private void ToMyShopWindow(object sender, RoutedEventArgs e)
        {
            MyShopWindow myShopWindow = new MyShopWindow(logedUser);
            this.Hide();
            myShopWindow.Show();
        }

        private void ToUserProfileWindow(object sender, RoutedEventArgs e)
        {
            UserProfileWindow userProfileWindow = new UserProfileWindow(logedUser);
            this.Hide();
            userProfileWindow.Show();
        }

        private void ShowHomeWindow(object sender, RoutedEventArgs e)
        {

        }
    }
}
