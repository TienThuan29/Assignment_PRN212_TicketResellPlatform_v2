using Service.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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

namespace Assignment_PRN212_TicketResellPlatform
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        private IUserService userService = new UserService();

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void ToLoginPage(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.Show();
        }

        private void RegisterUserAccount(object sender, RoutedEventArgs e)
        {
            string username = usernameTextbox.Text;
            string firstname = firstnameTextbox.Text;
            string lastname = lastnameTextbox.Text;
            string email = emailTextbox.Text;
            string password = passwordBox.Password.ToString();
            string repeatPass = repeatPasswordBox.Password.ToString();  

            if (
                username == null || username.Trim().Length == 0 ||
                firstname == null || firstname.Trim().Length == 0 ||
                lastname == null || lastname.Trim().Length == 0 ||
                !this.CheckEmaidAddress(email) ||
                password == null || password.Trim().Length == 0 ||
                repeatPass == null || repeatPass.Trim().Length == 0
            ) 
            {
                MessageBox.Show("Bạn không được để trống các mục điền!");
            }
            else if (password.Equals(repeatPass))
            { 
                // save user
            }
            else
            {
                MessageBox.Show("Mật khẩu nhập lại không hợp lệ!");
            }
        }

        private bool CheckEmaidAddress(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
