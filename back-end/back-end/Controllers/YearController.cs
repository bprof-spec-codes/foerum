using Logic;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public IEnumerable<Year> GetAllYear()
        {
            return this.yearLogic.GetAllYear();
        }

        [HttpGet("{id}")]
        [Authorize]
        public Year GetOneYear(string id)
        {
            return this.yearLogic.GetOneYear(id);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void CreateYear([FromBody] Year year)
        {
            this.yearLogic.CreateYear(year);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public void EditYear(string id, [FromBody] Year newYear)
        {
            this.yearLogic.EditYear(id, newYear);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void DeleteYear(string id)
        {
            this.yearLogic.DeleteYear(id);
        }
    }
}
