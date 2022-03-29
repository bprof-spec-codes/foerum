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
    public class TopicController : ControllerBase
    {
        private ITopicLogic topicLogic;

        public TopicController(ITopicLogic logic)
        {
            this.topicLogic = logic;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<Topic> GetAllTopic()
        {
            return this.topicLogic.GetAllTopic();
        }

        [HttpGet("{id}")]
        [Authorize]
        public Topic GetOneTopic(string id)
        {
            return this.topicLogic.GetOneTopic(id);
        }

        [HttpPost]
        [Authorize]
        public void CreateTopic([FromBody] Topic topic)
        {
            this.topicLogic.CreateTopic(topic);
        }

        [HttpPost("AddTagToTopic{topicId}")]
        [Authorize]
        public void AddTagToTopic([FromBody] Tag tag, string topicId)
        {
            this.topicLogic.AddTagToTopic(tag, topicId);
        }

        [HttpPut("{id}")]
        [Authorize]
        public void EditTopic(string id, [FromBody] Topic newTopic)
        {
            this.topicLogic.EditTopic(id, newTopic);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public void DeleteTopic(string id)
        {
            this.topicLogic.DeleteTopic(id);
        }

        [HttpDelete("DeleteTagFromTopic{topicId}")]
        [Authorize]
        public void DeleteTagFromTopic([FromBody] Tag tag, string topicId)
        {
            this.topicLogic.DeleteTagFromTopic(tag, topicId);
        }
    }
}
