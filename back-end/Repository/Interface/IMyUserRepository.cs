using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
      public interface IMyUserRepository
      {
            void Add(MyUser user);
            void Delete(string id);
            IQueryable<MyUser> GetAll();
            MyUser GetOne(string id);
            void Update(string id, MyUser user);
            void SetWallet(string id, string address);
      }
}
