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

        [HttpPost]
        public void CreateSubject([FromBody] Subject subject)
        {
            this.subjectLogic.CreateSubject(subject);
        }

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
    }
}
