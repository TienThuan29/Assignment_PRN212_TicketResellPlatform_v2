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
    public class TransactionRepository : ITransactionRepository
    {
        public ICollection<Transaction> FindByUserID(long userId)
        {
            return TransactionDAO.Instance.FindByUserID(userId);    
        }

        public List<Transaction> GetTransactions()
        {
            return TransactionDAO.Instance.GetTransactions();
        }

        public List<Transaction> GetTransactionsListOfType(string type)
        {
            return TransactionDAO.Instance.GetTransactionsListOfType(type);
        }

        public bool Save(Transaction transaction)
        {
            return TransactionDAO.Instance.Save(transaction);
        }
    }
}
