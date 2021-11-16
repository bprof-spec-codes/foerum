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
        public IEnumerable<Tag> GetOneTopicAllTag(string topicId);
        public IEnumerable<Topic> GetOneTagAllTopic(string tagId);
    }
}
