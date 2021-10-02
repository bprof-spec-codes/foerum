using Logic;
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
      }
}
