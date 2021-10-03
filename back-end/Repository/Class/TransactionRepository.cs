﻿using Data;
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
            throw new NotImplementedException();
        }

        public Transaction GetOne(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(string id, Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
