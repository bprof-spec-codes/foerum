using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Models
{
    public class MyUser : IdentityUser
    {
        public string FullName { get; set; }
        public int NikCoin { get; set; }
        public int StartYear { get; set; }
        public bool IsActive { get; set; }
        [NotMapped]
        public ICollection<MyUserRoles> Role { get; set; }

        public MyUser() : base()
        {
        }

        public MyUser(string userName) : base(userName)
        {
        }
    }
}
