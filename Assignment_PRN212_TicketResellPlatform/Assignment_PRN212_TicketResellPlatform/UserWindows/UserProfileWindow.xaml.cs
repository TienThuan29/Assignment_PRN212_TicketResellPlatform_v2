using BusinessObject;
using Service.User;
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
    }
}
