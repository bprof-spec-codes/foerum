using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
      public interface IYearRepository
      {
            public void Add(Year year);
            public void Delete(string id);
            public IQueryable<Year> GetAll();
            public Year GetOne(string id);
            public void Update(string id, Year year);
      }
}
