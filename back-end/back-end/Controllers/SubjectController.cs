using Logic.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private ISubjectLogic subjectLogic;

        public SubjectController(ISubjectLogic logic)
        {
            this.subjectLogic = logic;
        }

        [HttpGet]
        public IEnumerable<Subject> GetAllSubject()
        {
            return this.subjectLogic.GetAllSubject();
        }

        [HttpGet("{id}")]
        public Subject GetOneSubject(string id)
        {
            return this.subjectLogic.GetOneSubject(id);
        }

        [HttpGet("SubjectsOfYear{yearId}")]
        public IQueryable<Subject> GetAllSubjectsOfYear(string yearId)
        {
            return this.subjectLogic.GetAllSubjectsOfYear(yearId);
        }

        [HttpPost]
        public void CreateSubject([FromBody] Subject subject)
        {
            this.subjectLogic.CreateSubject(subject);
        }

        // NOT NEEDED
        //[HttpPost("AddUserToSubject{subjectId}")]
        //public void AddUserToSubject([FromBody] MyUser user, string subjectId)
        //{
        //    this.subjectLogic.AddUserToSubject(user, subjectId);
        //}

        [HttpPut("{id}")]
        public void EditSubject(string id, [FromBody] Subject newSubject)
        {
            this.subjectLogic.EditSubject(id, newSubject);
        }

        [HttpDelete("{id}")]
        public void DeleteSubject(string id)
        {
            this.subjectLogic.DeleteSubject(id);
        }

        // I suppose if adduser is not needed, delete isn't needed either
        //[HttpDelete("DeleteUserFromSubject{subjectId}")]
        //public void DeleteUserFromSubject([FromBody] MyUser user, string subjectId)
        //{
        //    this.subjectLogic.DeleteUserFromSubject(user, subjectId);
        //}
    }
}
