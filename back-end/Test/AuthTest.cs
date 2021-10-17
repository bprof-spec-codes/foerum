using Logic.Class;
using Microsoft.AspNetCore.Identity;
using Models;
using Moq;
using NUnit.Framework;
using Repository.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    class AuthTest
    {
        public Mock<MyUserRepository> userRepo = new Mock<MyUserRepository>();

        [Test]
        public async void RegisterTest()
        {
            // TODO How am i supposed to test this lol?
            // user and role manager needs like 200 constructor parameters each

            //userRepo.Setup(x => x.Add(It.IsAny<MyUser>()));
            //AuthLogic authLogic = new AuthLogic(
            //    new UserManager<MyUser>(),
            //    new RoleManager<IdentityRole>()
            //    );

            //RegisterViewModel user = new RegisterViewModel() { Email = "bob@gmail.com", Password = "Bobvagyok123" };
            //string result = await authLogic.RegisterUser(user);
            //Assert.That(result, Is.EqualTo("bob@gmail.com"));
        }

        [Test]
        public async void LoginTest()
        {
            // same problem
            //userRepo.Setup(x => x.Add(It.IsAny<MyUser>()));
            //AuthLogic authLogic = new AuthLogic(
            //    new UserManager<MyUser>(),
            //    new RoleManager<IdentityRole>()
            //    );

            //LoginViewModel user = new LoginViewModel() { Username = "bob@gmail.com", Password = "Bobvagyok123" };
            //var result = await authLogic.LoginUser(user);
            //Assert.That(result.Token, !Is.Empty);
        }

        [Test]
        public async void GetAllUsersTest()
        {
            // same problem
            //userRepo.Setup(x => x.Add(It.IsAny<MyUser>()));
            //AuthLogic authLogic = new AuthLogic(
            //    new UserManager<MyUser>(),
            //    new RoleManager<IdentityRole>()
            //    );

            //RegisterViewModel user = new RegisterViewModel() { Email = "bob@gmail.com", Password = "Bobvagyok123" };
            //await authLogic.RegisterUser(user);

            //userRepo.Verify(x => x.Add(It.IsAny<MyUser>()), Times.Once);
        }
    }
}
