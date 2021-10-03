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
    public class CommentRepository : ICommentRepository
    {
        public FoerumDbContext db;

        public CommentRepository(string dbPassword)
        {
            this.db = new FoerumDbContext(dbPassword);
        }
        public void Add(Comment comment)
        {
            this.db.Set<Comment>().Add(comment);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            this.db.Set<Comment>().Remove(this.GetOne(id));
            this.db.SaveChanges();
        }

        public IQueryable<Comment> GetAll()
        {
            return this.db.Set<Comment>();
        }

        public Comment GetOne(string id)
        {
            return this.GetAll().SingleOrDefault(x => x.CommentID == id);
        }

        public void Update(string id, Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
