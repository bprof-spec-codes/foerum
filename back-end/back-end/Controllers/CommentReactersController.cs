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
    public class CommentReactersController : ControllerBase
    {
        private ICommentReactersLogic commentReactersLogic;

        public CommentReactersController(ICommentReactersLogic logic)
        {
            this.commentReactersLogic = logic;
        }

        [HttpGet]
        public IEnumerable<CommentReacters> GetAllCommentReacters()
        {
            return this.commentReactersLogic.GetAllCommentReacters();
        }

        [HttpGet("{id}")]
        public Comment GetOneCommentReacters(string id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public void CreateCommentReacters(CommentReacters commentReacters)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public void EditCommentReacters(string id, [FromBody] Comment newCommentReacters)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public Comment DeleteCommentReacters(string id)
        {
            throw new NotImplementedException();
        }
    }
}
