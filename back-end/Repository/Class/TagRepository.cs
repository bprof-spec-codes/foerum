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
            throw new NotImplementedException();
        }

        public IQueryable<Tag> GetAll()
        {
            throw new NotImplementedException();
        }

        public Tag GetOne(string id)
        {
            throw new NotImplementedException();
        }

        public void Update(string id, Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
