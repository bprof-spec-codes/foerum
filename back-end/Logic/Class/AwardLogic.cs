using Logic.Interface;
using Models;
using Repository.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Class
{
      public class AwardLogic : IAwardLogic
      {
            private IAwardRepository awardRepo;

            public AwardLogic(string dbPassword)
            {
                  this.awardRepo = new AwardRepository(dbPassword);
            }
            public bool CreateAward(Award award)
            {
                  throw new NotImplementedException();
            }

            public bool DeleteAward(string id)
            {
                  throw new NotImplementedException();
            }

            public bool EditAward(string id, Award newAward)
            {
                  throw new NotImplementedException();
            }

            public IQueryable<Award> GetAllAward()
            {
                  throw new NotImplementedException();
            }

            public Award GetOneAward(string id)
            {
                  throw new NotImplementedException();
            }
      }
}
