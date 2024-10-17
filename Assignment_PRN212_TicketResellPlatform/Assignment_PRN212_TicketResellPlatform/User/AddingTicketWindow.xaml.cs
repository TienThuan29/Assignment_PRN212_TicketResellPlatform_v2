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

namespace Assignment_PRN212_TicketResellPlatform.User
{
    /// <summary>
    /// Interaction logic for AddingTicketWindow.xaml
    /// </summary>
    public partial class AddingTicketWindow : Window
    {
        public AddingTicketWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            MyShopWindow myShopWindow = new MyShopWindow();
            myShopWindow.Show();    
        }
    }
}
