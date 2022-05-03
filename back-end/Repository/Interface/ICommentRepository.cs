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
            void Add(Comment comment);
            void Delete(string id);
            IQueryable<Comment> GetAll();
            Comment GetOne(string id);
            void Update(string id, Comment comment);
            void AddUserToComment(MyUser user, string commentId);
            void DeleteUserFromComment(MyUser user, string commentId);
            IQueryable<Comment> GetAllCommentsOfTopic(string commentId);
      }
}
