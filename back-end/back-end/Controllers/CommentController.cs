using Logic.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Controllers
{
    /* Every controller needs all the CRUD methods */
    [Route("[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private ICommentLogic commentLogic;

        public CommentController(ICommentLogic logic)
        {
            this.commentLogic = logic;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<Comment> GetAllComment()
        {
            return this.commentLogic.GetAllComment();
        }

        [HttpGet("{id}")]
        [Authorize]
        public Comment GetOneComment(string id)
        {
            return this.commentLogic.GetOneComment(id);
        }

<<<<<<< HEAD
        [HttpGet("CommentsOfTopic{topicId}")]
        public IEnumerable<Comment> GetAllCommentsOfTopic(string topicId)
=======
        [HttpGet("GetOneTopicAllComment{topicId}")]
        [Authorize]
        public IEnumerable<Comment> GetOneTopicAllComment(string topicId)
>>>>>>> f8808f83d3cd87f1542f59a7b24398a865c62c58
        {
            return this.commentLogic.GetAllCommentsOfTopic(topicId);
        }

        [HttpPost]
        [Authorize]
        public void CreateComment([FromBody] Comment comment)
        {
            this.commentLogic.CreateComment(comment);
        }

        [HttpPost("AddUserToComment{commentId}")]
        [Authorize]
        public void AddUserToComment([FromBody] MyUser user, string commentId)
        {
            this.commentLogic.AddUserToComment(user, commentId);
        }

        [HttpPut("{id}")]
        [Authorize]
        public void EditComment(string id, [FromBody] Comment newComment)
        {
            this.commentLogic.EditComment(id, newComment);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public void DeleteComment(string id)
        {
            this.commentLogic.DeleteComment(id);
        }

        [HttpDelete("DeleteUserFromComment{commentId}")]
        [Authorize(Roles = "Admin")]
        public void DeleteUserFromComment([FromBody] MyUser user, string commentId)
        {
            this.commentLogic.DeleteUserFromComment(user, commentId);
        }
    }
}
