using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
      public interface ICommentRepository
      {
            public void Add(Comment comment);
            public void Delete(string id);
            public IQueryable<Comment> GetAll();
            public Comment GetOne(string id);
            public void Update(string id, Comment comment);
      }
}
