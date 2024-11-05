using BusinessObject;
using Service.AdminService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Assignment_PRN212_TicketResellPlatform.AdminWindows
{
    /// <summary>
    /// Interaction logic for AddPolicyWindow.xaml
    /// </summary>
    public partial class AddPolicyWindow : Window
    {
        private IPolicyService policyService;
        public AddPolicyWindow()
        {
            policyService = new PolicyService();
            InitializeComponent();
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            this.boxOfTypePolicy.ItemsSource = policyService.GetAllTypePolicies();
            this.boxOfTypePolicy.DisplayMemberPath = "Name";
            this.boxOfTypePolicy.SelectedValue = "Id";
        }

        private void ButtonClickExit(object sender, RoutedEventArgs e)
        {
            ManagePolicyWindow managePolicyWindow = new ManagePolicyWindow();
            managePolicyWindow.Show();
            this.Hide();
        }

        private void ButtonClickSubmit(object sender, RoutedEventArgs e)
        {
            if (!CheckInput())
            {
                Policy policy = new Policy();
                policy.Content = txtContent.Text;
                policy.TypePolicyId = policyService.GetTypePolicyByName(boxOfTypePolicy.Text).Id;
                policy.TypePolicy = policyService.GetTypePolicyByid(policy.Id);
                policy.IsDeleted = false;
                if (txtFee.Text.Equals(""))
                {
                    policy.Fee = 0;
                }
                else
                {
                    policy.Fee = int.Parse(txtFee.Text);
                }
                if (policyService.AddPolicy(policy))
                {
                    MessageBox.Show("Thêm chính sách thành công !");
                    this.ResetInput();
                }
                else
                {
                    MessageBox.Show("Thêm chính sách thất bại !");
                }
                
            }
            else
            {
                MessageBox.Show("Cần nhập đầy đủ thông tin !");
            }
        }

        private bool CheckInput()
        {
            return ( txtContent.Text.Equals("") || boxOfTypePolicy.Text.Equals(""));
        }

        private void ResetInput()
        {
            this.txtContent.Text = "";
            this.boxOfTypePolicy.Text = "";
            this.txtFee.Text = "";
        }
    }
}
