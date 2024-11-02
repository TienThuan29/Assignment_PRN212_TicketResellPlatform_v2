using BusinessObject;
using Service.User;
using Service.Utils;
using System.Windows;


namespace Assignment_PRN212_TicketResellPlatform.StaffWindows
{
    /// <summary>
    /// Interaction logic for ViewUserInfoWindow.xaml
    /// </summary>
    public partial class ViewUserInfoWindow : Window
    {
        private readonly IUserService userService;
        private Staff staff;
        public ViewUserInfoWindow()
        {
            InitializeComponent();
        }

        public ViewUserInfoWindow(Staff staff)
        {
            InitializeComponent();
            this.staff = staff;
            this.userService = new UserService();
        }

        public void OnWindowLoad(object sender, RoutedEventArgs e)
        {
            var users = userService.GetAllUsers();
            foreach (var user in users)
            {
                if (!user.Avatar.Contains(LocalPathSetting.ProfileImagePath))
                {
                    user.Avatar = LocalPathSetting.ProfileImagePath+user.Avatar;
                }
            }  

            UserGrid.ItemsSource= users;
        }

        //Side bar button
        private void StaffInfo_Click(object sender, RoutedEventArgs e)
        {
            StaffDashboardWindow staffDashboardWindow = new StaffDashboardWindow(staff);
            this.Hide();
            staffDashboardWindow.Show();
        }

        private void ManageEvent_Click(object sender, RoutedEventArgs e)
        {
            ManageEventWindow manageEventWindow = new ManageEventWindow(staff);
            this.Hide();
            manageEventWindow.Show();
        }

        private void ManageSellingRequest_Click(object sender, RoutedEventArgs e)
        {
            ManageSellingTicketRequestWindow manageSellingTicketRequestWindow = new ManageSellingTicketRequestWindow(staff);
            this.Hide();
            manageSellingTicketRequestWindow.Show();
        }

        private void ViewInfoUser_Click(object sender, RoutedEventArgs e)
        {
            ViewUserInfoWindow viewUserInfoWindow = new ViewUserInfoWindow(staff);
            this.Hide();
            viewUserInfoWindow.Show();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.Show();
        }
    }
}
