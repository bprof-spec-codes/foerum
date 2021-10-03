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
    public class TopicRepository : ITopicRepository
    {
        public FoerumDbContext db;

        public TopicRepository(string dbPassword)
        {
            this.db = new FoerumDbContext(dbPassword);
        }
        public void Add(Topic topic)
        {
            this.db.Set<Topic>().Add(topic);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            this.db.Set<Topic>().Remove(this.GetOne(id));
            this.db.SaveChanges();
        }

        public IQueryable<Topic> GetAll()
        {
            return this.db.Set<Topic>();
        }

        public Topic GetOne(string id)
        {
            return this.GetAll().SingleOrDefault(x => x.TopicID == id);
        }

        public void Update(string id, Topic topic)
        {
            throw new NotImplementedException();
        }
    }
}
