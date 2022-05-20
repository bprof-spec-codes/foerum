using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TransactionEmailOptions
    {
        public string destinationEmail { get; set; }
        public string destinationName { get; set; }
        public int amount { get; set; }
        public string fromUser { get; set; }
        public bool adminTransaction { get; set; }
    }
}
