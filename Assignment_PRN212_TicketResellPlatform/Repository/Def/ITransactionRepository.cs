﻿using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Def
{
    public interface ITransactionRepository
    {
        bool Save(Transaction transaction);

        ICollection<Transaction> FindByUserID(long userId);

        List<Transaction> GetTransactions();

        List<Transaction> GetTransactionsListOfType(string type);

        List<Transaction> Search(string query);

        List<Transaction> SearchOfType(string query, string type);
    }
}
