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

namespace Assignment_PRN212_TicketResellPlatform.StaffWindows
{
    /// <summary>
    /// Interaction logic for InputBox.xaml
    /// </summary>
    public partial class InputBox : Window
    {

        public string InputMessage { get; private set; }
        private string header;
        public InputBox()
        {
            InitializeComponent();
        }

        public InputBox(string header)
        {
            InitializeComponent();
            txtHeader.Text = header;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            InputMessage = txtInput.Text;
            this.DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
