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

        public TopicLogic(ITopicRepository repo)
        {
            this.topicRepo = repo;
        }

        public bool CreateTopic(Topic topic)
        {
            try
            {
                this.topicRepo.Add(topic);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteTopic(string id)
        {
            try
            {
                this.topicRepo.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditTopic(string id, Topic newTopic)
        {
            try
            {
                this.topicRepo.Update(id, newTopic);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<Topic> GetAllTopic()
        {
            return this.topicRepo.GetAll();
        }

        public Topic GetOneTopic(string id)
        {
            return this.topicRepo.GetOne(id);
        }

        public void AddTagToTopic(Tag tag, string topicId)
        {
            this.topicRepo.AddTagToTopic(tag, topicId);
        }

        public void DeleteTagFromTopic(Tag tag, string topicId)
        {
            this.topicRepo.DeleteTagFromTopic(tag, topicId);
        }
    }
}
