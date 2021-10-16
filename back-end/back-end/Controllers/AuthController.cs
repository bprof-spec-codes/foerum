using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Controllers
{
      [Route("[controller]")]
      [ApiController]
      public class AuthController : ControllerBase
      {
            [HttpPost("microsoft")]
            public void MicrosoftAuth()
            {
                  var token = Request.Form.First(x => x.Key == "id_token").Value;
                  var handler = new JwtSecurityTokenHandler();
                  var jwtSecurityToken = handler.ReadJwtToken(token);
                  var userame = jwtSecurityToken.Claims.First(x => x.Type == "email").Value;
                  TokenValidationParameters validationParameters = new TokenValidationParameters
                  {
                        ValidAudience = "4ad30f8a-47fc-41a7-b80e-63d57e0e9f37",
                        ValidateAudience = true,
                        ValidateIssuer = false,
                        ValidateLifetime = true
                  };
                  SecurityToken asd2;
                  var asd = handler.ValidateToken(token, validationParameters, out asd2);
            }
      }
}
