using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interface
{
      public interface ICommentReactersLogic
      {
            IQueryable<CommentReacters> GetAllCommentReacters();
            CommentReacters GetOneCommentReacters(string id);
            bool CreateCommentReacters(CommentReacters commentReacters);
            bool EditCommentReacters(string id, CommentReacters newCommentReacters);
            bool DeleteCommentReacters(string id);
      }
}
