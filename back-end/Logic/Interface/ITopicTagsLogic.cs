using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interface
{
      public interface ITopicTagsLogic
      {
            IQueryable<TopicTags> GetAllTopicTags();
            TopicTags GetOneTopicTags(string id);
            bool CreateTopicTags(TopicTags topicTags);
            bool EditTopicTags(string id, TopicTags newTopicTags);
            bool DeleteTopicTags(string id);
      }
}
