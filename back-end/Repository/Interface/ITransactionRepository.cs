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
            public void Add(Transaction transaction);
            public void Delete(string id);
            public IQueryable<Transaction> GetAll();
            public Transaction GetOne(string id);
            public void Update(string id, Transaction transaction);
            public MyUser GetUserFromTransaction(string userId);
      }
}
