using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
      public class TopicTags
      {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public string TopicID { get; set; }
            public string TagID { get; set; }
            public DateTime CreationDate { get; set; }
      }
}
