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
    public class CommentRepository : ICommentRepository
    {
        public FoerumDbContext db;

        public CommentRepository(string dbPassword)
        {
            this.db = new FoerumDbContext(dbPassword);
        }
        public void Add(Comment comment)
        {
            this.db.Set<Comment>().Add(comment);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            this.db.Set<Comment>().Remove(this.GetOne(id));
            this.db.SaveChanges();
        }

        public IQueryable<Comment> GetAll()
        {
            return this.db.Set<Comment>();
        }

        public Comment GetOne(string id)
        {
            return this.GetAll().SingleOrDefault(x => x.CommentID == id);
        }

        public void Update(string id, Comment comment)
        {
            var oldComment = this.GetOne(id);

            Comment newComment = new Comment();

            newComment.CommentID = oldComment.CommentID;
            newComment.UserID = oldComment.UserID;
            newComment.Content = comment.Content;
            newComment.CreationDate = DateTime.Now;
            newComment.AttachmentUrl = oldComment.AttachmentUrl;
            newComment.ReactionCount = oldComment.ReactionCount;
            newComment.ReplyToCommentID = oldComment.ReplyToCommentID;
            newComment.CoinReward = oldComment.CoinReward;
            newComment.IsEdited = oldComment.CommentID;
            newComment.IsActive = oldComment.IsActive;

            this.db.Set<Comment>().Add(newComment);
            this.db.SaveChanges();
        }
    }
}
