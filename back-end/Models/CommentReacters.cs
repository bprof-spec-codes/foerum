using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CommentReacters
    {
        public string CommentID { get; set; }
        public string UserID { get; set; }
        public int Choice { get; set; } // TODO: bool inkább? legalább byte?
    }
}
