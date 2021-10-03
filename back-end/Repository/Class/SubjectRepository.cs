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
                  throw new NotImplementedException();
            }

            public void Delete(string id)
            {
                  throw new NotImplementedException();
            }

            public IQueryable<Subject> GetAll()
            {
                  throw new NotImplementedException();
            }

            public Subject GetOne(string id)
            {
                  throw new NotImplementedException();
            }

            public void Update(string id, Subject subject)
            {
                  throw new NotImplementedException();
            }
      }
}
