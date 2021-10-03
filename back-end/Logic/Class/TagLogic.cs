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
      public class TagLogic : ITagLogic
      {
            private ITagRepository tagRepo;

            public TagLogic(string dbPassword)
            {
                  this.tagRepo = new TagRepository(dbPassword);
            }
            public bool CreateTag(Tag tag)
            {
                  throw new NotImplementedException();
            }

            public bool DeleteTag(string id)
            {
                  throw new NotImplementedException();
            }

            public bool EditTag(string id, Tag newTag)
            {
                  throw new NotImplementedException();
            }

            public IQueryable<Tag> GetAllTag()
            {
                  throw new NotImplementedException();
            }

            public Tag GetOneTag(string id)
            {
                  throw new NotImplementedException();
            }
      }
}
