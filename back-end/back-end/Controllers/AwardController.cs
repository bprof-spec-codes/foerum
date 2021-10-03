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
                  throw new NotImplementedException();
            }

            [HttpPost]
            public void CreateAward(Award award)
            {
                  throw new NotImplementedException();
            }

            [HttpPut("{id}")]
            public void EditAward(string id, [FromBody] Award newAward)
            {
                  throw new NotImplementedException();
            }

            [HttpDelete("{id}")]
            public Award DeleteAward(string id)
            {
                  throw new NotImplementedException();
            }
      }
}
