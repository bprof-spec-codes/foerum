using Data;
using Models;
using Repository.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
      public class YearLogic : IYearLogic
      {
            private IYearRepository yearRepo;

            public YearLogic(string dbPassword)
            {
                  this.yearRepo = new YearRepository(dbPassword);
            }

            public bool CreateYear(Year year)
            {
                  throw new NotImplementedException();
            }

            public bool DeleteYear(string id)
            {
                  throw new NotImplementedException();
            }

            public bool EditYear(string id, Year newYear)
            {
                  throw new NotImplementedException();
            }

            public IQueryable<Year> GetAllYear()
            {
                  throw new NotImplementedException();
            }

            public Year GetOneYear(string id)
            {
                  throw new NotImplementedException();
            }
      }
}
