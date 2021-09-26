using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Controllers
{
      public class AuthController : ControllerBase
      {
            [HttpGet]
            public string Index()
            {
                  return "";
            }
      }
}
