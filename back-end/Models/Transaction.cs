using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TransactionID { get; set; }
        public string Source { get; set; } // UserID
        public string Recipient { get; set; } // UserID
        public int Quantity { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Reason { get; set; }
    }
}
