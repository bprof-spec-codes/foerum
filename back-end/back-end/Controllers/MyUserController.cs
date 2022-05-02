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
    [Route("[controller]")]
    [ApiController]
    public class MyUserController : ControllerBase
    {
        private IMyUserLogic myUserLogic;

        public MyUserController(IMyUserLogic logic)
        {
            this.myUserLogic = logic;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<MyUser> GetAllUser()
        {
            return this.myUserLogic.GetAllUser();
        }

        [HttpGet("{id}")]
        [Authorize]
        public MyUser GetOneUser(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public void CreateUser([FromBody] MyUser user)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public void EditUser(string id, [FromBody] MyUser newUser)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public MyUser DeleteUser(string id)
        {
            throw new NotImplementedException();
        }
    }
}
