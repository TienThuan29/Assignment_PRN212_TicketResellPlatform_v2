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
        private ManagePolicyWindow policyWindow;
        private Policy policy1;
        private bool isUpdate;
        public AddPolicyWindow(ManagePolicyWindow managePolicyWindow)
        {
            policyService = new PolicyService();
            InitializeComponent();
            policyWindow = managePolicyWindow;
            isUpdate = false;   
        }

        public AddPolicyWindow(ManagePolicyWindow managePolicyWindow, Policy policy)
        {

            policyService = new PolicyService();
            InitializeComponent();
            policyWindow = managePolicyWindow;
            isUpdate = true;
            this.policy1 = policy;
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            this.boxOfTypePolicy.ItemsSource = policyService.GetAllTypePolicies();
            this.boxOfTypePolicy.DisplayMemberPath = "Name";
            this.boxOfTypePolicy.SelectedValue = "Id";
            if (isUpdate)
            {
                txtContent.Text = policy1.Content;
                txtFee.Text = policy1.Fee.ToString();
                boxOfTypePolicy.Text = policy1.TypePolicy.Name;
            }
        }

        private void ButtonClickExit(object sender, RoutedEventArgs e)
        {
            policyWindow.ReloadDataGrid();
            policyWindow.Show();
            this.Hide();
        }

        private void ButtonClickSubmit(object sender, RoutedEventArgs e)
        {
            if (!CheckInput())
            {
                string pattern = @"^([1-9]|[1-9][0-9]|100)?$";

                if (Regex.IsMatch(txtFee.Text, pattern))
                {
                    if (isUpdate)
                    {
                        policy1.Content = txtContent.Text;
                        policy1.TypePolicyId = policyService.GetTypePolicyByName(boxOfTypePolicy.Text).Id;
                        policy1.TypePolicy = policyService.GetTypePolicyByid(policy1.Id);
                        if (txtFee.Text.Equals(""))
                        {
                            policy1.Fee = 0;
                        }
                        else
                        {
                            policy1.Fee = int.Parse(txtFee.Text);
                        }
                        if (policyService.UpdatePolicy(policy1))
                        {
                            MessageBox.Show("Cập nhật chính sách thành công !");
                        }
                        else
                        {
                            MessageBox.Show("Cập nhật chính sách thất bại !");
                        }
                    }
                    else
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

                }
                else
                {
                    MessageBox.Show("Số phí nhập vào phải là số nguyên!");
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
