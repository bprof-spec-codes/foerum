using Logic.Interface;
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
        public IEnumerable<Comment> GetAllComment()
        {
            return this.commentLogic.GetAllComment();
        }

        [HttpGet("{id}")]
        public Comment GetOneComment(string id)
        {
            return this.commentLogic.GetOneComment(id);
        }

        [HttpPost]
        public void CreateComment([FromBody] Comment comment)
        {
            this.commentLogic.CreateComment(comment);
        }

        [HttpPut("{id}")]
        public void EditComment(string id, [FromBody] Comment newComment)
        {
            this.commentLogic.EditComment(id, newComment);
        }

        [HttpDelete("{id}")]
        public void DeleteComment(string id)
        {
            this.commentLogic.DeleteComment(id);
        }
    }
}
