using Service.EventService;
using Service.TicketService;
using Service.TicketService;
using Service.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
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
    /// Interaction logic for DetailEventWindow.xaml
    /// </summary>
    public partial class DetailEventWindow : Window
    {   private readonly ITicketService ticketService = new TicketService();
        private readonly IGenericTicketService genericTicketService = new GenericTicketService();
        private readonly IEventService eventService = new EventService();
        private BusinessObject.User LoggedUser;
        private BusinessObject.Event Event;
        public DetailEventWindow()
        {
            InitializeComponent();
        }

        public DetailEventWindow(BusinessObject.Event @event, BusinessObject.User loggedUser)
        {
            InitializeComponent();
            Event = @event;
            LoggedUser = loggedUser;

            InitDataOnWindow();         
        }

        public void InitDataOnWindow()
        {   //Init Lable
            fullnameLabel.Content = LoggedUser.Firstname + " " + LoggedUser.Lastname;
            //Init TextBox

            //txtEventNameTextBox.Text = Event.Name;
            //txtEventDescriptionTextBox.Text = Event.Detail;
            //txtStartDateTextBox.Text= Event.StartDate.ToString();
            //txtEndDateTextBox.Text= Event.EndDate.ToString();

            // Add image path
            Event.Image = System.IO.Path.Combine(LocalPathSetting.EventImagePath, Event.Image);

            // Set DataContext for binding
            EventDetailBox.DataContext = Event;

            //Init Ticket On sell
            var tickets = genericTicketService.FindTicketByEventId(Event.Id);
            if (tickets == null || !tickets.Any())
            {
                MessageBox.Show("No tickets found for this event.");
            }
            TicketGridData.ItemsSource = tickets;

            //Uri uri = new Uri(LocalPathSetting.EventImagePath+Event.Image, UriKind.Absolute);
            //txtImageEvent.Source = new BitmapImage(uri);

            //Uri uri = new Uri(System.IO.Path.Combine(LocalPathSetting.EventImagePath, Event.Image), UriKind.Absolute);
            //txtImageEvent.Source = new BitmapImage(uri);



        }

        private void ShowHomePageWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HomeWindow homeWindow = new HomeWindow(LoggedUser);
            homeWindow.Show();
        }

        private void ShowBuyTicketWindow(object sender, RoutedEventArgs e)
        {
            var ticketId = (long)((Button)sender).Tag;

            var ticketD = genericTicketService.FindGenericTicketById(ticketId);
            this.Hide();
            BuyTicketWindow buyTicketWindow = new BuyTicketWindow(ticketD, LoggedUser);
            buyTicketWindow.Show();
        }
    }
}
