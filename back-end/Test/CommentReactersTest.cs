using Logic;
using Logic.Class;
using Models;
using Moq;
using NUnit.Framework;
using Repository.Class;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestFixture]
    class CommentReactersTest
    {
        // !----------------------------------------------------------------------------!
        /* NotImplementedException in logic and repo. TODO: do after beingimplemented. */
        // !----------------------------------------------------------------------------!

        /*
        public Mock<ICommentReactersRepository> commentReactersRepository = new Mock<ICommentReactersRepository>();
        
        [Test]
        public void GetOneUserAllCommentTest()
        {
            // TODO
        }

        [Test]
        public void GetOneCommentAllUserTest()
        {
            CommentReactersLogic commentReactersLogic = new CommentReactersLogic(commentReactersRepository.Object);

            List<CommentReacters> commentReacters = new List<CommentReacters>()
            {
                new CommentReacters()
                {
                    CommentReactersID = "001",
                    CommentID = "01",
                    UserID = "1"
                },
                new CommentReacters()
                {
                    CommentReactersID = "002",
                    CommentID = "01",
                    UserID = "2"
                },
                new CommentReacters()
                {
                  CommentReactersID = "003",
                    CommentID = "01",
                    UserID = "3"
                },
            };

            commentReactersRepository
                .Setup(commentReacters => commentReacters.GetOneCommentAllUser("01"))
                .Returns(commentReacters
                .Where(x => x.CommentID == "01")
                .Select(x => x.UserID));

            commentReactersLogic.GetOneCommentAllUser("01");
            commentReactersRepository.Verify(repo => repo.GetOneCommentAllUser("01"), Times.Once);
        }

        [Test]
        public void CreateCommentReactersTest()
        {
            commentReactersRepository.Setup(comment => comment.Add(It.IsAny<CommentReacters>()));

            CommentReactersLogic commentReactersLogic = new CommentReactersLogic(commentReactersRepository.Object);

            CommentReacters commentReacters = new CommentReacters()
            {
                CommentReactersID = "001"
            };

            commentReactersLogic.CreateCommentReacters(commentReacters);
            commentReactersRepository.Verify(repo => repo.Add(commentReacters), Times.Once);
        }

        [Test]
        public void DeleteCommentTest()
        {
            commentReactersRepository.Setup(comment => comment.Add(It.IsAny<CommentReacters>()));

            CommentReactersLogic commentReactersLogic = new CommentReactersLogic(commentReactersRepository.Object);

            CommentReacters commentReacters = new CommentReacters()
            {
                CommentReactersID = "001"
            };

            commentReactersLogic.DeleteCommentReacters(commentReacters.CommentReactersID);
            commentReactersRepository.Verify(repo => repo.Delete(commentReacters.CommentReactersID), Times.Once);
        }

        [Test]
        public void EditCommentTest()
        {
            CommentReacters oldCommentReacters = new CommentReacters()
            {
                CommentReactersID = "001"
            };

            CommentReacters newCommentReacters = new CommentReacters()
            {
                CommentReactersID = "004"
            };

            commentReactersRepository.Setup(commentReacters => commentReacters.Update(oldCommentReacters.CommentReactersID, newCommentReacters));

            CommentReactersLogic commentReactersLogic = new CommentReactersLogic(commentReactersRepository.Object);

            commentReactersLogic.EditCommentReacters(oldCommentReacters.CommentReactersID, newCommentReacters);
            commentReactersRepository.Verify(repo => repo.Update(oldCommentReacters.CommentReactersID, newCommentReacters), Times.Once);
        }

        [Test]
        public void GetOneCommentTest()
        {
            CommentReactersLogic commentReactersLogic = new CommentReactersLogic(commentReactersRepository.Object);

            List<CommentReacters> commentReacterss = new List<CommentReacters>()
            {
                new CommentReacters()
                {
                    CommentReactersID = "001"
                },
                new CommentReacters()
                {
                    CommentReactersID = "002"
                },
                new CommentReacters()
                {
                  CommentReactersID = "003"
                },
            };

            commentReactersRepository.Setup(commentReacters => commentReacters.GetOne(commentReacterss[1].CommentReactersID)).Returns(commentReacterss[1]);

            commentReactersLogic.GetOneCommentReacters(commentReacterss[1].CommentReactersID);
            commentReactersRepository.Verify(repo => repo.GetOne("002"), Times.Once);
        }

        [Test]
        public void GetAllCommentTest()
        {
            CommentReactersLogic commentReactersLogic = new CommentReactersLogic(commentReactersRepository.Object);

            List<CommentReacters> commentReacterss = new List<CommentReacters>()
            {
                new CommentReacters()
                {
                    CommentReactersID = "001"
                },
                new CommentReacters()
                {
                    CommentReactersID = "002"
                },
                new CommentReacters()
                {
                  CommentReactersID = "003"
                },
            };

            commentReactersRepository.Setup(commentReacters => commentReacters.GetAll()).Returns(commentReacterss.AsQueryable());

            commentReactersLogic.GetAllCommentReacters();
            commentReactersRepository.Verify(repo => repo.GetAll(), Times.Once);
        }
        */
    }
}
