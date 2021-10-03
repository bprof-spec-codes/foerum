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
      public class SubjectLogic : ISubjectLogic
      {
            private ISubjectRepository subjectRepo;

            public SubjectLogic(string dbPassword)
            {
                  this.subjectRepo = new SubjectRepository(dbPassword);
            }
            public bool CreateSubject(Subject subject)
            {
                  throw new NotImplementedException();
            }

            public bool DeleteSubject(string id)
            {
                  throw new NotImplementedException();
            }

            public bool EditSubject(string id, Subject newSubject)
            {
                  throw new NotImplementedException();
            }

            public IQueryable<Subject> GetAllSubject()
            {
                  throw new NotImplementedException();
            }

            public Subject GetOneSubject(string id)
            {
                  throw new NotImplementedException();
            }
      }
}
