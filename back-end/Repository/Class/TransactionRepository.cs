using Data;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Class
{
    public class TransactionRepository : ITransactionRepository
    {
        public FoerumDbContext db;

        public TransactionRepository(string dbPassword)
        {
            this.db = new FoerumDbContext(dbPassword);
        }
        public void Add(Transaction transaction)
        {
            this.db.Set<Transaction>().Add(transaction);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            this.db.Set<Transaction>().Remove(this.GetOne(id));
            this.db.SaveChanges();
        }

        public IQueryable<Transaction> GetAll()
        {
            return this.db.Set<Transaction>();
        }

        public Transaction GetOne(string id)
        {
            return this.GetAll().SingleOrDefault(x => x.TransactionID == id);
        }

        public void Update(string id, Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
