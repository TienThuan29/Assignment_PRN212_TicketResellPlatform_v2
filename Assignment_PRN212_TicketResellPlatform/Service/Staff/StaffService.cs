using Repository.Def;
using Repository.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Staff
{
    public class StaffService : IStaffService
    {
        private IStaffRepository staffRepository;
        public StaffService() 
        { 
            this.staffRepository = new StaffRepository();
        }

        public BusinessObject.Staff FindByUsername(string username)
        {
            return staffRepository.FindByUsername(username);   
        }
    }
}
