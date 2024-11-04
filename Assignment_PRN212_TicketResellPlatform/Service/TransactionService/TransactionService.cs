using BusinessObject;
using Repository.Def;
using Repository.Impl;
using Service.Constant;
using Service.Utils.TienThuan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private ITransactionRepository transactionRepository;


        public TransactionService() 
        { 
            this.transactionRepository = new TransactionRepository();
        }


        public ICollection<Transaction> FindByUserID(long userId)
        {
            return transactionRepository.FindByUserID(userId);  
        }


        public bool SaveDepositeTransaction(long userId, long amount)
        {
            return SaveDoneTransaction(userId, amount, TransactionType.DEPOSITE);
        }

        public bool SaveBuyingTransaction(long userId, long amount)
        {
            return SaveDoneTransaction(userId, amount, TransactionType.BUYING);
        }

        public bool SaveSellingTransaction(long userId, long amount)
        {
            return SaveDoneTransaction((long)userId, amount, TransactionType.SELLING);
        }

        private bool SaveDoneTransaction(long userId, long amount, string type)
        {
            Transaction transaction = new Transaction();
            transaction.UserId = userId;
            transaction.Amount = amount;
            transaction.TransDate = DateTime.Now;
            transaction.IsDone = true;
            transaction.TransType = type;
            transaction.TransactionNo = RandomUtil.RandomString(10);
            return transactionRepository.Save(transaction);
        }
    }
}
