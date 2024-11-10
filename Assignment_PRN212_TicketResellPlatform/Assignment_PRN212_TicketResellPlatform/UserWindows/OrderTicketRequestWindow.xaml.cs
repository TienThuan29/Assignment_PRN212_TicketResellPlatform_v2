using BusinessObject;
using Service.Utils.TienThuan;
using Service.Utils;
using System.Windows;
using System.Windows.Media.Imaging;
using Service.TicketService;
using System.Windows.Controls;
using Assignment_PRN212_TicketResellPlatform.UserWindows.CustomDialog;
using Service.TransactionService;


namespace Assignment_PRN212_TicketResellPlatform.UserWindows
{
    public partial class OrderTicketRequestWindow : Window
    {
        private  BusinessObject.User logedUser;
        private IOrderTicketService orderTicketService = new OrderTicketService(); 
        private ITicketService ticketService = new TicketService();
        private ITransactionService transactionService = new TransactionService();  

        public OrderTicketRequestWindow(BusinessObject.User user)
        {
            InitializeComponent();
            this.logedUser = user;
            InitDataWindow();
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
            orderTicketDataGrid.ItemsSource = orderTicketService.GetAllOrderTicketsBySeller(logedUser.Id);
        }

        private void AcceptOrder(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is string orderNo)
            {
                //MessageBox.Show($"Accepted Order No: {orderNo}");
                OrderTicket orderTicket = orderTicketService.GetOrderTicketByOrderNo(orderNo);
                if (orderTicket.IsAccepted == false && !string.IsNullOrEmpty(orderTicket.Note))
                {
                    ShowErrorMessageBox("Đơn hàng này đã được từ chối!");
                }
                else if (orderTicket.IsAccepted == true)
                {
                    ShowErrorMessageBox("Đơn hàng này đã được xác nhận!");
                }
                else if (orderTicket.IsCanceled == true)
                {
                    ShowErrorMessageBox("Đơn hàng này đã bị hủy bởi người mua!");
                }
                else
                {
                    switch(MessageBox.Show("Xác nhận bán vé cho đơn hàng?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question))
                    {
                        case MessageBoxResult.Yes:
                            // Check quantity
                            ICollection<Ticket> sellingTickets = ticketService.FindSellingTicket(orderTicket.GenericTicketId);
                            if (orderTicket.Quantity <= sellingTickets.Count)
                            {
                                // Auto transact tickets to buyer
                                for (int i = 1; i <= orderTicket.Quantity; i++)
                                {
                                    Ticket sellingTicket = sellingTickets.ElementAt(i - 1);
                                    sellingTicket.IsBought = true;
                                    sellingTicket.BuyerId = orderTicket.BuyerId;
                                    sellingTicket.BoughtDate = DateTime.Now;
                                    sellingTicket.Process = GeneralProcess.SUCCESS;
                                    ticketService.UpdateBoughtTicket(sellingTicket);
                                }
                                // Update order ticket
                                orderTicket.IsAccepted = true;
                                orderTicketService.UpdateOrderTicket(orderTicket);
                                // Save transaction
                                transactionService.SaveBuyingTransaction(orderTicket.BuyerId, (long)orderTicket.TotalPrice);
                                transactionService.SaveSellingTransaction(logedUser.Id, (long)orderTicket.TotalPrice);
                                ShowInfoMessageBox("Đã chuyển vé đến người mua thành công!");
                            }
                            else
                            {
                                ShowErrorMessageBox("Không đủ số lượng vé cho đơn hàng này!");
                            }
                            break;
                        case MessageBoxResult.No:

                            break;
                    }
                    
                }
            }
        }

        private void RejectOrder(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is string orderNo)
            {
                //MessageBox.Show($"Rejected Order No: {orderNo}");
                OrderTicket orderTicket = orderTicketService.GetOrderTicketByOrderNo(orderNo);
                if (orderTicket.IsAccepted == false && !string.IsNullOrEmpty(orderTicket.Note)) 
                {
                    ShowErrorMessageBox("Đơn hàng này đã được từ chối!");
                }
                else if (orderTicket.IsAccepted == true)
                {
                    ShowErrorMessageBox("Đơn hàng này đã được xác nhận!");
                }
                else if (orderTicket.IsCanceled == true)
                {
                    ShowErrorMessageBox("Đơn hàng này đã bị hủy bởi người mua!");
                }
                else
                {
                    RejectOrderDialog rejectOrderDialog = new RejectOrderDialog(this.orderTicketService, orderNo);
                    rejectOrderDialog.Show();
                }
            }
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
            this.Hide();
            HomeWindow homeWindow = new HomeWindow(logedUser);
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

        private void HandleLogout(object sender, RoutedEventArgs e)
        {

        }
    }
}
