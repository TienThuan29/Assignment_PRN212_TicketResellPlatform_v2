using BusinessObject;
using Repository.Def;
using Repository.Impl;
using Service.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly ITransactionRepository iTransactionRepository;
        private readonly IPolicyRepository iPolicyRepository;
        private readonly IStaffRepository iStaffRepository;
        private readonly IUserRepository iUserRepository;

        public AdminService()
        {
            iTransactionRepository = new TransactionRepository();
            iPolicyRepository = new PolicyRepository();
            iStaffRepository = new StaffRepository();
            iUserRepository = new UserRepository();
        }

        public List<BusinessObject.Staff> GetListStaff()
        {
            return iStaffRepository.GetAll();
        }

        public List<Transaction> GetTransactions()
        {
            return iTransactionRepository.GetTransactions();
        }

        public List<Transaction> GetTransactionsListOfType(string type)
        {
            return iTransactionRepository.GetTransactionsListOfType(type);
        }

        public List<BusinessObject.User> GetUsers()
        {
            return (List<BusinessObject.User>) iUserRepository.GetAll();
        }
    }
}
