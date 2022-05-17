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
        void Add(Subject subject);
        void Delete(string id);
        IQueryable<Subject> GetAll();
        Subject GetOne(string id);
        void Update(string id, Subject subject);
        IQueryable<Subject> GetAllSubjectsOfYear(string yearId);

        // NOT NEEDED
        //void AddUserToSubject(MyUser user, string subjectId);
        //void DeleteUserFromSubject(MyUser user, string subjectId);
    }
}
