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
        public IEnumerable<string> GetOneTopicAllTag(string topicId);
        public IEnumerable<string> GetOneTagAllTopic(string tagId);
    }
}
