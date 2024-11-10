using BusinessObject;
using DataAccessObject;
using Repository.Def;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Impl
{
    public class StaffRepository : IStaffRepository
    {
        public bool AddStaff(Staff item)
        {
            return StaffDAO.Instance.AddStaff(item);
        }

        public bool ChangeEnableOfStaff(string id)
        {
            return StaffDAO.Instance.ChangeEnableOfStaff(id);
        }

        public bool CheckExistUsername(string username)
        {
            return StaffDAO.Instance.CheckExistUsername(username);
        }

        public Staff FindByUsername(string username)
        {
            return StaffDAO.Instance.FindByUsername(username);  
        }

        public List<Staff> GetAll()
        {
            return StaffDAO.Instance.GetAll();
        }

        public List<EventRevenue> GetEventRevenueList()
        {
            return StaffDAO.Instance.GetEventRevenueList();
        }

        public Staff GetStaffById(string id)
        {
            return StaffDAO.Instance.GetStaffById(id);
        }

        public List<Staff> Search(string str)
        {
            return StaffDAO.Instance.Search(str);
        }

        public List<EventRevenue> SearchEventRevenueList(string str)
        {
            return StaffDAO.Instance.SearchEventRevenueList(str);
        }

        public bool UpdateStaff(Staff item)
        {
            return StaffDAO.Instance.UpdateStaff(item);
        }
    }
}
