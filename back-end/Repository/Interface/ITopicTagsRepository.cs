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
        IEnumerable<Tag> GetOneTopicAllTag(string topicId);
        IEnumerable<Topic> GetOneTagAllTopic(string tagId);
    }
}
