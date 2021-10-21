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
    public class AwardTest
    {
        public Mock<IAwardRepository> awardRepository = new Mock<IAwardRepository>();

        [Test]
        public void CreateAwardTest()
        {
            awardRepository.Setup(award => award.Add(It.IsAny<Award>()));

            AwardLogic awardLogic = new AwardLogic();

            Award award = new Award()
            {
                AwardID = "bvadubw89bcyií",
                AwardName = "Gold",
                Points = 10,
                IconUrl = "xxxx",
            };

            awardLogic.CreateAward(award);
            awardRepository.Verify(repo => repo.Add(award), Times.Once);
        }

        [Test]
        public void DeleteAwardTest()
        {
            this.awardRepository.Setup(award => award.Delete(It.IsAny<string>()));

            AwardLogic awardLogic = new AwardLogic();

            Award award = new Award()
            {
                AwardID = "bvadubw89bcyií",
                AwardName = "GoldAward",
                Points = 10,
                IconUrl = "xxxx",
            };

            awardLogic.DeleteAward(award.AwardID);
            awardRepository.Verify(repo => repo.Delete(award.AwardID), Times.Once);
        }

        [Test]
        public void EditAwardTest()
        {
            Award oldAward = new Award()
            {
                AwardID = "bvadubw89bcyií",
                AwardName = "Gold",
                Points = 10,
                IconUrl = "xxxx",
            };

            Award newAward = new Award()
            {
                AwardName = "Gold",
                Points = 12,
                IconUrl = "xxxx",
            };

            awardRepository.Setup(player => player.Update(oldAward.AwardID, newAward));

            AwardLogic awardLogic = new AwardLogic();

            awardLogic.EditAward(oldAward.AwardID, newAward);
            awardRepository.Verify(repo => repo.Update(oldAward.AwardID, newAward), Times.Once);
        }

        [Test]
        public void GetOneAwardTest()
        {
            AwardLogic awardLogic = new AwardLogic();

            List<Award> awards = new List<Award>()
            {
                new Award()
                {
                  AwardID = "bvadubw89bcyií",
                  AwardName = "Gold",
                  Points = 10,
                  IconUrl = "xxxx",
                },
                new Award()
                {
                  AwardID = "oihngw9u947bwe",
                  AwardName = "Silver",
                  Points = 6,
                  IconUrl = "yyyy",
                },
                new Award()
                {
                  AwardID = "8743hsvb9whssgb",
                  AwardName = "Bronze",
                  Points = 3,
                  IconUrl = "zzzz",
                },
            };

            awardRepository.Setup(award => award.GetOne(awards[1].AwardID)).Returns(awards[1]);

            awardLogic.GetOneAward(awards[1].AwardID);
            awardRepository.Verify(repo => repo.GetOne("oihngw9u947bwe"), Times.Once);
        }

        [Test]
        public void GetAllAwardTest()
        {
            AwardLogic awardLogic = new AwardLogic();

            List<Award> awards = new List<Award>()
            {
                new Award()
                {
                  AwardID = "bvadubw89bcyií",
                  AwardName = "Gold",
                  Points = 10,
                  IconUrl = "xxxx",
                },
                new Award()
                {
                  AwardID = "oihngw9u947bwe",
                  AwardName = "Silver",
                  Points = 6,
                  IconUrl = "yyyy",
                },
                new Award()
                {
                  AwardID = "8743hsvb9whssgb",
                  AwardName = "Bronze",
                  Points = 3,
                  IconUrl = "zzzz",
                },
            };

            awardRepository.Setup(award => award.GetAll()).Returns(awards.AsQueryable());

            awardLogic.GetAllAward();
            awardRepository.Verify(repo => repo.GetAll(), Times.Once);
        }
    }
}
