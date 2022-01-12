using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
      public interface ITopicRepository
      {
            void Add(Topic topic);
            void Delete(string id);
            IQueryable<Topic> GetAll();
            Topic GetOne(string id);
            void Update(string id, Topic topic);
            void AddTagToTopic(Tag tag, string topicId);
            void DeleteTagFromTopic(Tag tag, string topicId);
      }
}
