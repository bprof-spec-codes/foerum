using Logic.Interface;
using Models;
using Repository.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Class
{
      public class CommentReactersLogic : ICommentReactersLogic
      {
            private ICommentReactersRepository commentReactersRepo;

            public CommentReactersLogic(string dbPassword)
            {
                  this.commentReactersRepo = new CommentReactersRepository(dbPassword);
            }
            public bool CreateCommentReacters(CommentReacters commentReacters)
            {
                  throw new NotImplementedException();
            }

            public bool DeleteCommentReacters(string id)
            {
                  throw new NotImplementedException();
            }

            public bool EditCommentReacters(string id, CommentReacters newCommentReacters)
            {
                  throw new NotImplementedException();
            }

            public IQueryable<CommentReacters> GetAllCommentReacters()
            {
                  throw new NotImplementedException();
            }

            public CommentReacters GetOneCommentReacters(string id)
            {
                  throw new NotImplementedException();
            }
      }
}
