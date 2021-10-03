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
      public class AwardRepository : IAwardRepository
      {
            public FoerumDbContext db;

            public AwardRepository(string dbPassword)
            {
                  this.db = new FoerumDbContext(dbPassword);
            }
            public void Add(Award award)
            {
                  throw new NotImplementedException();
            }

            public void Delete(string id)
            {
                  throw new NotImplementedException();
            }

            public IQueryable<Award> GetAll()
            {
                  throw new NotImplementedException();
            }

            public Award GetOne(string id)
            {
                  throw new NotImplementedException();
            }

            public void Update(string id, Award award)
            {
                  throw new NotImplementedException();
            }
      }
}
