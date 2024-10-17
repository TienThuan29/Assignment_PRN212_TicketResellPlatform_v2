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
    /// Interaction logic for MyShopWindow.xaml
    /// </summary>
    public partial class MyShopWindow : Window
    {
        public MyShopWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            AddingTicketWindow addingTicketWindow = new AddingTicketWindow();
            addingTicketWindow.Show();
        }
    }
}
