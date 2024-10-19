using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Staff
{
    public interface IStaffService
    {
        BusinessObject.Staff FindByUsername(string username); 
    }
}
