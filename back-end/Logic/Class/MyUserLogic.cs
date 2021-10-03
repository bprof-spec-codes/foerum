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
            public bool CreateUser(MyUser myUser)
            {
                  throw new NotImplementedException();
            }

            public bool DeleteUser(string id)
            {
                  throw new NotImplementedException();
            }

            public bool EditUser(string id, MyUser newMyUser)
            {
                  throw new NotImplementedException();
            }

            public IQueryable<MyUser> GetAllUser()
            {
                  throw new NotImplementedException();
            }

            public MyUser GetOneUser(string id)
            {
                  throw new NotImplementedException();
            }
      }
}
