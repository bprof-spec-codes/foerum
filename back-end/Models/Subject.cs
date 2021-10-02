using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string SubjectID { get; set; }
        //[ForeignKey("Year")]
        public string YearID { get; set; }
        public string SubjectName { get; set; }
        public bool IsPrivate { get; set; }
        public string InviteKeyIfPrivate { get; set; }
    }
}
