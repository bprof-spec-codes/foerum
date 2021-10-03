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
      public class TopicTagsLogic : ITopicTagsLogic
      {
            private ITopicTagsRepository topicTagsRepo;

            public TopicTagsLogic(string dbPassword)
            {
                  this.topicTagsRepo = new TopicTagsRepository(dbPassword);
            }
            public bool CreateTopicTags(TopicTags topicTags)
            {
                  throw new NotImplementedException();
            }

            public bool DeleteTopicTags(string id)
            {
                  throw new NotImplementedException();
            }

            public bool EditTopicTags(string id, TopicTags newTopicTags)
            {
                  throw new NotImplementedException();
            }

            public IQueryable<TopicTags> GetAllTopicTags()
            {
                  throw new NotImplementedException();
            }

            public TopicTags GetOneTopicTags(string id)
            {
                  throw new NotImplementedException();
            }
      }
}
