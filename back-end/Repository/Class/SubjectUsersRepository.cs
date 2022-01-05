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
    public class SubjectUsersRepository : ISubjectUsersRepository
    {
        public FoerumDbContext db;

        public SubjectUsersRepository(string dbPassword)
        {
            this.db = new FoerumDbContext(dbPassword);
        }

        public IEnumerable<MyUser> GetOneSubjectAllUser(string subjectId)
        {
            return this.db.Set<SubjectUsers>().Where(x => x.SubjectID == subjectId).Select(x => x.User);
        }

        public IEnumerable<Subject> GetOneUserAllSubject(string userId)
        {
            return this.db.Set<SubjectUsers>().Where(x => x.UserID == userId).Select(x => x.Subject);
        }
    }
}
