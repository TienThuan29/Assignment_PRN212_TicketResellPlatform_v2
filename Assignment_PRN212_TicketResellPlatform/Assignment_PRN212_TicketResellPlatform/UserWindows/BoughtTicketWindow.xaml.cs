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
using Assignment_PRN212_TicketResellPlatform.UserWindows.CustomDialog;
using BusinessObject;
using Service.User;

namespace Assignment_PRN212_TicketResellPlatform.UserWindows
{
    public partial class BoughtTicketWindow : Window
    {
        private BusinessObject.User logedUser;

        private IOrderTicketService orderTicketService = new OrderTicketService();

        private ITicketService ticketService = new TicketService();

        private IUserService userService = new UserService();

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


        private void ViewOrderDetail(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is string orderNo)
            {
                //MessageBox.Show($"Detail Order No: {orderNo}");
                OrderTicket orderTicket = orderTicketService.GetOrderTicketByOrderNo(orderNo);
                if (orderTicket.IsAccepted == false && !string.IsNullOrEmpty(orderTicket.Note))
                {
                    ShowErrorMessageBox("Đơn hàng này đã bị từ chối bởi người bán!");
                }
                else if (orderTicket.IsCanceled == true)
                {
                    ShowErrorMessageBox("Đơn hàng này đã được hủy!");
                }
                else if (orderTicket.IsAccepted == true)
                {
                    ICollection<Ticket> boughtTicketsOfBuyer = ticketService.FindByGenericTicketID(orderTicket.GenericTicketId).Where(
                        ticket => ticket.BuyerId.Equals(logedUser.Id)
                    ).ToList();
                    foreach (Ticket ticket in boughtTicketsOfBuyer)
                    {
                        if (!ticket.Image.Contains(LocalPathSetting.TicketImagePath))
                            ticket.Image = LocalPathSetting.TicketImagePath + ticket.Image;
                    }
                    ViewBoughtTicketsOfOrder viewBoughtTicketsOfOrder = new ViewBoughtTicketsOfOrder(boughtTicketsOfBuyer);
                    viewBoughtTicketsOfOrder.Show();
                }
                else
                {
                    ShowErrorMessageBox("Có một vài sự cố xảy ra!!!");
                }
            }
        }


        private void CancelOrder(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is string orderNo)
            {
                //MessageBox.Show($"Canceled Order No: {orderNo}");
                OrderTicket orderTicket = orderTicketService.GetOrderTicketByOrderNo(orderNo);
                if (orderTicket.IsAccepted == false && !string.IsNullOrEmpty(orderTicket.Note))
                {
                    ShowErrorMessageBox("Đơn hàng này đã bị từ chối bởi người bán!");
                }
                else if (orderTicket.IsCanceled == true)
                {
                    ShowErrorMessageBox("Đơn hàng này đã được hủy!");
                }
                else if (orderTicket.IsAccepted == true)
                {
                    ShowInfoMessageBox("Đơn này đã hoàn thành");
                }
                else
                {
                    switch(MessageBox.Show("Xác nhận hủy đơn hàng?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question))
                    {
                        case MessageBoxResult.Yes:
                            orderTicket.IsCanceled = true;
                            orderTicketService.UpdateOrderTicket(orderTicket);
                            logedUser.Balance += orderTicket.TotalPrice;
                            userService.SaveProfile(logedUser);
                            ShowInfoMessageBox("Hủy đon hàng thành công!");
                            break;
                        case MessageBoxResult.No:
                            break;
                    }
                }
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
            MainWindow mainWindow = new MainWindow();   
            this.Hide();
            mainWindow.Show();
        }

        private void ToChangePasswordWindow(object sender, RoutedEventArgs e)
        {
            ChangePasswordWindow changePasswordWindow = new ChangePasswordWindow(logedUser);
            this.Hide();
            changePasswordWindow.Show();
        }

        private void ToManageBalanceWindow(object sender, RoutedEventArgs e)
        {
            BalanceManagementWindow balanceManagementWindow = new BalanceManagementWindow(logedUser);
            this.Hide();
            balanceManagementWindow.Show();
        }

        private void ToMyShopWindow(object sender, RoutedEventArgs e)
        {
            MyShopWindow myShopWindow = new MyShopWindow(logedUser);
            this.Hide();
            myShopWindow.Show();
        }


        private void ToUserProfileWindow(object sender, RoutedEventArgs e)
        {
            UserProfileWindow userProfileWindow = new UserProfileWindow(logedUser);
            this.Hide();
            userProfileWindow.Show();
        }

        private void ShowHomeWindow(object sender, RoutedEventArgs e)
        {
            HomeWindow homeWindow = new HomeWindow(logedUser);
            this.Hide();
            homeWindow.Show();
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
    }
}
