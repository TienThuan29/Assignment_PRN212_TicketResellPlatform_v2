using BusinessObject;
using Service.TicketService;
using Service.TicketService;
using Service.Utils;
using Service.Utils.TienThuan;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
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
    public partial class MyShopWindow : Window
    {
        private BusinessObject.User logedUser;

        private IGenericTicketService genericTicketService = new GenericTicketService();

        private ITicketService ticketService = new TicketService();


        public MyShopWindow()
        {
            InitializeComponent();
        }

        public MyShopWindow(BusinessObject.User logedUser)
        {
            InitializeComponent();
            this.logedUser = logedUser;
            this.InitDataOnWindow();
        }

        private void InitDataOnWindow()
        {
            if (!string.IsNullOrEmpty(logedUser.Avatar))
            {
                Uri uri = new Uri(LocalPathSetting.ProfileImagePath + logedUser.Avatar, UriKind.Absolute);
                avatarImageBrush.ImageSource = new BitmapImage(uri);
                avatarImageBrushHeader.ImageSource = new BitmapImage(uri);
            }
            fullnameLabel.Content = logedUser.Firstname + " " + logedUser.Lastname;
            fullnameHeaderLabel.Content = logedUser.Firstname + " " + logedUser.Lastname;
            balanceLabel.Content = balanceLabel.Content.ToString() + StringFormatUtil.FormatVND((long)logedUser.Balance);
        }

        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            List<GenericTicket> genericTickets = (List<GenericTicket>)genericTicketService.FindBySellerId(logedUser.Id);
            List<Ticket> tickets = new List<Ticket>();
            foreach (GenericTicket genTicket in genericTickets)
            {
                tickets.AddRange(
                    ticketService.FindByGenericTicketID(genTicket.Id)
                );
            }
            ticketDataGrid.ItemsSource = tickets;
        }



        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the TicketSerial using the Tag property of the Button
            var button = sender as System.Windows.Controls.Button;
            string ticketSerial = button?.Tag.ToString();

            if (!string.IsNullOrEmpty(ticketSerial))
            {
                MessageBox.Show($"Ticket Serial: {ticketSerial}", "Edit Action", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


        private void ViewNoteButton(object sender, RoutedEventArgs e)
        {
            // Retrieve the Note using the Tag property of the Button
            var button = sender as Button;
            string note = button?.Tag?.ToString();

            if (!string.IsNullOrEmpty(note))
            {
                MessageBox.Show(note, "Note", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("No note available.", "Note", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ViewDetailTicket(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            string ticketId = button?.Tag?.ToString();
            if (!string.IsNullOrEmpty(ticketId))
            {
                ViewTicketDetailWindow viewTicketDetailWindow = new  ViewTicketDetailWindow(long.Parse(ticketId));
                viewTicketDetailWindow.Show();
            }
        }


        // Rediect to other window
        private void ToAddingTicketWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddingTicketWindow addingTicketWindow = new AddingTicketWindow(logedUser);
            addingTicketWindow.Show();
        }

        private void ToUserProfileWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            UserProfileWindow userProfileWindow = new UserProfileWindow(logedUser);
            userProfileWindow.Show();
        }


        private void ShowHomeWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HomeWindow mainWindow = new HomeWindow(logedUser);
            mainWindow.Show();
        }

        private void ToManageBalanceWindow(object sender, RoutedEventArgs e)
        {
            BalanceManagementWindow balanceManagementWindow = new BalanceManagementWindow(logedUser);
            this.Hide();
            balanceManagementWindow.Show();
        }

        private void ToChangePasswordWindow(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow(logedUser);
            this.Hide();
            changePasswordWindow.Show();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            this.Hide();
            mainWindow.Show();  
        }

        private void ToOrderTicketWindow(object sender, RoutedEventArgs e)
        {
            OrderTicketRequestWindow orderTicketRequestWindow = new OrderTicketRequestWindow(logedUser);
            this.Hide();
            orderTicketRequestWindow.Show();
        }
    }
}
