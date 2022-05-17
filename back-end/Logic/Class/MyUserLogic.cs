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
    public class MyUserLogic : IMyUserLogic
    {
        private IMyUserRepository myUserRepo;

        public MyUserLogic(string dbPassword)
        {
            this.myUserRepo = new MyUserRepository(dbPassword);
        }

        public MyUserLogic(IMyUserRepository repo)
        {
            this.myUserRepo = repo;
        }

        public bool CreateUser(MyUser myUser)
        {
            try
            {
                this.myUserRepo.Add(myUser);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteUser(string id)
        {
            try
            {
                this.myUserRepo.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool EditUser(string id, MyUser newMyUser)
        {
            try
            {
                this.myUserRepo.Update(id, newMyUser);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<MyUser> GetAllUser()
        {
            return this.myUserRepo.GetAll();
        }

        public ICollection<UserWalletModel> GetAllWallets()
        {
            return this.myUserRepo.GetAllWallets();
        }

        public MyUser GetOneUser(string id)
        {
            return this.myUserRepo.GetOne(id);
        }

        public string GetOneWallet(string id)
        {
            return this.myUserRepo.GetOneWallet(id);
        }

        public bool SetWallet(string id, string address)
        {
            try
            {
                this.myUserRepo.SetWallet(id, address);
                return true;
            }
            catch (DifferentWalletAlreadyConnectedException)
            {
                return false;
            }
        }
    }
}
