using Logic;
using Logic.Class;
using Models;
using Moq;
using NUnit.Framework;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    class MyUserTest
    {
        public Mock<IMyUserRepository> myUserRepository = new Mock<IMyUserRepository>();

        [Test]
        public void CreateMyUserTest()
        {
            myUserRepository.Setup(comment => comment.Add(It.IsAny<MyUser>()));

            MyUserLogic myUserLogic = new MyUserLogic(myUserRepository.Object);

            MyUser myUser = new MyUser()
            {
                Id = "001"
            };

            myUserLogic.CreateUser(myUser);
            myUserRepository.Verify(repo => repo.Add(myUser), Times.Once);
        }

        [Test]
        public void DeleteCommentTest()
        {
            myUserRepository.Setup(comment => comment.Add(It.IsAny<MyUser>()));

            MyUserLogic myUserLogic = new MyUserLogic(myUserRepository.Object);

            MyUser myUser = new MyUser()
            {
                Id = "001"
            };

            myUserLogic.DeleteUser(myUser.Id);
            myUserRepository.Verify(repo => repo.Delete(myUser.Id), Times.Once);
        }

        [Test]
        public void EditCommentTest()
        {
            MyUser oldMyUser = new MyUser()
            {
                Id = "001"
            };

            MyUser newMyUser = new MyUser()
            {
                Id = "004"
            };

            myUserRepository.Setup(myUser => myUser.Update(oldMyUser.Id, newMyUser));

            MyUserLogic myUserLogic = new MyUserLogic(myUserRepository.Object);

            myUserLogic.EditUser(oldMyUser.Id, newMyUser);
            myUserRepository.Verify(repo => repo.Update(oldMyUser.Id, newMyUser), Times.Once);
        }

        [Test]
        public void GetOneCommentTest()
        {
            MyUserLogic myUserLogic = new MyUserLogic(myUserRepository.Object);

            List<MyUser> myUsers = new List<MyUser>()
            {
                new MyUser()
                {
                    Id = "001"
                },
                new MyUser()
                {
                    Id = "002"
                },
                new MyUser()
                {
                  Id = "003"
                },
            };

            myUserRepository.Setup(myUser => myUser.GetOne(myUsers[1].Id)).Returns(myUsers[1]);

            myUserLogic.GetOneUser(myUsers[1].Id);
            myUserRepository.Verify(repo => repo.GetOne("002"), Times.Once);
        }

        [Test]
        public void GetAllCommentTest()
        {
            MyUserLogic myUserLogic = new MyUserLogic(myUserRepository.Object);

            List<MyUser> myUsers = new List<MyUser>()
            {
                new MyUser()
                {
                    Id = "001"
                },
                new MyUser()
                {
                    Id = "002"
                },
                new MyUser()
                {
                  Id = "003"
                },
            };

            myUserRepository.Setup(myUser => myUser.GetAll()).Returns(myUsers.AsQueryable());

            myUserLogic.GetAllUser();
            myUserRepository.Verify(repo => repo.GetAll(), Times.Once);
        }
    }
}
