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
    public class TagRepository : ITagRepository
    {
        public FoerumDbContext db;

        public TagRepository(string dbPassword)
        {
            this.db = new FoerumDbContext(dbPassword);
        }
        public void Add(Tag tag)
        {
            this.db.Set<Tag>().Add(tag);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            this.db.Set<Tag>().Remove(this.GetOne(id));
            this.db.SaveChanges();
        }

        public IQueryable<Tag> GetAll()
        {
            return this.db.Set<Tag>();
        }

        public Tag GetOne(string id)
        {
            return this.GetAll().SingleOrDefault(x => x.TagID == id);
        }

        public void Update(string id, Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
