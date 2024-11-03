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
using Service.TicketService;

namespace Assignment_PRN212_TicketResellPlatform.UserWindows
{
    public partial class BoughtTicketWindow : Window
    {
        private BusinessObject.User logedUser;

        private IOrderTicketService orderTicketService = new OrderTicketService();

        public BoughtTicketWindow()
        {
            InitializeComponent();
        }

        public BoughtTicketWindow(BusinessObject.User user)
        {
            InitializeComponent();
            this.logedUser = user;
            InitDataWindow();
        }


        private void CancelOrder(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is string orderNo)
            {
                MessageBox.Show($"Canceled Order No: {orderNo}");
            }
        }

        private void InitDataWindow()
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
            ReloadDataGrid();
        }

        private void ReloadDataGrid()
        {
            orderTicketDataGrid.ItemsSource = orderTicketService.GetAllOrderTicketsByBuyer(logedUser.Id);
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            
        }

        private void ToChangePasswordWindow(object sender, RoutedEventArgs e)
        {

        }

        private void ToManageBalanceWindow(object sender, RoutedEventArgs e)
        {

        }

        private void ToMyShopWindow(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ToUserProfileWindow(object sender, RoutedEventArgs e)
        {

        }

        private void ShowHomeWindow(object sender, RoutedEventArgs e)
        {

        }
    }
}
