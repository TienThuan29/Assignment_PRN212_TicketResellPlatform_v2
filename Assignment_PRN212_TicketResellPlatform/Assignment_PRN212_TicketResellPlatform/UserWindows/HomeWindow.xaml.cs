using DataAccessObject;
using Service.EventService;
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
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : Window
    {   private IEventService eventService = new EventService();
        private BusinessObject.User logedUser;
        public HomeWindow()
        {
            InitializeComponent();        
        }

        public HomeWindow(BusinessObject.User LogedUser)
        {
            InitializeComponent();
            this.logedUser = LogedUser;
            this.InitOndataWindow();
        }
        public void InitOndataWindow()
        {
            //init lable
            fullnameHeaderLabel.Content = logedUser.Firstname + " " + logedUser.Lastname;
        }

        public void OnWindowLoad(object sender, RoutedEventArgs e)
        {
            mainEventList.ItemsSource = eventService.GetAllEvents();
        }

        private void ShowUserProfileWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            UserProfileWindow userProfileWindow = new UserProfileWindow(logedUser);
            userProfileWindow.Show();
        }

        private void ShowDetailEventWindow(object sender, RoutedEventArgs e)
        {
            var eventId = (int)((Button)sender).Tag;

            var eventD = eventService.GetEvent(eventId);

            this.Hide();
            DetailEventWindow detailEventWindow = new DetailEventWindow(eventD, logedUser);
            detailEventWindow.Show();
        }

    }
}
