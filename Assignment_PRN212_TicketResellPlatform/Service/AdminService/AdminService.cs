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

        public AdminService()
        {
            iTransactionRepository = new TransactionRepository();
            iPolicyRepository = new PolicyRepository();
        }

        public List<Policy> GetPolicies()
        {
            return iPolicyRepository.GetPolicies();
        }

        public List<Transaction> GetTransactions()
        {
            return iTransactionRepository.GetTransactions();
        }

        public List<Transaction> GetTransactionsListOfType(string type)
        {
            return iTransactionRepository.GetTransactionsListOfType(type);
        }


    }
}
