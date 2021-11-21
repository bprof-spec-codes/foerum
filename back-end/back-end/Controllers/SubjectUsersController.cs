using Logic.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    /* Every controller needs all the CRUD methods */
    [Route("[controller]")]
    [ApiController]
    public class SubjectUsersController : ControllerBase
    {
        private ISubjectUsersLogic subjectUsersLogic;

        public SubjectUsersController(ISubjectUsersLogic logic)
        {
            this.subjectUsersLogic = logic;
        }

        [HttpGet]
        public IEnumerable<SubjectUsers> GetAllSubjectUsers()
        {
            return this.subjectUsersLogic.GetAllSubjectUsers();
        }

        [HttpGet("{id}")]
        public SubjectUsers GetOneSubjectUsers(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void CreateSubjectUsers([FromBody] SubjectUsers subjectUsers)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public void EditSubjectUsers(string id, [FromBody] SubjectUsers newSubjectUsers)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public SubjectUsers DeleteSubjectUsers(string id)
        {
            throw new NotImplementedException();
        }
    }
}
