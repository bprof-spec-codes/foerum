using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
      public class Comment
      {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public string CommentID { get; set; }
            public string TopicID { get; set; }
            public string UserID { get; set; }
            public string Content { get; set; }
            public DateTime CreationDate { get; set; }
            public string AttachmentUrl { get; set; }
            public int ReactionCount { get; set; }
            public string? ReplyToCommentID { get; set; }
            public int? CoinReward { get; set; }
            public string? IsEdited { get; set; }
            public bool IsActive { get; set; }

      }
}
