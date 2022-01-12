using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class MyRole : IdentityRole<int>
    {
        public ICollection<MyUserRoles> UserRoles { get; set; }
    }
}
