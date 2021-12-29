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

        public TransactionLogic(ITransactionRepository repo)
        {
            this.transactionRepo = repo;
        }

        public bool CreateTransaction(Transaction transaction)
        {
            if(!this.UserCanCompleteTransaction(transaction)) return false;

            try
            {
                this.transactionRepo.Add(transaction);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteTransaction(string id)
        {
            try
            {
                this.transactionRepo.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditTransaction(string id, Transaction newTransaction)
        {
            try
            {
                this.transactionRepo.Update(id, newTransaction);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<Transaction> GetAllTransaction()
        {
            return this.transactionRepo.GetAll();
        }

        public Transaction GetOneTransaction(string id)
        {
            return this.transactionRepo.GetOne(id);
        }

        private bool UserCanCompleteTransaction(Transaction Transaction)
        {
            return true;
        }
    }
}
