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
      public class CommentLogic : ICommentLogic
      {
            private ICommentRepository commentRepo;

            public CommentLogic(string dbPassword)
            {
                  this.commentRepo = new CommentRepository(dbPassword);
            }
            public bool CreateComment(Comment comment)
            {
                  throw new NotImplementedException();
            }

            public bool DeleteComment(string id)
            {
                  throw new NotImplementedException();
            }

            public bool EditComment(string id, Comment newComment)
            {
                  throw new NotImplementedException();
            }

            public IQueryable<Comment> GetAllComment()
            {
                  throw new NotImplementedException();
            }

            public Comment GetOneComment(string id)
            {
                  throw new NotImplementedException();
            }
      }
}
