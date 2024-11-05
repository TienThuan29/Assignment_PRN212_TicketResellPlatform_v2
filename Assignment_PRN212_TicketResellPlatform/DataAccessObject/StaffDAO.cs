using BusinessObject;
using System;
using System.Collections.Generic;
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
                if(item.Id.ToString().Contains(str) || item.Firstname.ToLower().Contains(str) || item.Lastname.ToLower().Contains(str)
                    || item.Email.ToLower().Contains(str) || item.Phone.ToLower().Contains(str))
                {
                    result.Add(item);
                }
            }
            return result;
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
    }
}
