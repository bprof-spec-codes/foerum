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
    public class AwardLogic : IAwardLogic
    {
        private IAwardRepository awardRepo;

        public AwardLogic(string dbPassword)
        {
            this.awardRepo = new AwardRepository(dbPassword);
        }

<<<<<<< HEAD
        public AwardLogic(IAwardRepository repo)
        {
            this.awardRepo = repo;
=======
        public AwardLogic()
        {

>>>>>>> test/basic-crud
        }

        public bool CreateAward(Award award)
        {
            try
            {
                this.awardRepo.Add(award);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAward(string id)
        {
            try
            {
                this.awardRepo.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditAward(string id, Award newAward)
        {
            try
            {
                this.awardRepo.Update(id, newAward);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<Award> GetAllAward()
        {
            return this.awardRepo.GetAll();
        }

        public Award GetOneAward(string id)
        {
            return this.awardRepo.GetOne(id);
        }
    }
}
