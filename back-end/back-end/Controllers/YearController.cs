using Logic;
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
      public class YearController : ControllerBase
      {
            private IYearLogic yearLogic;

            public YearController(IYearLogic logic)
            {
                  this.yearLogic = logic;
            }

            [HttpGet]
            public IEnumerable<Year> GetAllYear()
            {
                  return this.yearLogic.GetAllYear();
            }

            [HttpGet("{id}")]
            public Year GetOneYear(string id)
            {
                  throw new NotImplementedException();
            }

            [HttpPost]
            public void CreateYear(Year year)
            {
                  throw new NotImplementedException();
            }

            [HttpPut("{id}")]
            public void EditYear(string id, [FromBody] Year newYear)
            {
                  throw new NotImplementedException();
            }

            [HttpDelete("{id}")]
            public Year DeleteYear(string id)
            {
                  throw new NotImplementedException();
            }
      }
}
