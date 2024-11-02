using BusinessObject;
using Repository.Impl;
using Service.TicketService;
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
        private BusinessObject.GenericTicket GenericTicket;
        private ITicketService ticketService = new TicketService();
        private IOrderTicketService orderTicketService = new OrderTicketService();
        public BuyTicketWindow()
        {
            InitializeComponent();
        }

        public void InitDataOnWindow()
        {   //Init Lable
            fullnameLabel.Content = LoggedUser.Firstname + " " + LoggedUser.Lastname;
            //Init TextBox
            var tickets = ticketService.FindSellingTicket(GenericTicket.Id);
            var quantity = tickets.Count();
            GenericTicketBox.DataContext = GenericTicket;
            txtQuantity.Text = quantity.ToString();

        }

        public BuyTicketWindow(BusinessObject.GenericTicket genericTicket,BusinessObject.User loggedUser)
        {
            InitializeComponent();
            LoggedUser = loggedUser;
            GenericTicket = genericTicket;
            InitDataOnWindow();
        }

        private void ShowHomePageWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HomeWindow homeWindow = new HomeWindow(LoggedUser);
            homeWindow.Show();
        }

        private void Button_Buy(object sender, RoutedEventArgs e)
        {
            var tickets = ticketService.FindSellingTicket(GenericTicket.Id);
            var quantity = tickets.Count();
            if(orderTicketService.OrderTicket(GenericTicket.Id, quantity, LoggedUser))
            {
                MessageBox.Show("Mua thành công");
            }
            else
            {
                MessageBox.Show("Không đủ tiền");
            }
        }

        private int selectedQuantity = 1;

        private void DecreaseQuantity_Click(object sender, RoutedEventArgs e)
        {   
            var quantity = ticketService.FindSellingTicket(GenericTicket.Id).Count();
            if (selectedQuantity > quantity)
            {
                selectedQuantity--;
                quantitySelector.Text = selectedQuantity.ToString();
            }
        }

        private void IncreaseQuantity_Click(object sender, RoutedEventArgs e)
        {
            var quantity = ticketService.FindSellingTicket(GenericTicket.Id).Count();
            if (selectedQuantity < quantity)
            {
                selectedQuantity++;
                quantitySelector.Text = selectedQuantity.ToString();
            }

        }

    }
}
