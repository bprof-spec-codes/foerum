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
            void Add(Tag tag);
            void Delete(string id);
            IQueryable<Tag> GetAll();
            Tag GetOne(string id);
            void Update(string id, Tag tag);
      }
}
