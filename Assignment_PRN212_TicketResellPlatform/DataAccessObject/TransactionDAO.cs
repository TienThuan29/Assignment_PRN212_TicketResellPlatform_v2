using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class TransactionDAO
    {
        private PRN212_TicketResellPlatformContext context;

        private static TransactionDAO instance;


        public static TransactionDAO Instance
        {
            get => instance = instance ?? (instance = new TransactionDAO());
        }


        private TransactionDAO()
        {
            this.context = new PRN212_TicketResellPlatformContext();
        }


        public bool Save(Transaction transaction)
        {
            bool flag = true;
            try
            {
                this.context.Transactions.Add(transaction);
                this.context.SaveChanges();
            }
            catch (Exception ex)
            {
                flag = false;
            }
            return flag;
        }

        

        public ICollection<Transaction> FindByUserID(long userId)
        {
            return context.Transactions.Where(trs => trs.UserId.Equals(userId))
                    .OrderByDescending(trs => trs.TransDate).ToList();
        }

        public List<Transaction> GetTransactions() => context.Transactions.ToList();

        public List<Transaction> GetTransactionsListOfType(string type)
        {
            List<Transaction> list = this.GetTransactions();
            List<Transaction> result = new List<Transaction>();
            foreach (var item in list)
            {
                if (item.TransType.Equals(type))
                {
                   result.Add(item);
                }
            }
            return result;
        }

    }
}
