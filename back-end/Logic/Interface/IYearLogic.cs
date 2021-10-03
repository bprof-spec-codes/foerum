using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
      public interface IYearLogic
      {
            IQueryable<Year> GetAllYear();
            Year GetOneYear(string id);
            bool CreateYear(Year year);
            bool EditYear(string id, Year newYear);
            bool DeleteYear(string id);
      }
}
