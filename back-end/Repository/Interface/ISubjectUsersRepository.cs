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
            public void Add(SubjectUsers subjectUsers);
            public void Delete(string id);
            public IQueryable<SubjectUsers> GetAll();
            public SubjectUsers GetOne(string id);
            public void Update(string id, SubjectUsers subjectUsers);
      }
}
