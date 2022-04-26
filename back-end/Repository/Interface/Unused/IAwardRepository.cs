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
            void Add(Award award);
            void Delete(string id);
            IQueryable<Award> GetAll();
            Award GetOne(string id);
            void Update(string id, Award award);
      }
}
