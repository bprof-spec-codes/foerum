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
    public class Tag
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string TagID { get; set; }
        public string TagName { get; set; }

        [JsonIgnore]
        public virtual ICollection<TopicTags> Topics { get; set; }

        public Tag()
        {
            this.Topics = new HashSet<TopicTags>();
        }
    }
}
