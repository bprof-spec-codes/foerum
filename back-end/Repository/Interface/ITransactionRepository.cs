using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
      public interface ITransactionRepository
      {
            void Add(Transaction transaction);
            void Delete(string id);
            IQueryable<Transaction> GetAll();
            Transaction GetOne(string id);
            void Update(string id, Transaction transaction);
      }
}
