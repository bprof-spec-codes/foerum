using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
      public interface ICommentReactersRepository
      {
            public void Add(CommentReacters commentReacters);
            public void Delete(string id);
            public IQueryable<CommentReacters> GetAll();
            public CommentReacters GetOne(string id);
            public void Update(string id, CommentReacters commentReacters);
      }
}
