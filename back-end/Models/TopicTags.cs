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
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public string TopicTagsID { get; set; }
        public string TopicID { get; set; }
        public Topic Topic { get; set; }
        public string TagID { get; set; }
        public Tag Tag { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
