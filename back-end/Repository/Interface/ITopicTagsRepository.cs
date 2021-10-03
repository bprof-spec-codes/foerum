using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
      public interface ITopicTagsRepository
      {
            public void Add(TopicTags topicTags);
            public void Delete(string id);
            public IQueryable<TopicTags> GetAll();
            public TopicTags GetOne(string id);
            public void Update(string id, TopicTags topicTags);
      }
}
