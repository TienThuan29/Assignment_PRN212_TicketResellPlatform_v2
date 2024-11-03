using DataAccessObject;
using Service.EventService;
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

        public HomeWindow(BusinessObject.User user)
        {
            InitializeComponent();
            this.logedUser = user;
            this.InitOndataWindow();
        }
        public void InitOndataWindow()
        {
            if (!string.IsNullOrEmpty(logedUser.Avatar))
            {
                Uri uri = new Uri(LocalPathSetting.ProfileImagePath + logedUser.Avatar, UriKind.Absolute);
                avatarImageBrushHeader.ImageSource = new BitmapImage(uri);
            }
            //init lable
            fullnameHeaderLabel.Content = logedUser.Firstname + " " + logedUser.Lastname;
            //init event

            var events = eventService.GetAllEvents();
            foreach (var eventItem in events)
            {    if(!eventItem.Image.Contains(LocalPathSetting.EventImagePath))
                {
                   eventItem.Image = LocalPathSetting.EventImagePath + eventItem.Image;
                }        
                
            }

            mainEventList.ItemsSource = events;
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

            
            DetailEventWindow detailEventWindow = new DetailEventWindow(eventD, logedUser);
            detailEventWindow.Show();
            this.Close();
        }

        private void ShowPolicyWindow(object sender, RoutedEventArgs e)
        {
            PolicyWindow policyWindow = new PolicyWindow();
            policyWindow.Show();
        }
    }
}
