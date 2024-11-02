using BusinessObject;
using Microsoft.Win32;
using Service.Ticket;
using Service.TicketService;
using Service.User;
using Service.Utils;
using Service.Utils.TienThuan;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;


namespace Assignment_PRN212_TicketResellPlatform.UserWindows
{
    public partial class AddingSpecificTicketWindow : Window
    {
        private GenericTicket addedGenericTicket;
        private ICollection<Ticket> addedTickets = new List<Ticket>();

        private ITicketService ticketService = new TicketService();

        private string currentFullFilePath;

        public AddingSpecificTicketWindow()
        {
            InitializeComponent();
        }

        public AddingSpecificTicketWindow(GenericTicket addedGenericTicket)
        {
            InitializeComponent();
            this.addedGenericTicket = addedGenericTicket;   
        }

        private void BrowseTicketImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == true)
            {
                try
                {
                    string fullFilename = fileDialog.FileName;
                    ticketImage.Source = new BitmapImage(new Uri(fullFilename, UriKind.Absolute));
                    this.currentFullFilePath = fullFilename;
                    /*FileInfo fileInfo = new FileInfo(fullFilename);
                    string filename = System.IO.Path.GetFileName(fullFilename) + RandomUtil.RandomString(7);
                    fileInfo.CopyTo(LocalPathSetting.TicketImagePath + filename);*/
                }
                catch (Exception ex)
                {

                }
            }
        }

        private void AddTicket(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(ticketSerialTextbox.Text) && ! string.IsNullOrEmpty(currentFullFilePath))
                {
                    bool ticketSerialIsAdded = false;
                    foreach(Ticket t in addedTickets)
                    {
                        if (t.TicketSerial.Equals(ticketSerialTextbox.Text)) ticketSerialIsAdded |= true;   
                    }
                    if (!ticketSerialIsAdded) 
                    {
                        FileInfo fileInfo = new FileInfo(currentFullFilePath);
                        string filename = System.IO.Path.GetFileName(currentFullFilePath);
                        if (!File.Exists(currentFullFilePath))
                        {
                            fileInfo.CopyTo(LocalPathSetting.TicketImagePath + filename);
                        }

                        Ticket ticket = new Ticket();
                        ticket.TicketSerial = ticketSerialTextbox.Text;
                        ticket.Image = filename;
                        ticket.Process = GeneralProcess.WAITING;
                        ticket.GenericTicketId = addedGenericTicket.Id;
                        ticket.IsBought = false;
                        ticket.IsChecked = false;
                        ticket.IsValid = false;
                        // This line to handle Staff id to verify ticket
                        this.addedTickets.Add(ticket);
                        // save db
                        if (ticketService.AddTicket(ticket)) 
                        {
                            ShowInfoMessageBox("Thêm thành công!");
                        }
                    }
                    else
                    {
                        ShowWarningMessageBox("Vé này đã được thêm vào!");
                    }
                }
                else
                {
                    ShowWarningMessageBox("Bạn phải điền đầy đủ thông tin để thêm vé!");
                }
            }
            catch(Exception ex)
            {
                ShowErrorMessageBox("Thêm vé không thành công!");
            }
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            this.addedGenericTicket = null;
            this.addedTickets.Clear();
            this.currentFullFilePath = null;
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
