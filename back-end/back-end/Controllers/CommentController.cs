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
            private ICommentLogic commnetLogic;

            public CommentController(ICommentLogic logic)
            {
                  this.commnetLogic = logic;
            }

            [HttpGet]
            public IEnumerable<Comment> GetAllComment()
            {
                  return this.commnetLogic.GetAllComment();
            }

            [HttpGet("{id}")]
            public Comment GetOneComment(string id)
            {
                  throw new NotImplementedException();
            }

            [HttpPost]
            public void CreateComment(Comment comment)
            {
                  throw new NotImplementedException();
            }

            [HttpPut("{id}")]
            public void EditComment(string id, [FromBody] Comment newComment)
            {
                  throw new NotImplementedException();
            }

            [HttpDelete("{id}")]
            public Comment DeleteComment(string id)
            {
                  throw new NotImplementedException();
            }
      }
}
