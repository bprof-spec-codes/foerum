using Data;
using Models;
using Repository.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class YearLogic : IYearLogic
    {
        private IYearRepository yearRepo;

        public YearLogic(string dbPassword)
        {
            this.yearRepo = new YearRepository(dbPassword);
        }

        public YearLogic(IYearRepository repo)
        {
            this.yearRepo = repo;
        }

        public bool CreateYear(Year year)
        {
            try
            {
                this.yearRepo.Add(year);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteYear(string id)
        {
            try
            {
                this.yearRepo.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditYear(string id, Year newYear)
        {
            try
            {
                this.yearRepo.Update(id, newYear);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<Year> GetAllYear()
        {
            return this.yearRepo.GetAll();
        }

        public Year GetOneYear(string id)
        {
            return this.yearRepo.GetOne(id);
        }
    }
}
