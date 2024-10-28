﻿using BusinessObject;
using Service.Ticket;
using Service.TicketService;
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
    /// <summary>
    /// Interaction logic for MyShopWindow.xaml
    /// </summary>
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
    }

    // Window Resource Image Converter
    public class ByteArrayToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                if (value is byte[] byteArray && byteArray.Length > 0)
                {
                    using (var stream = new MemoryStream(byteArray))
                    {
                        BitmapImage image = new BitmapImage();
                        image.BeginInit();
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.StreamSource = stream;
                        image.EndInit();
                        image.Freeze(); // Freeze for performance
                        return image;
                    }
                }
                else
                {
                    MessageBox.Show("The image data is null or empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (NotSupportedException ex)
            {
                MessageBox.Show($"Unsupported image format: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Invalid image data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error loading image: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
