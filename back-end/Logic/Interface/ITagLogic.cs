using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interface
{
      public interface ITagLogic
      {
            IQueryable<Tag> GetAllTag();
            Tag GetOneTag(string id);
            bool CreateTag(Tag tag);
            bool EditTag(string id, Tag newTag);
            bool DeleteTag(string id);
      }
}
