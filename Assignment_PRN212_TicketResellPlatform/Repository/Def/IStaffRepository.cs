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
    }
}
