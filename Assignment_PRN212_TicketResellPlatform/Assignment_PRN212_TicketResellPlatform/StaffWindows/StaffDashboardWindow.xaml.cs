using BusinessObject;
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

namespace Assignment_PRN212_TicketResellPlatform.StaffWindows
{
    /// <summary>
    /// Interaction logic for StaffDashboardWindow.xaml
    /// </summary>
    public partial class StaffDashboardWindow : Window
    {
        private readonly Staff staff;
        public StaffDashboardWindow()
        {
            InitializeComponent();
        }

        public StaffDashboardWindow(Staff staff)
        {
            InitializeComponent();
            this.staff = staff;
        }

        public void OnWindowLoad(object sender, RoutedEventArgs e)
        {
            firstnameTextBox.Text = staff.Firstname;
            lastnameTextBox.Text = staff.Lastname;
            emailTextBox.Text = staff.Email;
            phoneTextBox.Text = staff.Phone;
        }

        private void StaffInfo_Click(object sender, RoutedEventArgs e)
        {
            StaffDashboardWindow staffDashboardWindow = new StaffDashboardWindow(staff);
            staffDashboardWindow.Show();
            this.Close();  
        }

        private void ManageEvent_Click(object sender, RoutedEventArgs e)
        {
            ManageEventWindow manageEventWindow = new ManageEventWindow(staff);
            manageEventWindow.Show();
            this.Close();
        }

        private void ManageSellingRequest_Click(object sender, RoutedEventArgs e)
        {
            ManageSellingTicketRequestWindow manageSellingTicketRequestWindow = new ManageSellingTicketRequestWindow();
            manageSellingTicketRequestWindow.Show();
            this.Close();
        }

        private void ViewInfoUser_Click(object sender, RoutedEventArgs e)
        {
            ViewUserInfoWindow viewUserInfoWindow = new ViewUserInfoWindow(staff);
            viewUserInfoWindow.Show();
            this.Close();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
