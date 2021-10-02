using Data;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
      public class YearLogic : IYearLogic
      {
            public FoerumDbContext db;

            public YearLogic(string dbstring)
            {
                  this.db = new FoerumDbContext(dbstring);
            }

            public IQueryable<Year> GetAllYear()
            {
                  return db.Year;
            }
      }
}
