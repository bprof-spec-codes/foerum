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
      public class YearRepository : IYearRepository
      {
            public FoerumDbContext db;

            public YearRepository(string dbPassword)
            {
                  this.db = new FoerumDbContext(dbPassword);
            }

            public void Add(Year year)
            {
                  throw new NotImplementedException();
            }

            public void Delete(string id)
            {
                  throw new NotImplementedException();
            }

            public IQueryable<Year> GetAll()
            {
                  throw new NotImplementedException();
            }

            public Year GetOne(string id)
            {
                  throw new NotImplementedException();
            }

            public void Update(string id, Year year)
            {
                  throw new NotImplementedException();
            }
      }
}
