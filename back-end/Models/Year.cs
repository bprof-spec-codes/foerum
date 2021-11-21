using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Year
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string YearID { get; set; }
        public string YearName { get; set; }
    }
}
