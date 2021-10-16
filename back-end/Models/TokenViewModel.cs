using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TokenViewModel
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }

    public class TokenLoginViewModel
    {
        public string Name { get; set; }
        public string uniqueName { get; set; }
    }
}
