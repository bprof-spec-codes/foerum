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
        IEnumerable<MyUser> GetOneCommentAllUser(string commentId);
        IEnumerable<Comment> GetOneUserAllComment(string userId);
    }
}
