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
      public class TopicTagsController : ControllerBase
      {
            private ITopicTagsLogic topicTagsLogic;

            public TopicTagsController(ITopicTagsLogic logic)
            {
                  this.topicTagsLogic = logic;
            }

            [HttpGet]
            public IEnumerable<TopicTags> GetAllTopicTags()
            {
                  return this.topicTagsLogic.GetAllTopicTags();
            }

            [HttpGet("{id}")]
            public TopicTags GetOneTopicTags(string id)
            {
                  throw new NotImplementedException();
            }

            [HttpPost]
            public void CreateTopicTags(TopicTags topicTags)
            {
                  throw new NotImplementedException();
            }

            [HttpPut("{id}")]
            public void EditTopicTags(string id, [FromBody] TopicTags newTopicTags)
            {
                  throw new NotImplementedException();
            }

            [HttpDelete("{id}")]
            public TopicTags DeleteTopicTags(string id)
            {
                  throw new NotImplementedException();
            }
      }
}
