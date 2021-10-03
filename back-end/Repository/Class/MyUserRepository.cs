using Data;
using Models;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Class
{
    public class MyUserRepository : IMyUserRepository
    {
        public FoerumDbContext db;

        public MyUserRepository(string dbPassword)
        {
            this.db = new FoerumDbContext(dbPassword);
        }
        public void Add(MyUser user)
        {
            this.db.Set<MyUser>().Add(user);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            this.db.Set<MyUser>().Remove(this.GetOne(id));
            this.db.SaveChanges();
        }

        public IQueryable<MyUser> GetAll()
        {
            return this.db.Set<MyUser>();
        }

        public MyUser GetOne(string id)
        {
            return this.GetAll().SingleOrDefault(x => x.Id == id);
        }

        public void Update(string id, MyUser user)
        {
            var oldUser = this.GetOne(id);
            if (oldUser == null || user == null)
            {
                throw new ArgumentNullException(nameof(user), nameof(oldUser));
            }
            else
            {
                oldUser.FullName = user.FullName;
                oldUser.NikCoin = user.NikCoin;
                oldUser.StartYear = user.StartYear;
                oldUser.Role = user.Role;
                this.db.SaveChanges();
            }
        }
    }
}
