using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Admin
{
    public interface IAdminService
    {
        public List<Transaction> GetTransactions();

        public List<Transaction> GetTransactionsListOfType(string type);

        public List<BusinessObject.Staff> GetListStaff();

        public List<BusinessObject.User> GetUsers();
    }
}
