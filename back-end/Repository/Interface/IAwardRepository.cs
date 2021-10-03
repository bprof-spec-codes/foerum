using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
      public interface IAwardRepository
      {
            public void Add(Award award);
            public void Delete(string id);
            public IQueryable<Award> GetAll();
            public Award GetOne(string id);
            public void Update(string id, Award award);
      }
}
