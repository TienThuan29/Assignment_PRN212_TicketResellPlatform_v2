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
        private ManageStaffWindow staffWindow;
        private Staff staff;
        private bool isUpdate;
        public AddStaffWindow(ManageStaffWindow staffWindow)
        {
            adminService = new AdminService();
            InitializeComponent();
            this.staffWindow = staffWindow;
            isUpdate =false;
        }

        public AddStaffWindow(ManageStaffWindow staffWindow, Staff staff)
        {
            adminService = new AdminService();
            InitializeComponent();
            this.staffWindow = staffWindow;
            this.staff = staff;
            isUpdate = true;
        }

        private void ButtonClickExit(object sender, RoutedEventArgs e)
        {
            staffWindow.ReloadDataGrid();
            staffWindow.Show();
            this.Close();
        }

        private bool UpdateStaffInfor()
        {
            bool success = false;
            string PhonePattern = @"^(0[235789]\d{8})$";
            string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (Regex.IsMatch(txtPhone.Text, PhonePattern) && Regex.IsMatch(txtEmail.Text, EmailPattern))
            {
                staff.Firstname = txtFirstname.Text;
                staff.Lastname = txtLastname.Text;
                staff.Email = txtEmail.Text;
                staff.Phone = txtPhone.Text;
                staff.StaffCode = txtStaffcode.Text;
                success = adminService.UpdateStaff(staff);
            }
            return success;
        }

        private bool CheckInputUpdate()
        {
            return (txtFirstname.Text.Equals("") || txtLastname.Text.Equals("") || txtEmail.Text.Equals("")
                || txtPhone.Text.Equals("") || txtStaffcode.Text.Equals(""));
        }

        private void ButtonClickSubmit(object sender, RoutedEventArgs e)
        {
            if (isUpdate)
            {
                if (!CheckInputUpdate())
                {
                    if (UpdateStaffInfor())
                    {
                        MessageBox.Show("Cập nhật thông tin nhân viên thành công");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin nhân viên thất bại");
                    }
                }
                else
                {
                    MessageBox.Show("Thông tin cập nhật cần được đầy đủ");
                }
            }
            else
            {
                if (!CheckInput())
                {
                    string PhonePattern = @"^(0[235789]\d{8})$";
                    if (Regex.IsMatch(txtPhone.Text, PhonePattern))
                    {
                        string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                        if (Regex.IsMatch(txtEmail.Text, EmailPattern))
                        {
                            if (adminService.CheckExistUsername(txtUsername.Text))
                            {
                                string PwdPattern = @"^.{5,}$";
                                string UsernamePattern = @"^[a-zA-Z]{5,}[a-zA-Z0-9]*$";
                                if (Regex.IsMatch(pwdBox.Password, PwdPattern) && pwdBox.Password.Equals(confirmPwd.Password)
                                    && Regex.IsMatch(txtUsername.Text, UsernamePattern))
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
                                MessageBox.Show("Tên đăng nhập đã tồn tại");
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

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            if (isUpdate)
            {
                txtFirstname.Text = staff.Firstname;
                txtLastname.Text = staff?.Lastname;
                txtEmail.Text = staff?.Email;
                txtPhone.Text = staff?.Phone;
                txtStaffcode.Text = staff?.StaffCode;
                txtUsername.IsEnabled = false;
                pwdBox.IsEnabled = false;
                confirmPwd.IsEnabled = false;
            }
        }
    }
}
