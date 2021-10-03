using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interface
{
      public interface ISubjectUsersLogic
      {
            IQueryable<SubjectUsers> GetAllSubjectUsers();
            SubjectUsers GetOneSubjectUsers(string id);
            bool CreateSubjectUsers(SubjectUsers subjectUsers);
            bool EditSubjectUsers(string id, SubjectUsers newSubjectUsers);
            bool DeleteSubjectUsers(string id);
      }
}
