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
            this.db.Set<Award>().Add(award);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            this.db.Set<Award>().Remove(this.GetOne(id));
            this.db.SaveChanges();
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
