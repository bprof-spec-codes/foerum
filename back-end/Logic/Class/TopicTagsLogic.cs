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

        public TopicTagsLogic(ITopicTagsRepository repo)
        {
            this.topicTagsRepo = repo;
        }

        /// TODO: uncomment after repo is implemented
        public bool CreateTopicTags(TopicTags topicTags)
        {
            throw new NotImplementedException();
            /*try
            {
                this.topicTagsRepo.Add(topicTags);
                return true;
            }
            catch
            {
                return false;
            }*/
        }

        public bool DeleteTopicTags(string id)
        {
            throw new NotImplementedException();
            /*try
            {
                this.topicTagsRepo.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }*/
        }

        public bool EditTopicTags(string id, TopicTags newTopicTags)
        {
            throw new NotImplementedException();
            /*try
            {
                this.topicTagsRepo.Update(id, newTopicTags);
                return true;
            }
            catch
            {
                return false;
            }*/
        }

        public IQueryable<TopicTags> GetAllTopicTags()
        {
            throw new NotImplementedException();
            //return this.topicTagsRepo.GetAll();
        }

        public TopicTags GetOneTopicTags(string id)
        {
            throw new NotImplementedException();
            //return this.topicTagsRepo.GetOne(id);
        }
    }
}
