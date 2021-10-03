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
            public void Add(SubjectUsers subjectUsers)
            {
                  throw new NotImplementedException();
            }

            public void Delete(string id)
            {
                  throw new NotImplementedException();
            }

            public IQueryable<SubjectUsers> GetAll()
            {
                  throw new NotImplementedException();
            }

            public SubjectUsers GetOne(string id)
            {
                  throw new NotImplementedException();
            }

            public void Update(string id, SubjectUsers subjectUsers)
            {
                  throw new NotImplementedException();
            }
      }
}
