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

    public partial class AddingTicketWindow : Window
    {
        private BusinessObject.User logedUser;

        private IEventService eventService = new EventService();
        private ICategoryService categoryService = new CategoryService();
        private IGenericTicketService genericTicketService = new GenericTicketService();

        private GenericTicket currentAddingGenericTicket;

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
            if (!string.IsNullOrEmpty(logedUser.Avatar))
            {
                Uri uri = new Uri(LocalPathSetting.ProfileImagePath + logedUser.Avatar, UriKind.Absolute);
                avatarImageBrush.ImageSource = new BitmapImage(uri);
                avatarImageBrushHeader.ImageSource = new BitmapImage(uri);
            }
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
            if(this.currentAddingGenericTicket != null)
            {
                AddingSpecificTicketWindow addingSpecificTicketWindow = new AddingSpecificTicketWindow(currentAddingGenericTicket);
                addingSpecificTicketWindow.Show();
            }
            else
            {
                ShowErrorMessageBox("Bạn cần tạo thông tin vé trước khi thêm vé chi tiết!");
            }
        }


        private void RefreshFields(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateGenericTicket(object sender, RoutedEventArgs e)
        {

        }

        private void CreateGenericTicket(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ValidateReuiredFields())
                {
                    GenericTicket genericTicket = new GenericTicket();
                    genericTicket.SellerId = logedUser.Id;
                    genericTicket.TicketName = gTicketNameTextbox.Text;
                    genericTicket.Price = int.Parse(gTicketPriceTextbox.Text);
                    /*genericTicket.SalePercent = int.Parse(
                        gTicketSalePercentTextbox.Text.Trim().Equals("") ? "0" : gTicketSalePercentTextbox.Text
                    );*/
                    genericTicket.SalePercent = 0;
                    genericTicket.Area = gTicketAreaTextbox.Text;
                    genericTicket.ExpiredDateTime = DateTime.Parse(gTicketExpiredDateTime.Text);
                    genericTicket.LinkEvent = gTicketLinkTextbox.Text;
                    genericTicket.CategoryId = int.Parse(categoriesComboBox.SelectedValue.ToString());
                    //genericTicket.IsPaper = int.Parse(gTicketTypeComboBox.Tag == 1);
                    var selectedItem = gTicketTypeComboBox.SelectedItem as ComboBoxItem;
                    if (selectedItem != null && int.TryParse(selectedItem.Tag?.ToString(), out int tagValue))
                    {
                        genericTicket.IsPaper = (tagValue == 1);
                    }
                    genericTicket.EventId = int.Parse(eventsComboBox.SelectedValue.ToString());
                    genericTicket.Description = desTextbox.Text;
                    currentAddingGenericTicket = genericTicket;
                    if (genericTicketService.AddGenericTicket(genericTicket))
                    {
                        ShowInfoMessageBox("Tạo vé thành công! Bạn hay thêm vé chi tiết");
                    }
                    else
                    {
                        ShowErrorMessageBox("Tạo vé thất bại! Vui lòng thử lại!");
                    }
                }
            }
            catch (Exception ex) 
            {
                ShowErrorMessageBox("Tạo vé thất bại! Vui lòng kiểm tra các mục nhập!");
            }
        }

        private bool ValidateReuiredFields()
        {
            if (string.IsNullOrWhiteSpace(gTicketNameTextbox.Text))
            {
                ShowWarningMessageBox("Không được để trống tên vé");
                return false;
            }

            if (string.IsNullOrWhiteSpace(gTicketPriceTextbox.Text))
            {
                ShowWarningMessageBox("Không được để trống giá vé!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(gTicketExpiredDateTime.Text))
            {
                ShowWarningMessageBox("Không được để trống thời gian hết hạn!");
                return false;
            }

            if (categoriesComboBox.SelectedValue == null)
            {
                ShowWarningMessageBox("Không được để trống thể loại vé!");
            }

            if (eventsComboBox.SelectedValue == null)
            {
                ShowWarningMessageBox("Không được để trống sự kiện!");
                return false;
            }
            return true;
        }

        private void ToMyShopWindow(object sender, RoutedEventArgs e)
        {
            MyShopWindow myShopWindow = new MyShopWindow(logedUser);
            this.Hide();
            myShopWindow.Show();
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

        public void ShowWarningMessageBox(string message)
        {
            MessageBox.Show(message, "Cảnh báo", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        
    }
}
