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
        /// TODO: uncomment after repo is implemented
        public bool CreateSubjectUsers(SubjectUsers subjectUsers)
        {
            throw new NotImplementedException();
            /*try
            {
                this.subjectRepo.Add(subjectUsers);
                return true;
            }
            catch
            {
                return false;
            }*/
        }

        public bool DeleteSubjectUsers(string id)
        {
            throw new NotImplementedException();
            /*try
            {
                this.subjectRepo.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }*/
        }

        public bool EditSubjectUsers(string id, SubjectUsers newSubjectUser)
        {
            throw new NotImplementedException();
            /*try
            {
                this.subjectRepo.Update(id, newSubjectUser);
                return true;
            }
            catch
            {
                return false;
            }*/
        }

        public IQueryable<SubjectUsers> GetAllSubjectUsers()
        {
            throw new NotImplementedException();
            //return this.subjectRepo.GetAll();
        }

        public SubjectUsers GetOneSubjectUsers(string id)
        {
            throw new NotImplementedException();
            //return this.subjectRepo.GetOne(id);
        }
    }
}
