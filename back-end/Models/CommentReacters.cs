using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
      public class CommentReacters
      {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public string CommentReactersID { get; set; }
            public string CommentID { get; set; }
            public string UserID { get; set; }
            public int Choice { get; set; } // TODO: bool inkább? legalább byte?
      }
}
