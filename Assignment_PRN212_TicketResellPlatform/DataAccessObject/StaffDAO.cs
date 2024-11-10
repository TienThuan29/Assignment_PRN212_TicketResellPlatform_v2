using BusinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace DataAccessObject
{
    public class StaffDAO
    {
        private PRN212_TicketResellPlatformContext context;

        private static StaffDAO instance;

        public static StaffDAO Instance
        {
            get => instance = instance ?? (instance = new StaffDAO());
        }

        private StaffDAO()
        {
            this.context = new PRN212_TicketResellPlatformContext();
        }

        public Staff FindByUsername(string username)
        {
            return context.Staffs.SingleOrDefault(obj => obj.Username.Equals(username));
        }

        public List<Staff> GetAll()
        {
            List<Staff> list = context.Staffs.ToList();
            List<Staff> result = new List<Staff>();
            foreach (var item in list)
            {
                if (item.RoleCode.ToUpper().Equals("STAFF"))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public List<Staff> Search(string str1)
        {
            string str = str1.ToLower();
            List<Staff> staff = context.Staffs.ToList();
            List<Staff> result = new List<Staff>();
            foreach (var item in staff) {
                if (item.Id.ToString().Contains(str) || item.Firstname.ToLower().Contains(str) || item.Lastname.ToLower().Contains(str)
                    || item.Email.ToLower().Contains(str) || item.Phone.ToLower().Contains(str))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public bool CheckExistUsername(string username)
        {
            Staff staff = context.Staffs.SingleOrDefault(x => x.Username.Equals(username));
            User user = context.Users.SingleOrDefault(x => x.Username.Equals(username));
            return user == null && staff == null;
        }

        public bool AddStaff(Staff item) {
            bool isSuccess = false;
            try
            {
                context.Staffs.Add(item);
                context.SaveChanges();
                isSuccess = true;
            }
            catch (Exception ex) {
                isSuccess = false;
            }
            return isSuccess;
        }

        public bool ChangeEnableOfStaff(string id)
        {
            bool isSuccess = false;
            try
            {
                Staff staff = context.Staffs.SingleOrDefault(x => x.Id.ToString() == id);
                if (staff != null) {
                    staff.IsEnable = !staff.IsEnable;
                    context.Staffs.Update(staff);
                    context.SaveChanges();
                    isSuccess = true;
                }

            }
            catch (Exception ex)
            {
                isSuccess = false;
            }
            return isSuccess;
        }

        public List<EventRevenue> GetEventRevenueList()
        {
            return context.GetEventRevenue();
        }

        public List<EventRevenue> SearchEventRevenueList(string str)
        {
            List<EventRevenue> list = this.GetEventRevenueList();
            List<EventRevenue> result = new List<EventRevenue>();
            str = str.ToLower();
            foreach (EventRevenue e in list) {
                if(e.EventName.ToLower().Equals(str) || e.TicketCount.ToString().Equals(str) || e.StartDate.ToString().Equals(str)
                    || e.TotalRevenue.ToString().Equals(str))
                {
                    result.Add(e);
                }
            }
            return result;
        }
    }
}
