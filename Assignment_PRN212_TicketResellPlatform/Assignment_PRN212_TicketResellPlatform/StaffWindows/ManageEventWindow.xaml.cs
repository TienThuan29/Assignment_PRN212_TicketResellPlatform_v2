using BusinessObject;
using Service.EventService;
using Service.Utils.NhatTruong;
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
    /// Interaction logic for ManageEventWindow.xaml
    /// </summary>
    public partial class ManageEventWindow : Window
    {
        private readonly IEventService eventService;
        private readonly Staff staff;
        public ManageEventWindow()
        {
            InitializeComponent();
            eventService = new EventService();
        }

        public ManageEventWindow(Staff staff)
        {
            InitializeComponent();
            eventService = new EventService();
            this.staff = staff;
        }

        public void LoadData()
        {
            EventGrid.ItemsSource = eventService.GetAllEvents();
        }

        public void OnWindowLoad(object sender, RoutedEventArgs e)
        {
            EventGrid.ItemsSource = eventService.GetAllEvents();
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

        //Action button
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            Event EventDetail = null;
            Button button = sender as Button;
            if (button != null)
            {
                EventDetail = eventService.GetEvent((int)button.Tag);
            }
            EventDetailWindow eventDetailWindow = new EventDetailWindow(EventDetail, ACTION.UPDATE, this);
            eventDetailWindow.Show();
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            Event EventDetail = null;
            Button button = sender as Button;
            if (button != null) 
            {
                EventDetail = eventService.GetEvent((int)button.Tag);                      
            }
            EventDetailWindow eventDetailWindow = new EventDetailWindow(EventDetail, ACTION.DEATAIL, this);
            eventDetailWindow.Show();
        }

        private void btnAddEvent_Click(object sender, RoutedEventArgs e)
        {
            EventDetailWindow eventDetailWindow = new EventDetailWindow(null, ACTION.ADD, this);
            eventDetailWindow.Show();
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

        //Search Event Name
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            EventGrid.ItemsSource = eventService.SearchEventsByName(txtSearch.Text);
        }
    }
}
