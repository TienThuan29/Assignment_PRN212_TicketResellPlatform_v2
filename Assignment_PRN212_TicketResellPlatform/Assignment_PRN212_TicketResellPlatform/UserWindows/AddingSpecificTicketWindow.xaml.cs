using Microsoft.Win32;
using Service.User;
using Service.Utils;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;


namespace Assignment_PRN212_TicketResellPlatform.UserWindows
{
    public partial class AddingSpecificTicketWindow : Window
    {
        public AddingSpecificTicketWindow()
        {
            InitializeComponent();
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
                    FileInfo fileInfo = new FileInfo(fullFilename);
                    string filename = System.IO.Path.GetFileName(fullFilename);
                    //fileInfo.CopyTo(LocalPathSetting. + filename);
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
