using Logic.Interface;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace back_end.Controllers
{
    /* Every controller needs all the CRUD methods */
    [Route("[controller]")]
    [ApiController]
    public class MyUserController : ControllerBase
    {
        private IMyUserLogic myUserLogic;

        public MyUserController(IMyUserLogic logic)
        {
            this.myUserLogic = logic;
        }

        //[HttpGet]
        //public IEnumerable<MyUser> GetAllUser()
        //{
        //    return this.myUserLogic.GetAllUser();
        //}

        [Authorize]
        [HttpGet]
        public ActionResult<MyUser> GetUser()
        {
            // TODO LINQ to get user from db by name or something similar
            var user = new MyUser();
            user.FullName = this.HttpContext.User.Identity.Name.ToString();
            return this.Ok(user);
        }

        [HttpGet("{id}")]
        public MyUser GetOneUser(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void CreateUser(MyUser user)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public void EditUser(string id, [FromBody] MyUser newUser)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public MyUser DeleteUser(string id)
        {
            throw new NotImplementedException();
        }
    }
}
