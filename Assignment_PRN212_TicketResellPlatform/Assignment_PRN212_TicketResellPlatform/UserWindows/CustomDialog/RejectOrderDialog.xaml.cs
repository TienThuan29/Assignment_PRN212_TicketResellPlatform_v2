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

namespace Assignment_PRN212_TicketResellPlatform.UserWindows.CustomDialog
{
    public partial class RejectOrderDialog : Window
    {
        private string orderNo;
        private IOrderTicketService orderTicketService;

        public RejectOrderDialog()
        {
            InitializeComponent();
        }

        public RejectOrderDialog(IOrderTicketService orderTicketService, string orderNo)
        {
            InitializeComponent();
            this.orderNo = orderNo; 
            this.orderTicketService = orderTicketService;
        }

        private void Confirm(object sender, RoutedEventArgs e)
        {
            string note = reasonTextbox.Text; ;
            if (string.IsNullOrWhiteSpace(note))
            {
                ShowErrorMessageBox("Bạn không được để trống lý do từ chối!");
            }
            else
            {
                if (orderTicketService.RejectOrder(this.orderNo, note))
                {
                    ShowInfoMessageBox("Từ chối đơn hàng thành công!");
                    this.Close();
                }
                else
                {
                    ShowErrorMessageBox("Từ chối đơn hàng thất bại");
                }
            }
        }

        private void CancelWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
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
