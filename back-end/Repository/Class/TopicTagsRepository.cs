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
      public class TopicTagsRepository : ITopicTagsRepository
      {
            public FoerumDbContext db;

            public TopicTagsRepository(string dbPassword)
            {
                  this.db = new FoerumDbContext(dbPassword);
            }
            public void Add(TopicTags topicTags)
            {
                  throw new NotImplementedException();
            }

            public void Delete(string id)
            {
                  throw new NotImplementedException();
            }

            public IQueryable<TopicTags> GetAll()
            {
                  throw new NotImplementedException();
            }

            public TopicTags GetOne(string id)
            {
                  throw new NotImplementedException();
            }

            public void Update(string id, TopicTags topicTags)
            {
                  throw new NotImplementedException();
            }
      }
}
