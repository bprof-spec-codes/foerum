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
    class TopicTest
    {
        public Mock<ITopicRepository> topicRepository = new Mock<ITopicRepository>();

        [Test]
        public void CreateTopicTest()
        {
            topicRepository.Setup(comment => comment.Add(It.IsAny<Topic>()));

            TopicLogic topicLogic = new TopicLogic(topicRepository.Object);

            Topic topic = new Topic()
            {
                TopicID = "001",
                SubjectID = "002",
                UserID = "003",
                TopicName = "Test",
                CreationDate = DateTime.Now,
                OfferedCoins = 10,
                AttachmentURL = ""
            };

            topicLogic.CreateTopic(topic);
            topicRepository.Verify(repo => repo.Add(topic), Times.Once);
        }

        [Test]
        public void DeleteCommentTest()
        {
            topicRepository.Setup(comment => comment.Add(It.IsAny<Topic>()));

            TopicLogic topicLogic = new TopicLogic(topicRepository.Object);

            Topic topic = new Topic()
            {
                TopicID = "001",
                SubjectID = "002",
                UserID = "003",
                TopicName = "Test",
                CreationDate = DateTime.Now,
                OfferedCoins = 10,
                AttachmentURL = ""
            };

            topicLogic.DeleteTopic(topic.TopicID);
            topicRepository.Verify(repo => repo.Delete(topic.TopicID), Times.Once);
        }

        [Test]
        public void EditCommentTest()
        {
            Topic oldTopic = new Topic()
            {
                TopicID = "001",
                SubjectID = "002",
                UserID = "003",
                TopicName = "Test",
                CreationDate = DateTime.Now,
                OfferedCoins = 10,
                AttachmentURL = ""
            };

            Topic newTopic = new Topic()
            {
                TopicID = "004",
                SubjectID = "005",
                UserID = "006",
                TopicName = "New test",
                CreationDate = DateTime.Now,
                OfferedCoins = 20,
                AttachmentURL = ""
            };

            topicRepository.Setup(topic => topic.Update(oldTopic.TopicID, newTopic));

            TopicLogic topicLogic = new TopicLogic(topicRepository.Object);

            topicLogic.EditTopic(oldTopic.TopicID, newTopic);
            topicRepository.Verify(repo => repo.Update(oldTopic.TopicID, newTopic), Times.Once);
        }

        [Test]
        public void GetOneCommentTest()
        {
            TopicLogic topicLogic = new TopicLogic(topicRepository.Object);

            List<Topic> topics = new List<Topic>()
            {
                new Topic()
                {
                    TopicID = "001",
                    SubjectID = "002",
                    UserID = "003",
                    TopicName = "Test",
                     CreationDate = DateTime.Now,
                     OfferedCoins = 10,
                      AttachmentURL = ""
                },
                new Topic()
                {
                    TopicID = "002",
                    SubjectID = "003",
                    UserID = "004",
                    TopicName = "Test2",
                    CreationDate = DateTime.Now,
                    OfferedCoins = 20,
                    AttachmentURL = ""
                },
                new Topic()
                {
                  TopicID = "003",
                    SubjectID = "004",
                    UserID = "005",
                    TopicName = "Test3",
                    CreationDate = DateTime.Now,
                    OfferedCoins = 30,
                    AttachmentURL = ""
                },
            };

            topicRepository.Setup(topic => topic.GetOne(topics[1].TopicID)).Returns(topics[1]);

            topicLogic.GetOneTopic(topics[1].TopicID);
            topicRepository.Verify(repo => repo.GetOne("002"), Times.Once);
        }

        [Test]
        public void GetAllCommentTest()
        {
            TopicLogic topicLogic = new TopicLogic(topicRepository.Object);

            List<Topic> topics = new List<Topic>()
            {
                new Topic()
                {
                    TopicID = "001",
                    SubjectID = "002",
                    UserID = "003",
                    TopicName = "Test",
                     CreationDate = DateTime.Now,
                     OfferedCoins = 10,
                      AttachmentURL = ""
                },
                new Topic()
                {
                    TopicID = "002",
                    SubjectID = "003",
                    UserID = "004",
                    TopicName = "Test2",
                    CreationDate = DateTime.Now,
                    OfferedCoins = 20,
                    AttachmentURL = ""
                },
                new Topic()
                {
                  TopicID = "003",
                    SubjectID = "004",
                    UserID = "005",
                    TopicName = "Test3",
                    CreationDate = DateTime.Now,
                    OfferedCoins = 30,
                    AttachmentURL = ""
                },
            };

            topicRepository.Setup(topic => topic.GetAll()).Returns(topics.AsQueryable());

            topicLogic.GetAllTopic();
            topicRepository.Verify(repo => repo.GetAll(), Times.Once);
        }
    }
}
