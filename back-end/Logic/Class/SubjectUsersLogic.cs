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
      public class SubjectUsersLogic : ISubjectUsersLogic
      {
            private ISubjectUsersRepository subjectRepo;

            public SubjectUsersLogic(string dbPassword)
            {
                  this.subjectRepo = new SubjectUsersRepository(dbPassword);
            }
            public bool CreateSubjectUsers(SubjectUsers subjectUsers)
            {
                  throw new NotImplementedException();
            }

            public bool DeleteSubjectUsers(string id)
            {
                  throw new NotImplementedException();
            }

            public bool EditSubjectUsers(string id, SubjectUsers newSubjectUsers)
            {
                  throw new NotImplementedException();
            }

            public IQueryable<SubjectUsers> GetAllSubjectUsers()
            {
                  throw new NotImplementedException();
            }

            public SubjectUsers GetOneSubjectUsers(string id)
            {
                  throw new NotImplementedException();
            }
      }
}
