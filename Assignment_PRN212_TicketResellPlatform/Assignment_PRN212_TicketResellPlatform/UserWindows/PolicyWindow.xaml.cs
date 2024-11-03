using Service.AdminService;
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
    /// Interaction logic for PolicyWindow.xaml
    /// </summary>
    public partial class PolicyWindow : Window
    {   
        private readonly IPolicyService policyService;
        public PolicyWindow()
        {
            InitializeComponent();
            policyService = new PolicyService();  
        }

        public void OnDataWindow(object sender, RoutedEventArgs e)
        {
            PolicyDataGrid.ItemsSource = policyService.GetPolicies();
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
