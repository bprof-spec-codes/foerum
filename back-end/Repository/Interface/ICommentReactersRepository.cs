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
        public IEnumerable<MyUser> GetOneCommentAllUser(string commentId);
        public IEnumerable<Comment> GetOneUserAllComment(string userId);
    }
}
