using BusinessObject;
using Service.TicketService;
using Service.Utils;
using Service.Utils.NhatTruong;
using Service.Utils.TienThuan;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Assignment_PRN212_TicketResellPlatform.StaffWindows
{
    /// <summary>
    /// Interaction logic for GenericTicketDetailWindow.xaml
    /// </summary>
    public partial class GenericTicketDetailWindow : Window
    {
        private GenericTicket genericTicket;
        private ITicketService ticketService;
        private ManageSellingTicketRequestWindow manageSellingTicketRequestWindow;
        private Staff staff;

        public GenericTicketDetailWindow()
        {
            InitializeComponent();
        }

        public GenericTicketDetailWindow(GenericTicket genericTicket,ManageSellingTicketRequestWindow manageSellingTicketRequestWindow, Staff staff)
        {
            InitializeComponent();
            this.manageSellingTicketRequestWindow = manageSellingTicketRequestWindow;
            this.genericTicket = genericTicket;
            this.ticketService = new TicketService();
            SetInfoGeneric();
            this.staff = staff;
        }

        //Setup
        private void SetInfoGeneric()
        {
            txtGenericName.Text = genericTicket.TicketName;
            txtArea.Text = genericTicket.Area;
            txtCategory.Text = genericTicket.Category.Name;
            txtDescription.Text = genericTicket.Description;
            txtLinkEvent.Text = genericTicket.LinkEvent;
            txtPrice.Text = StringFormatUtil.FormatVND(genericTicket.Price);
            txtTypeTicket.Text = genericTicket.IsPaper.Value ? "Vé vật lý" : "Vé điện tử";
            setUpTicketGrid();
        }

        private void setUpTicketGrid()
        {
            var tickets = ticketService.FindByRequestSellingGenericTicket(genericTicket.Id);
            foreach (var ticket in tickets)
            {
                if (ticket != null && !ticket.Image.Contains(LocalPathSetting.TicketImagePath))
                {
                    ticket.Image = LocalPathSetting.TicketImagePath+ticket.Image;
                }
            }
            TicketGrid.ItemsSource = tickets;    
        }

        //Action button
        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                long ticketId = (long)button.Tag;

                InputBox inputBox = new InputBox();
                if (inputBox.ShowDialog() == true)
                {
                    string note = inputBox.InputMessage;
                    ticketService.AcceptTicketSelling(ticketId, staff.Id, note);
                }
            }
            setUpTicketGrid();
        }

        private void btnReject_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                long ticketId = (long)button.Tag;

                InputBox inputBox = new InputBox();
                if (inputBox.ShowDialog() == true)
                {
                    string note = inputBox.InputMessage;
                    ticketService.RejectTicketSelling(ticketId, staff.Id, note);
                }
            }
            setUpTicketGrid();
        }

        //Popup image
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Image img)
            {
                PopupImage.Source = img.Source;
                ImagePopup.IsOpen = true;
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            manageSellingTicketRequestWindow.loadData();
            this.Close();
        }
    }
}
