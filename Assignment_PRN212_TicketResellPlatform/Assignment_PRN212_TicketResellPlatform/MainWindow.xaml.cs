using Assignment_PRN212_TicketResellPlatform.AdminWindows;
using Assignment_PRN212_TicketResellPlatform.StaffWindows;
using Assignment_PRN212_TicketResellPlatform.UserWindows;
using Service.Authentication;
using Service.Constant;
using Service.Staff;
using Service.User;
using System.Diagnostics.Eventing.Reader;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment_PRN212_TicketResellPlatform
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private IUserService userService = new UserService();

        private IStaffService staffService = new StaffService();    

        public MainWindow()
        {
            InitializeComponent();
        }

        private void HandleLogin(object sender, RoutedEventArgs e)
        {
            var user = userService.FindByUsername(usernameTextbox.Text);

            if (user != null && user.Password.Equals(passwordBox.Password.ToString()))
            {
                //UserProfileWindow profileWindow = new UserProfileWindow(user);
                //this.Hide();
                //profileWindow.Show();
                HomeWindow homeWindow = new HomeWindow(user);
                this.Hide();
                homeWindow.Show();
            }
            else
            {
                var staff = staffService.FindByUsername(usernameTextbox.Text);
                if (staff != null && staff.Password.Equals(passwordBox.Password.ToString()))
                {
                    if (staff.RoleCode.Equals(Role.STAFF))
                    {
                        // Show staff dashboard here
                        StaffDashboardWindow staffDashboardWindow = new StaffDashboardWindow(staff);
                        staffDashboardWindow.Show();
                        this.Hide();
                    }
                    else if (staff.RoleCode.Equals(Role.ADMIN))
                    {
                        // Show admin dashboard here
                        AdminDashboardWindow adminDashboardWindow = new AdminDashboardWindow();
                        adminDashboardWindow.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show(
                        "Tên đăng nhập hoặc mật khẩu không đúng!", "Đăng nhập", 
                        MessageBoxButton.OK, MessageBoxImage.Error
                    );
                }
            }
        }

        private void ToRegisterWindow(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            this.Hide();
            registerWindow.Show();
        }

        private void ButtonClickExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}