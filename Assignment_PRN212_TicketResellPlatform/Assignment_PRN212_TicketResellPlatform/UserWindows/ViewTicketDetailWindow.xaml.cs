using System.Windows;
using System.Windows.Media.Imaging;
using BusinessObject;
using Service.TicketService;
using Service.Utils;
using Service.Utils.TienThuan;

namespace Assignment_PRN212_TicketResellPlatform.UserWindows
{
    public partial class ViewTicketDetailWindow : Window
    {
        private Ticket choosenTicket;

        private ITicketService ticketService = new TicketService();

        private IGenericTicketService genericTicketService = new GenericTicketService();    

        private ICategoryService categoryService = new CategoryService();

        public ViewTicketDetailWindow(long ticketId)
        {
            InitializeComponent();
            InitDataWindow(ticketId);
        }

        public void InitDataWindow(long ticketId)
        {
            this.choosenTicket = ticketService.GetTicketById(ticketId);
            GenericTicket genericTicket = genericTicketService.FindGenericTicketById((long)choosenTicket.GenericTicketId);
            Category category = categoryService.GetCategoryById((int)genericTicket.CategoryId);
            ticketNameLabel.Content += genericTicket.TicketName;
            expiredDateLabel.Content += genericTicket.ExpiredDateTime.ToString();
            priceLable.Content += StringFormatUtil.FormatVND(genericTicket.Price);
            areaLabel.Content += genericTicket.Area;
            ticketTypeLabel.Content += (bool)genericTicket.IsPaper ? " Giấy" : "Online";
            descriptionTextBlock.Text += genericTicket.Description;
            ticketSerialLabel.Content += choosenTicket.TicketSerial;
            processLabel.Content += ProcessGenerator.GeneralProcessToName(choosenTicket.Process);
            noteTextBlock.Text += choosenTicket.Note;

            ticketImage.Source = new BitmapImage(new Uri(LocalPathSetting.TicketImagePath +  choosenTicket.Image));

            if ((bool)choosenTicket.IsBought)
            {
                markBoughtBtn.IsEnabled = false;
            }
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MarkBought(object sender, RoutedEventArgs e)
        {
            switch (
                MessageBox.Show("Xác nhận vé đã bán?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Question)
            )
            {
                case MessageBoxResult.Yes:
                    if (ticketService.MarkBought(choosenTicket.Id))
                    {
                        ShowInfoMessageBox("Đánh dấu đã mua thành công!");
                    }
                    else
                    {
                        ShowErrorMessageBox("Đánh dấu vé không thành công! Vui lòng thử lại!");
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }
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
