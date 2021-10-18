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
        public IEnumerable<string> GetOneCommentAllUser(string commentId);
        public IEnumerable<string> GetOneUserAllComment(string userId);
    }
}
