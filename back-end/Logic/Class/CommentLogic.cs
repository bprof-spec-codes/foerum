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

        public CommentLogic(ICommentRepository repo)
        {
            this.commentRepo = repo;
        }

        public bool CreateComment(Comment comment)
        {
            try
            {
                this.commentRepo.Add(comment);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteComment(string id)
        {
            try
            {
                this.commentRepo.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditComment(string id, Comment newComment)
        {
            try
            {
                this.commentRepo.Update(id, newComment);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<Comment> GetAllComment()
        {
            var comments = this.commentRepo.GetAll();
            var orderedComments = comments.OrderBy(c => c.CreationDate);
            return orderedComments;
        }

        public Comment GetOneComment(string id)
        {
            return this.commentRepo.GetOne(id);
        }

        public void AddUserToComment(MyUser user, string commentId)
        {
            this.commentRepo.AddUserToComment(user, commentId);
        }

        public void DeleteUserFromComment(MyUser user, string commentId)
        {
            this.commentRepo.DeleteUserFromComment(user, commentId);
        }

        public IQueryable<Comment> GetOneTopicAllComment(string topicId)
        {
            return this.commentRepo.GetOneTopicAllComment(topicId).OrderBy(comment => comment.CreationDate);
        }
    }
}
