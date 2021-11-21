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
            public void Add(Topic topic);
            public void Delete(string id);
            public IQueryable<Topic> GetAll();
            public Topic GetOne(string id);
            public void Update(string id, Topic topic);
      }
}
