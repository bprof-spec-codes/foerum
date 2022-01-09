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

        // TODO Register function unneeded?! Probably need some way to add user to db tho.
        [HttpPost]
        public async Task<ActionResult> InsertUser([FromBody] RegisterViewModel model)
        {
            string result = await _authLogic.RegisterUser(model);
            return Ok(new { UserName = result });
        }

        // TODO Input parameter? LoginViewModel, or just string (token)?
        [HttpPut]
        public async Task<ActionResult> Login([FromBody] LoginViewModel model)
        {
            try
            {
                return Ok(await _authLogic.LoginUser(model));
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpGet("GetOneUser/{userId}")]
        public async Task<MyUser> GetUser(string userId)
        {
            return await this._authLogic.GetUser(userId);
        }

        [HttpGet]
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
        public void UserToRole([FromBody] UserRoleViewModel model)
        {
            this._authLogic.UserToRole(model);
        }
    }
}
