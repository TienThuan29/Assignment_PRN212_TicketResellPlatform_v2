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
    /// Interaction logic for DetailEventWindow.xaml
    /// </summary>
    public partial class DetailEventWindow : Window
    {
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
            txtEventNameTextBox.Text = Event.Name;
            txtEventDescriptionTextBox.Text = Event.Detail;
            txtStartDateTextBox.Text= Event.StartDate.ToString();
            txtEndDateTextBox.Text= Event.EndDate.ToString();
            
        }

        private void ShowHomePageWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HomeWindow homeWindow = new HomeWindow(LoggedUser);
            homeWindow.Show();
        }
    }
}
