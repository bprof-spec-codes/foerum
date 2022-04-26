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
    [Route("[controller]")]
    [ApiController]
    public class CommentReactersController : ControllerBase
    {
        private ICommentReactersLogic commentReactersLogic;

        public CommentReactersController(ICommentReactersLogic logic)
        {
            this.commentReactersLogic = logic;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IEnumerable<CommentReacters> GetAllCommentReacters()
        {
            return this.commentReactersLogic.GetAllCommentReacters();
        }

        [HttpGet("{id}")]
        [Authorize]
        public Comment GetOneCommentReacters(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Authorize]
        public void CreateCommentReacters([FromBody] CommentReacters commentReacters)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        [Authorize]
        public void EditCommentReacters(string id, [FromBody] Comment newCommentReacters)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public Comment DeleteCommentReacters(string id)
        {
            throw new NotImplementedException();
        }
    }
}
