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

            [HttpGet("{id:string}")]
            public Subject GetOneSubject(string id)
            {
                  throw new NotImplementedException();
            }

            [HttpPost]
            public void CreateSubject(Subject subject)
            {
                  throw new NotImplementedException();
            }

            [HttpPut("{id:string}")]
            public void EditSubject(string id, [FromBody] Subject newSubject)
            {
                  throw new NotImplementedException();
            }

            [HttpDelete("{id:string}")]
            public Subject DeleteSubject(string id)
            {
                  throw new NotImplementedException();
            }
      }
}
