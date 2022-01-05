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
    public class SubjectUsers
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string SubjectUsersID { get; set; }
        public string SubjectID { get; set; }
        [JsonIgnore]
        public Subject Subject { get; set; }
        public string UserID { get; set; }
        [JsonIgnore]
        public MyUser User { get; set; }
    }
}
