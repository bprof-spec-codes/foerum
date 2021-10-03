using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interface
{
      public interface ICommentLogic
      {
            IQueryable<Comment> GetAllComment();
            Comment GetOneComment(string id);
            bool CreateComment(Comment comment);
            bool EditComment(string id, Comment newComment);
            bool DeleteComment(string id);
      }
}
