using Logic.Interface;
using Models;
using Repository.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Class
{
      public class TopicLogic : ITopicLogic
      {
            private ITopicRepository topicRepo;

            public TopicLogic(string dbPassword)
            {
                  this.topicRepo = new TopicRepository(dbPassword);
            }
            public bool CreateTopic(Topic topic)
            {
                  throw new NotImplementedException();
            }

            public bool DeleteTopic(string id)
            {
                  throw new NotImplementedException();
            }

            public bool EditTopic(string id, Topic newTopic)
            {
                  throw new NotImplementedException();
            }

            public IQueryable<Topic> GetAllTopic()
            {
                  throw new NotImplementedException();
            }

            public Topic GetOneTopic(string id)
            {
                  throw new NotImplementedException();
            }
      }
}
