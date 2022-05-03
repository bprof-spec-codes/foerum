using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interface
{
      public interface IAwardLogic
      {
            IQueryable<Award> GetAllAward();
            Award GetOneAward(string id);
            bool CreateAward(Award award);
            bool EditAward(string id, Award newAward);
            bool DeleteAward(string id);
      }
}
