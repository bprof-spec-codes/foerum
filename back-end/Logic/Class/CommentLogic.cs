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
            return this.commentRepo.GetAll();
        }

        public Comment GetOneComment(string id)
        {
            return this.commentRepo.GetOne(id);
        }
    }
}
