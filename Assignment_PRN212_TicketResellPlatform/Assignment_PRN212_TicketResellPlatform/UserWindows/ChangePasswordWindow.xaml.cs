using BusinessObject;
using Service.User;
using Service.Utils;
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
    public partial class ChangePasswordWindow : Window
    {
        private User logedUser;

        private IUserService userService = new UserService();

        public ChangePasswordWindow()
        {
            InitializeComponent();
        }

        public ChangePasswordWindow(User user)
        {
            InitializeComponent();
            this.logedUser = user;  
            this.InitDataOnWindow();
        }

        private void InitDataOnWindow()
        {
            Uri uri = new Uri(LocalPathSetting.ProfileImagePath + logedUser.Avatar, UriKind.Absolute);
            avatarImageBrush.ImageSource = new BitmapImage(uri);
            avatarImageBrushHeader.ImageSource = new BitmapImage(uri);
            // Init label
            fullnameLabel.Content = logedUser.Firstname + " " + logedUser.Lastname;
            fullnameHeaderLabel.Content = logedUser.Firstname + " " + logedUser.Lastname;
            balanceLabel.Content = balanceLabel.Content.ToString() + logedUser.Balance + "đ";
        }

        private void ToUserProfileWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            UserProfileWindow userProfileWindow = new UserProfileWindow(logedUser);
            userProfileWindow.Show();
        }

        
        private void SaveNewPassword(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            string oldPass = oldPasswordBox.Password.ToString();
            string newPass = newPasswordBox.Password.ToString();
            string repeatNewPass = repeatNewPasswordBox.Password.ToString();
            if (newPass.Equals(repeatNewPass)) 
            {
                if(logedUser.Password.Equals(oldPass)) 
                {
                    flag = userService.SaveNewPassword(logedUser.Id, newPass); 
                }
                else
                {
                    MessageBox.Show("Mật khẩu cũ không đúng!");
                }
            }
            else
            {
                MessageBox.Show("Mật khẩu nhập lại không hợp lệ!");
            }

            if (flag) MessageBox.Show("Đổi mật khẩu thành công");
        }

        private void HandleLogout(object sender, RoutedEventArgs e)
        {
            this.logedUser = null;
            this.Hide();
            MainWindow mainWindow = new MainWindow(); 
            mainWindow.Show();
        }

        private void ShowHomeWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HomeWindow mainWindow = new HomeWindow(logedUser);
            mainWindow.Show();
        }

    }
}
