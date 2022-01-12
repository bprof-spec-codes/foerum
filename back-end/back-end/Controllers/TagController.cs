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
            return this.tagLogic.GetOneTag(id);
        }

        [HttpPost]
        public void CreateTag([FromBody] Tag tag)
        {
            this.tagLogic.CreateTag(tag);
        }

        [HttpPut("{id}")]
        public void EditTag(string id, [FromBody] Tag newTag)
        {
            this.tagLogic.EditTag(id, newTag);
        }

        [HttpDelete("{id}")]
        public void DeleteTag(string id)
        {
            this.tagLogic.DeleteTag(id);
        }
    }
}
