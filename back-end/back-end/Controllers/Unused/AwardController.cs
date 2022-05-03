/*
using Logic.Interface;
using Microsoft.AspNetCore.Authorization;
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
    public class AwardController : ControllerBase
    {
        private IAwardLogic awardLogic;

        public AwardController(IAwardLogic logic)
        {
            this.awardLogic = logic;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<Award> GetAllAward()
        {
            return this.awardLogic.GetAllAward();
        }

        [HttpGet("{id}")]
        [Authorize]
        public Award GetOneAward(string id)
        {
            return this.awardLogic.GetOneAward(id);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void CreateAward([FromBody] Award award)
        {
            this.awardLogic.CreateAward(award);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public void EditAward(string id, [FromBody] Award newAward)
        {
            this.EditAward(id, newAward);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void DeleteAward(string id)
        {
            this.awardLogic.DeleteAward(id);
        }
    }
}
*/