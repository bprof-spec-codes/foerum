using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
      public interface ISubjectRepository
      {
            public void Add(Subject subject);
            public void Delete(string id);
            public IQueryable<Subject> GetAll();
            public Subject GetOne(string id);
            public void Update(string id, Subject subject);
      }
}
