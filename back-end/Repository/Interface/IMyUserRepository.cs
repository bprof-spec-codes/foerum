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
            public void Add(MyUser user);
            public void Delete(string id);
            public IQueryable<MyUser> GetAll();
            public MyUser GetOne(string id);
            public void Update(string id, MyUser user);
      }
}
