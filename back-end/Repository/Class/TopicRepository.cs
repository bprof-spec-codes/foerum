using Data;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Class
{
    public class TopicRepository : ITopicRepository
    {
        public FoerumDbContext db;

        public TopicRepository(string dbPassword)
        {
            this.db = new FoerumDbContext(dbPassword);
        }
        public void Add(Topic topic)
        {
            this.db.Set<Topic>().Add(topic);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            this.db.Set<Topic>().Remove(this.GetOne(id));
            this.db.SaveChanges();
        }

        public IQueryable<Topic> GetAll()
        {
            return this.db.Set<Topic>();
        }

        public Topic GetOne(string id)
        {
            return this.GetAll().SingleOrDefault(x => x.TopicID == id);
        }

        public void Update(string id, Topic topic)
        {
            var oldTopic = this.GetOne(id);
            if (oldTopic == null || topic == null)
            {
                throw new ArgumentNullException(nameof(topic), nameof(oldTopic));
            }
            else
            {
                oldTopic.TopicName = topic.TopicName;
                oldTopic.CreationDate = DateTime.Now;
                oldTopic.OfferedCoins = topic.OfferedCoins;
                oldTopic.AttachmentURL = topic.AttachmentURL;
                this.db.SaveChanges();
            }
        }

        public void AddTagToTopic(Tag tag, string topicId)
        {
            this.GetOne(topicId).Tags.Add(new TopicTags { TagID = tag.TagID });
            this.db.SaveChanges();
        }

        public void DeleteTagFromTopic(Tag tag, string topicId)
        {
            TopicTags topicTags = this.GetOne(topicId).Tags.FirstOrDefault(tag => tag.TagID == tag.TagID);
            if (topicTags != null)
            {
                this.GetOne(topicId).Tags.Remove(topicTags);
                this.db.SaveChanges();
            }
        }
    }
}
