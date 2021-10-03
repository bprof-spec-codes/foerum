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
      public class CommentReactersRepository : ICommentReactersRepository
      {
            public FoerumDbContext db;

            public CommentReactersRepository(string dbPassword)
            {
                  this.db = new FoerumDbContext(dbPassword);
            }
            public void Add(CommentReacters commentReacters)
            {
                  throw new NotImplementedException();
            }

            public void Delete(string id)
            {
                  throw new NotImplementedException();
            }

            public IQueryable<CommentReacters> GetAll()
            {
                  throw new NotImplementedException();
            }

            public CommentReacters GetOne(string id)
            {
                  throw new NotImplementedException();
            }

            public void Update(string id, CommentReacters commentReacters)
            {
                  throw new NotImplementedException();
            }
      }
}
