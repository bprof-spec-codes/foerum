using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ISubjectUsersRepository
    {
        public IEnumerable<MyUser> GetOneSubjectAllUser(string subjectId);
        public IEnumerable<Subject> GetOneUserAllSubject(string userId);
    }
}
