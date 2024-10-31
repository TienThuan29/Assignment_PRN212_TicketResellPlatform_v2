using Service.Utils.TienThuan;
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
using Service.EventService;
using Service.TicketService;
using BusinessObject;

namespace Assignment_PRN212_TicketResellPlatform.UserWindows
{
    /// <summary>
    /// Interaction logic for AddingTicketWindow.xaml
    /// </summary>
    public partial class AddingTicketWindow : Window
    {
        private BusinessObject.User logedUser;

        private IEventService eventService = new EventService();
        private ICategoryService categoryService = new CategoryService();   


        public AddingTicketWindow()
        {
            InitializeComponent();
        }

        public AddingTicketWindow(BusinessObject.User user)
        {
            InitializeComponent();
            this.logedUser = user;
            this.InitDataOnWindow();
        }
        private void InitDataOnWindow()
        {
            Uri uri = new Uri(LocalPathSetting.ProfileImagePath + logedUser.Avatar, UriKind.Absolute);
            avatarImageBrush.ImageSource = new BitmapImage(uri);
            avatarImageBrushHeader.ImageSource = new BitmapImage(uri);
            // Init label
            fullnameLabel.Content = logedUser.Firstname + " " + logedUser.Lastname;
            fullnameHeaderLabel.Content = logedUser.Firstname + " " + logedUser.Lastname;
            balanceLabel.Content = balanceLabel.Content.ToString() + StringFormatUtil.FormatVND((long)logedUser.Balance);
            // Init combo box
            eventsComboBox.ItemsSource = eventService.GetAllEvents();
            eventsComboBox.DisplayMemberPath = "Name";
            eventsComboBox.SelectedValue = "Id";

            categoriesComboBox.ItemsSource = categoryService.GetAllCategories();
            categoriesComboBox.DisplayMemberPath = "Name";
            categoriesComboBox.SelectedValue = "Id";
        }


        private void ShowHomeWindow(object sender, RoutedEventArgs e)
        {
            this.Hide();
            HomeWindow homeWindow = new HomeWindow(logedUser);
            homeWindow.Show();
        }

        private void OpenAddSpecificTicketWindow(object sender, RoutedEventArgs e)
        {
            AddingSpecificTicketWindow addingSpecificTicketWindow = new AddingSpecificTicketWindow();
            addingSpecificTicketWindow.Show();
        }


        private void RefreshFields(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateGenericTicket(object sender, RoutedEventArgs e)
        {

        }

        private void CreateGenericTicket(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Create");
            try
            {
                GenericTicket genericTicket = new GenericTicket();
                genericTicket.SellerId = logedUser.Id;
                genericTicket.TicketName = gTicketNameTextbox.Text;
                genericTicket.Price = int.Parse(gTicketPriceTextbox.Text);
                genericTicket.SalePercent = int.Parse(gTicketSalePercentTextbox.Text);
                genericTicket.Area = gTicketAreaTextbox.Text;
                genericTicket.ExpiredDateTime = DateTime.Parse(gTicketExpiredDateTime.Text);
                genericTicket.LinkEvent = gTicketLinkTextbox.Text;
                genericTicket.CategoryId = int.Parse(categoriesComboBox.SelectedValue.ToString());
                //genericTicket.IsPaper = int.Parse(gTicketTypeComboBox.Tag == 1);
                var selectedItem = gTicketTypeComboBox.SelectedItem as ComboBoxItem;
                if (selectedItem != null && int.TryParse(selectedItem.Tag?.ToString(), out int tagValue))
                {
                    genericTicket.IsPaper = (tagValue == 1); // true if "Giấy" is selected, false otherwise
                }


                genericTicket.EventId = int.Parse(eventsComboBox.SelectedValue.ToString());
                genericTicket.Description = desTextbox.Text;
                Console.WriteLine(genericTicket);   
            }
            catch (Exception ex) { }
        }
    }
}
