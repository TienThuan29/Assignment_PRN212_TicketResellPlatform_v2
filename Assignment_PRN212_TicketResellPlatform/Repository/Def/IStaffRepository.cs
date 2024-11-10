using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Def
{
    public interface IStaffRepository
    {
        Staff FindByUsername(string username);

        List<Staff> GetAll();

        List<Staff> Search(string str);

        bool AddStaff(Staff item);

        bool ChangeEnableOfStaff(string id);

        bool CheckExistUsername(string username);

        List<EventRevenue> GetEventRevenueList();

        List<EventRevenue> SearchEventRevenueList(string str);

        Staff GetStaffById(string id);

        bool UpdateStaff(Staff item);
    }
}
