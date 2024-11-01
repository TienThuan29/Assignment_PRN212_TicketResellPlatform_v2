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
    /// Interaction logic for BuyTicketWindow.xaml
    /// </summary>
    public partial class BuyTicketWindow : Window
    {
        private BusinessObject.User LoggedUser;
        private BusinessObject.Event Event;
        private BusinessObject.Ticket Ticket;
        public BuyTicketWindow()
        {
            InitializeComponent();
        }

        public void InitDataOnWindow()
        {   //Init Lable
            fullnameLabel.Content = LoggedUser.Firstname + " " + LoggedUser.Lastname;
            //Init TextBox

        }

        public BuyTicketWindow(BusinessObject.Ticket ticket,BusinessObject.User loggedUser)
        {
            InitializeComponent();
            LoggedUser = loggedUser;
            Ticket = ticket;
            InitDataOnWindow();
        }

        private void ShowHomePageWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HomeWindow homeWindow = new HomeWindow(LoggedUser);
            homeWindow.Show();
        }
    }
}
