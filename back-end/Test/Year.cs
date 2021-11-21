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
    class YearTest
    {
        public Mock<IYearRepository> yearRepository = new Mock<IYearRepository>();

        [Test]
        public void CreateYearTest()
        {
            yearRepository.Setup(comment => comment.Add(It.IsAny<Year>()));

            YearLogic yearLogic = new YearLogic(yearRepository.Object);

            Year year = new Year()
            {
                YearID = "001"
            };

            yearLogic.CreateYear(year);
            yearRepository.Verify(repo => repo.Add(year), Times.Once);
        }

        [Test]
        public void DeleteCommentTest()
        {
            yearRepository.Setup(comment => comment.Add(It.IsAny<Year>()));

            YearLogic yearLogic = new YearLogic(yearRepository.Object);

            Year year = new Year()
            {
                YearID = "001"
            };

            yearLogic.DeleteYear(year.YearID);
            yearRepository.Verify(repo => repo.Delete(year.YearID), Times.Once);
        }

        [Test]
        public void EditCommentTest()
        {
            Year oldYear = new Year()
            {
                YearID = "001"
            };

            Year newYear = new Year()
            {
                YearID = "004"
            };

            yearRepository.Setup(year => year.Update(oldYear.YearID, newYear));

            YearLogic yearLogic = new YearLogic(yearRepository.Object);

            yearLogic.EditYear(oldYear.YearID, newYear);
            yearRepository.Verify(repo => repo.Update(oldYear.YearID, newYear), Times.Once);
        }

        [Test]
        public void GetOneCommentTest()
        {
            YearLogic yearLogic = new YearLogic(yearRepository.Object);

            List<Year> years = new List<Year>()
            {
                new Year()
                {
                    YearID = "001"
                },
                new Year()
                {
                    YearID = "002"
                },
                new Year()
                {
                  YearID = "003"
                },
            };

            yearRepository.Setup(year => year.GetOne(years[1].YearID)).Returns(years[1]);

            yearLogic.GetOneYear(years[1].YearID);
            yearRepository.Verify(repo => repo.GetOne("002"), Times.Once);
        }

        [Test]
        public void GetAllCommentTest()
        {
            YearLogic yearLogic = new YearLogic(yearRepository.Object);

            List<Year> years = new List<Year>()
            {
                new Year()
                {
                    YearID = "001"
                },
                new Year()
                {
                    YearID = "002"
                },
                new Year()
                {
                  YearID = "003"
                },
            };

            yearRepository.Setup(year => year.GetAll()).Returns(years.AsQueryable());

            yearLogic.GetAllYear();
            yearRepository.Verify(repo => repo.GetAll(), Times.Once);
        }
    }
}
