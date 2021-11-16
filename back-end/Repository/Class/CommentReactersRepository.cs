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

        public IEnumerable<MyUser> GetOneCommentAllUser(string commentId)
        {
            return this.db.Set<CommentReacters>().Where(x => x.CommentID == commentId).Select(x => x.User);
        }

        public IEnumerable<Comment> GetOneUserAllComment(string userId)
        {
            return this.db.Set<CommentReacters>().Where(x => x.UserID == userId).Select(x => x.Comment);
        }
    }
}
