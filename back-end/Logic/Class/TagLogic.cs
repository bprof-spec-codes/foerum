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
            try
            {
                this.tagRepo.Add(tag);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteTag(string id)
        {
            try
            {
                this.tagRepo.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditTag(string id, Tag newTag)
        {
            try
            {
                this.tagRepo.Update(id, newTag);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<Tag> GetAllTag()
        {
            return this.tagRepo.GetAll();
        }

        public Tag GetOneTag(string id)
        {
            return this.tagRepo.GetOne(id);
        }
    }
}
