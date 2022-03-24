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
    public class SubjectRepository : ISubjectRepository
    {
        public FoerumDbContext db;

        public SubjectRepository(string dbPassword)
        {
            this.db = new FoerumDbContext(dbPassword);
        }
        public void Add(Subject subject)
        {
            this.db.Set<Subject>().Add(subject);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            this.db.Set<Subject>().Remove(this.GetOne(id));
            this.db.SaveChanges();
        }

        public IQueryable<Subject> GetAll()
        {
            return this.db.Set<Subject>();
        }

        public Subject GetOne(string id)
        {
            return this.GetAll().SingleOrDefault(x => x.SubjectID == id);
        }

        public void Update(string id, Subject subject)
        {
            var oldSubject = this.GetOne(id);
            if (oldSubject == null || subject == null)
            {
                throw new ArgumentNullException(nameof(subject), nameof(oldSubject));
            }
            else
            {
                oldSubject.SubjectName = subject.SubjectName;
                oldSubject.IsPrivate = subject.IsPrivate;
                oldSubject.InviteKeyIfPrivate = subject.InviteKeyIfPrivate;
                this.db.SaveChanges();
            }
        }

        public void AddUserToSubject(MyUser user, string subjectId)
        {
            this.GetOne(subjectId).Users.Add(new SubjectUsers { UserID = user.Id });
            this.db.SaveChanges();
        }

        public void DeleteUserFromSubject(MyUser user, string subjectId)
        {
            SubjectUsers subjectUsers = this.GetOne(subjectId).Users.FirstOrDefault(user => user.UserID == user.UserID);
            if (subjectUsers != null)
            {
                this.GetOne(subjectId).Users.Remove(subjectUsers);
                this.db.SaveChanges();
            }
        }

        public IQueryable<Subject> GetAllSubjectsOfYear(string yearId)
        {
            return this.GetAll().Where(x => x.YearID == yearId);
        }
    }
}
