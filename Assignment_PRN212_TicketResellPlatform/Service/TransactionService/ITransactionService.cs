using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.TransactionService
{
    public interface ITransactionService
    {
        bool SaveDepositeTransaction(long userId, long amount);
    }
}
