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
    public class CommentTest
    {
        public Mock<ICommentRepository> commentRepository = new Mock<ICommentRepository>();

        [Test]
        public void CreateCommentTest()
        {
            commentRepository.Setup(comment => comment.Add(It.IsAny<Comment>()));

            CommentLogic commentLogic = new CommentLogic();

            Comment comment = new Comment()
            {
                CommentID = "bvadubw89bcyií",
                Content = "Gold",
                CreationDate = DateTime.Now,
                AttachmentUrl = "xxxx",
                ReactionCount = 5,
                CoinReward = 10,
                IsEdited = null,
                IsActive = true,
            };

            commentLogic.CreateComment(comment);
            commentRepository.Verify(repo => repo.Add(comment), Times.Once);
        }

        [Test]
        public void DeleteCommentTest()
        {
            commentRepository.Setup(award => award.Delete(It.IsAny<string>()));

            CommentLogic commentLogic = new CommentLogic();

            Comment comment = new Comment()
            {
                CommentID = "bvadubw89bcyií",
                Content = "Gold",
                CreationDate = DateTime.Now,
                AttachmentUrl = "xxxx",
                ReactionCount = 5,
                CoinReward = 10,
                IsEdited = null,
                IsActive = true,
            };

            commentLogic.DeleteComment(comment.CommentID);
            commentRepository.Verify(repo => repo.Delete(comment.CommentID), Times.Once);
        }

        [Test]
        public void EditCommentTest()
        {
            Comment oldComment = new Comment()
            {
                CommentID = "bvadubw89bcyií",
                Content = "Gold",
                CreationDate = DateTime.Now,
                AttachmentUrl = "xxxx",
                ReactionCount = 5,
                CoinReward = 10,
                IsEdited = null,
                IsActive = true,
            };

            Comment newComment = new Comment()
            {
                CommentID = "oihngw9u947bwe",
                Content = "Silver",
                CreationDate = DateTime.Now,
                AttachmentUrl = "xxxx",
                ReactionCount = 5,
                CoinReward = 10,
                IsEdited = "bvadubw89bcyií",
                IsActive = true,
            };

            commentRepository.Setup(comment => comment.Update(oldComment.CommentID, newComment));

            CommentLogic commentLogic = new CommentLogic();

            commentLogic.EditComment(oldComment.CommentID, newComment);
            commentRepository.Verify(repo => repo.Update(oldComment.CommentID, newComment), Times.Once);
        }

        [Test]
        public void GetOneCommentTest()
        {
            CommentLogic commentLogic = new CommentLogic();

            List<Comment> comments = new List<Comment>()
            {
                new Comment()
                {
                  CommentID = "bvadubw89bcyií",
                  Content = "Gold",
                  CreationDate = DateTime.Now,
                  AttachmentUrl = "xxxx",
                  ReactionCount = 5,
                  CoinReward = 10,
                  IsEdited = null,
                  IsActive = true,
                },
                new Comment()
                {
                  CommentID = "oihngw9u947bwe",
                  Content = "Silver",
                  CreationDate = DateTime.Now,
                  AttachmentUrl = "yyyy",
                  ReactionCount = 5,
                  CoinReward = 10,
                  IsEdited = null,
                  IsActive = true,
                },
                new Comment()
                {
                  CommentID = "8743hsvb9whssgb",
                  Content = "Bronze",
                  CreationDate = DateTime.Now,
                  AttachmentUrl = "zzzz",
                  ReactionCount = 5,
                  CoinReward = 10,
                  IsEdited = null,
                  IsActive = true,
                },
            };

            commentRepository.Setup(comment => comment.GetOne(comments[1].CommentID)).Returns(comments[1]);

            commentLogic.GetOneComment(comments[1].CommentID);
            commentRepository.Verify(repo => repo.GetOne("oihngw9u947bwe"), Times.Once);
        }

        [Test]
        public void GetAllCommentTest()
        {
            CommentLogic commentLogic = new CommentLogic();

            List<Comment> comments = new List<Comment>()
            {
                new Comment()
                {
                  CommentID = "bvadubw89bcyií",
                  Content = "Gold",
                  CreationDate = DateTime.Now,
                  AttachmentUrl = "xxxx",
                  ReactionCount = 5,
                  CoinReward = 10,
                  IsEdited = null,
                  IsActive = true,
                },
                new Comment()
                {
                  CommentID = "oihngw9u947bwe",
                  Content = "Silver",
                  CreationDate = DateTime.Now,
                  AttachmentUrl = "yyyy",
                  ReactionCount = 5,
                  CoinReward = 10,
                  IsEdited = null,
                  IsActive = true,
                },
                new Comment()
                {
                  CommentID = "8743hsvb9whssgb",
                  Content = "Bronze",
                  CreationDate = DateTime.Now,
                  AttachmentUrl = "zzzz",
                  ReactionCount = 5,
                  CoinReward = 10,
                  IsEdited = null,
                  IsActive = true,
                },
            };

            commentRepository.Setup(comment => comment.GetAll()).Returns(comments.AsQueryable());

            commentLogic.GetAllComment();
            commentRepository.Verify(repo => repo.GetAll(), Times.Once);
        }
    }
}
