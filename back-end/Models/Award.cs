using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Award
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AwardID { get; set; }
        public string AwardName { get; set; }
        //TODO: prop CommentID (FK), UserID(FK)?
        public int Points { get; set; }
        public string IconUrl { get; set; }
    }
}
