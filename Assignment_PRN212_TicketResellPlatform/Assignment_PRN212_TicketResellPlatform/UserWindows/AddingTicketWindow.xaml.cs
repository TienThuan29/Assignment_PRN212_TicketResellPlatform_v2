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

namespace Assignment_PRN212_TicketResellPlatform.UserWindows
{
    /// <summary>
    /// Interaction logic for AddingTicketWindow.xaml
    /// </summary>
    public partial class AddingTicketWindow : Window
    {
        private BusinessObject.User logedUser;


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
    }
}
