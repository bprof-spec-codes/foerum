using Logic.Interface;
using Models;
using Repository.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Class
{
      public class TransactionLogic : ITransactionLogic
      {
            private ITransactionRepository transactionRepo;

            public TransactionLogic(string dbPassword)
            {
                  this.transactionRepo = new TransactionRepository(dbPassword);
            }
            public bool CreateTransaction(Transaction transaction)
            {
                  throw new NotImplementedException();
            }

            public bool DeleteTransaction(string id)
            {
                  throw new NotImplementedException();
            }

            public bool EditTransaction(string id, Transaction newTransaction)
            {
                  throw new NotImplementedException();
            }

            public IQueryable<Transaction> GetAllTransaction()
            {
                  throw new NotImplementedException();
            }

            public Transaction GetOneTransaction(string id)
            {
                  throw new NotImplementedException();
            }
      }
}
