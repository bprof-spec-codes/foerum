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
            void Add(Year year);
            void Delete(string id);
            IQueryable<Year> GetAll();
            Year GetOne(string id);
            void Update(string id, Year year);
      }
}
