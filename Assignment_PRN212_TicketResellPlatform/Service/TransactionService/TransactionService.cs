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
            Transaction transaction = new Transaction();
            transaction.UserId = userId;    
            transaction.Amount = amount;    
            transaction.TransDate = DateTime.Now;   
            transaction.IsDone = true;
            transaction.TransType = TransactionType.DEPOSITE;
            transaction.TransactionNo = RandomUtil.RandomString(10);
            return transactionRepository.Save(transaction);
        }


    }
}
