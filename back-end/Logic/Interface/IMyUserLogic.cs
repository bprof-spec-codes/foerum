using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Interface
{
      public interface IMyUserLogic
      {
            IQueryable<MyUser> GetAllUser();
            MyUser GetOneUser(string id);
            bool CreateUser(MyUser myUser);
            bool EditUser(string id, MyUser newMyUser);
            bool DeleteUser(string id);
            bool SetWallet(string id, string address);
      }
}
