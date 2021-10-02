using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Models
{
    class MyUser : IdentityUser
    {
        public string FullName { get; set; }
        public int NikCoin { get; set; }
        public int StartYear { get; set; }
        public bool IsActive { get; set; }
        public IdentityRole Role { get; set; } // TODO: is this how to do it?

        public MyUser() : base()
        {
        }

        public MyUser(string userName) : base(userName)
        {
        }
    }
}
