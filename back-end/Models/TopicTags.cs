using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Models
{
    public class TopicTags
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TopicTagsID { get; set; }
        public string TopicID { get; set; }
        [JsonIgnore]
        public Topic Topic { get; set; }
        public string TagID { get; set; }
        [JsonIgnore]
        public Tag Tag { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
