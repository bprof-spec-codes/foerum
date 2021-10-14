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
    public class TopicController : ControllerBase
    {
        private ITopicLogic topicLogic;

        public TopicController(ITopicLogic logic)
        {
            this.topicLogic = logic;
        }

        [HttpGet]
        public IEnumerable<Topic> GetAllTopic()
        {
            return this.topicLogic.GetAllTopic();
        }

        [HttpGet("{id}")]
        public Topic GetOneTopic(string id)
        {
            return this.topicLogic.GetOneTopic(id);
        }

        [HttpPost]
        public void CreateTopic(Topic topic)
        {
            this.topicLogic.CreateTopic(topic);
        }

        [HttpPut("{id}")]
        public void EditTopic(string id, [FromBody] Topic newTopic)
        {
            this.topicLogic.EditTopic(id, newTopic);
        }

        [HttpDelete("{id}")]
        public void DeleteTopic(string id)
        {
            this.topicLogic.DeleteTopic(id);
        }
    }
}
