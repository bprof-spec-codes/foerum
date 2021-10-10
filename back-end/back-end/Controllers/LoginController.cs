using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpGet]
        public IActionResult IsUserLoggedIn()
        {
            if (!this.HttpContext.User.Identity.IsAuthenticated)
            {
                return this.Unauthorized();
            }
            return this.Accepted();
        }

        [AllowAnonymous]
        [HttpGet("Authenticate")]
        public async Task Login()
        {
            if (!this.HttpContext.User.Identity.IsAuthenticated)
            {
                this.HttpContext.Items.Add("allowRedirect", true);
                await this.HttpContext.ChallengeAsync();
                return;
            }

            // TODO URL change
            this.HttpContext.Response.Redirect("http://localhost:8585/");
        }
    }
}
