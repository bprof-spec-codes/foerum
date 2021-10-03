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
      public class TagController : ControllerBase
      {
            private ITagLogic tagLogic;

            public TagController(ITagLogic logic)
            {
                  this.tagLogic = logic;
            }

            [HttpGet]
            public IEnumerable<Tag> GetAllTag()
            {
                  return this.tagLogic.GetAllTag();
            }

            [HttpGet("{id}")]
            public Tag GetOneTag(string id)
            {
                  throw new NotImplementedException();
            }

            [HttpPost]
            public void CreateTag(Tag tag)
            {
                  throw new NotImplementedException();
            }

            [HttpPut("{id}")]
            public void EditTag(string id, [FromBody] Tag newTag)
            {
                  throw new NotImplementedException();
            }

            [HttpDelete("{id}")]
            public Tag DeleteTag(string id)
            {
                  throw new NotImplementedException();
            }
      }
}
