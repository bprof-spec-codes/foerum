using Logic.Class;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private AuthLogic _authLogic;

        public AuthController(AuthLogic authLogic)
        {
            _authLogic = authLogic;
        }

        [HttpGet("GetOneUser/{userId}")]
        [Authorize]
        public async Task<MyUser> GetUser(string userId)
        {
            return await this._authLogic.GetUser(userId);
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<MyUser> GetAllUsers()
        {
            return _authLogic.GetAllUsers();
        }

        [HttpPut("microsoft")]
        public async Task<ActionResult> MicrosoftAuth([FromBody] TokenLoginViewModel model)
        {
            try
            {
                return Ok(await _authLogic.LoginUserMicrosoft(model));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPut("UserToRole")]
        [Authorize(Roles = "Admin")]
        public void UserToRole([FromBody] UserRoleViewModel model)
        {
            this._authLogic.UserToRole(model);
        }
    }
}
