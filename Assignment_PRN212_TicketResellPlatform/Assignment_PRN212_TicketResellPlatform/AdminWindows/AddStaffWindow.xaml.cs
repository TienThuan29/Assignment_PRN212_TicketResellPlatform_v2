using BusinessObject;
using Service.Admin;
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
    /// Interaction logic for AddStaffWindow.xaml
    /// </summary>
    public partial class AddStaffWindow : Window
    {
        private IAdminService adminService;
        public AddStaffWindow()
        {
            adminService = new AdminService();
            InitializeComponent();
        }

        private void ButtonClickExit(object sender, RoutedEventArgs e)
        {
            ManageStaffWindow manageStaffWindow = new ManageStaffWindow();
            manageStaffWindow.Show();
            this.Close();
        }

        private void ButtonClickSubmit(object sender, RoutedEventArgs e)
        {
            if (!CheckInput()) {
                string PhonePattern = @"^(0[235789]\d{8})$";
                if (Regex.IsMatch(txtPhone.Text,PhonePattern))
                {
                    string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                    if (Regex.IsMatch(txtEmail.Text,EmailPattern))
                    {
                        string PwdPattern = @"^.{5,}$";
                        string UsernamePattern = @"^[a-zA-Z]{5,}[a-zA-Z0-9]*$";
                        if (Regex.IsMatch(pwdBox.Password, PwdPattern) && pwdBox.Password.Equals(confirmPwd.Password)
                            && Regex.IsMatch(txtUsername.Text,UsernamePattern))
                        {
                            Staff staff = new Staff();
                            staff.Password = pwdBox.Password;
                            staff.Firstname = txtFirstname.Text;
                            staff.Lastname = txtLastname.Text;
                            staff.Email = txtEmail.Text;
                            staff.Phone = txtPhone.Text;
                            staff.StaffCode = txtStaffcode.Text;
                            staff.Username = txtUsername.Text;
                            staff.Balance = 0;
                            staff.Revenue = 0;
                            staff.IsEnable = true;
                            staff.RoleCode = "STAFF";
                            if (adminService.AddStaff(staff))
                            {
                                MessageBox.Show("Thêm nhân viên thành công !");
                                this.ResetInput();
                            }
                            else
                            {
                                MessageBox.Show("Thêm nhân viên thất bại !");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Mật khẩu hoặc Username chưa phù hợp !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Email không phù hợp");
                    }
                }
                else
                {
                    MessageBox.Show("Số điện thoại không phù hợp");
                }
            }
            else
            {
                MessageBox.Show("Cần nhập đầy đủ thông tin");
            }
        }

        private bool CheckInput()
        {
            return (txtFirstname.Text.Equals("") || txtLastname.Text.Equals("") || txtEmail.Text.Equals("")
                || txtPhone.Text.Equals("") || txtStaffcode.Text.Equals("") || txtUsername.Text.Equals("")
                || pwdBox.Password.Equals("") || confirmPwd.Password.Equals(""));
        }

        private void ResetInput()
        {
            txtFirstname.Text = "";
            txtLastname.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtStaffcode.Text = "";
            txtUsername.Text = "";
            pwdBox.Password = "";
            confirmPwd.Password = "";
        }
    }
}
