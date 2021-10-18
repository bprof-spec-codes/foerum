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
    public class AwardController : ControllerBase
    {
        private IAwardLogic awardLogic;

        public AwardController(IAwardLogic logic)
        {
            this.awardLogic = logic;
        }

        [HttpGet]
        public IEnumerable<Award> GetAllAward()
        {
            return this.awardLogic.GetAllAward();
        }

        [HttpGet("{id}")]
        public Award GetOneAward(string id)
        {
            return this.awardLogic.GetOneAward(id);
        }

        [HttpPost]
        public void CreateAward([FromBody] Award award)
        {
            this.awardLogic.CreateAward(award);
        }

        [HttpPut("{id}")]
        public void EditAward(string id, [FromBody] Award newAward)
        {
            this.EditAward(id, newAward);
        }

        [HttpDelete("{id}")]
        public void DeleteAward(string id)
        {
            this.awardLogic.DeleteAward(id);
        }
    }
}
