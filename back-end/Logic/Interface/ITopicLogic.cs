using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interface
{
      public interface ITopicLogic
      {
            IQueryable<Topic> GetAllTopic();
            Topic GetOneTopic(string id);
            bool CreateTopic(Topic topic);
            bool EditTopic(string id, Topic newTopic);
            bool DeleteTopic(string id);
      }
}
