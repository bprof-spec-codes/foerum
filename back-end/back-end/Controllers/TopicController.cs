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

        [HttpGet("TopicsOfSubject{subjectId}")]
        public IQueryable<Topic> GetAllTopicsOfSubject(string subjectId)
        {
            return this.topicLogic.GetAllTopicsOfSubject(subjectId);
        }

        [HttpPost]
        public void CreateTopic([FromBody] Topic topic)
        {
            this.topicLogic.CreateTopic(topic);
        }

        [HttpPost("AddTagToTopic{topicId}")]
        public void AddTagToTopic([FromBody] Tag tag, string topicId)
        {
            this.topicLogic.AddTagToTopic(tag, topicId);
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

        [HttpDelete("DeleteTagFromTopic{topicId}")]
        public void DeleteTagFromTopic([FromBody] Tag tag, string topicId)
        {
            this.topicLogic.DeleteTagFromTopic(tag, topicId);
        }
    }
}
