using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interface
{
      public interface ITransactionLogic
      {
            IQueryable<Transaction> GetAllTransaction();
            Transaction GetOneTransaction(string id);
            bool CreateTransaction(Transaction transaction);
            bool EditTransaction(string id, Transaction newTransaction);
            bool DeleteTransaction(string id);
      }
}
