using BusinessObject;
using Microsoft.Win32;
using Service.User;
using Service.Utils.TienThuan;
using System.Windows;
using Microsoft.Win32;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.IO;
using Service.Utils;


namespace Assignment_PRN212_TicketResellPlatform.UserWindows
{
    /// <summary>
    /// Interaction logic for UserProfileWindow.xaml
    /// </summary>
    public partial class UserProfileWindow : Window
    {
        private BusinessObject.User logedUser;

        private IUserService userService = new UserService();

        public UserProfileWindow()
        {
            InitializeComponent();
        }

        public UserProfileWindow(BusinessObject.User user)
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
            // Init textbox
            firstnameTextBox.Text = logedUser.Firstname;
            lastnameTextBox.Text = logedUser.Lastname;
            emailTextBox.Text = logedUser.Email;    
            phoneTextBox.Text = logedUser.Phone;
        }

        // Handle button click on window

        private void SaveProfile(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            if (
                firstnameTextBox.Text.Length > 0 &&
                lastnameTextBox.Text.Length > 0 &&
                emailTextBox.Text.Length > 0
            )
            {
                this.logedUser.Firstname = firstnameTextBox.Text;
                this.logedUser.Lastname = lastnameTextBox.Text; 
                this.logedUser.Email = emailTextBox.Text;   
                this.logedUser.Phone = phoneTextBox.Text;  
                flag = userService.SaveProfile( this.logedUser );
            }
            else
            {
                MessageBox.Show("Bạn không được để trống các mục nhập");
            }

            if (flag) MessageBox.Show("Cập nhật thông tin thành công");
        }

        private void ChangeAvatar(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                try
                {
                    string fullFilename = fileDialog.FileName;
                    avatarImageBrush.ImageSource = new BitmapImage(new Uri(fullFilename, UriKind.Absolute));
                    FileInfo fileInfo = new FileInfo(fullFilename);
                    string filename = System.IO.Path.GetFileName(fullFilename);
                    
                    if (!File.Exists(LocalPathSetting.ProfileImagePath + filename))
                    {
                        fileInfo.CopyTo(LocalPathSetting.ProfileImagePath + filename);
                    }
                    // Save db
                    this.logedUser.Avatar = filename;
                    userService.SaveProfile(this.logedUser);
                    ShowInfoMessageBox("Cập nhật ảnh đại diện thành công!");
                }
                catch (Exception ex) 
                {
                    ShowErrorMessageBox("Cập nhật ảnh đại diện không thành công!");
                }
            }
        }

        // Redirect to other windows

        private void ShowChangePasswordWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow(logedUser);
            changePasswordWindow.Show();
        }

        
        private void ShowBalanceManagementWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            BalanceManagementWindow balanceManagementWindow = new BalanceManagementWindow(logedUser);
            balanceManagementWindow.Show();
        }

        private void ShowMyShopWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MyShopWindow myShopWindow = new MyShopWindow(logedUser); 
            myShopWindow.Show();    
        }

        // Handle logout function
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

        // Message box define
        public void ShowInfoMessageBox(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        public void ShowErrorMessageBox(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
