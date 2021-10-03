using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
      public interface ITagRepository
      {
            public void Add(Tag tag);
            public void Delete(string id);
            public IQueryable<Tag> GetAll();
            public Tag GetOne(string id);
            public void Update(string id, Tag tag);
      }
}
