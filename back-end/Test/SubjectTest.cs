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
    public class SubjectTest
    {
        public Mock<ISubjectRepository> subjectRepository = new Mock<ISubjectRepository>();

        [Test]
        public void CreateSubjectTest()
        {
            subjectRepository.Setup(subject => subject.Add(It.IsAny<Subject>()));

            SubjectLogic subjectLogic = new SubjectLogic();

            Subject subject = new Subject()
            {
                SubjectID = "bvadubw89bcyií",
                SubjectName = "Programming",
                IsPrivate = false,
            };

            subjectLogic.CreateSubject(subject);
            subjectRepository.Verify(repo => repo.Add(subject), Times.Once);
        }

        [Test]
        public void DeleteSubjectTest()
        {
            this.subjectRepository.Setup(subject => subject.Delete(It.IsAny<string>()));

            SubjectLogic subjectLogic = new SubjectLogic();

            Subject subject = new Subject()
            {
                SubjectID = "bvadubw89bcyií",
                SubjectName = "Programming",
                IsPrivate = false,
            };

            subjectLogic.DeleteSubject(subject.SubjectID);
            subjectRepository.Verify(repo => repo.Delete(subject.SubjectID), Times.Once);
        }

        [Test]
        public void EditSubjectTest()
        {
            Subject oldSubject = new Subject()
            {
                SubjectID = "bvadubw89bcyií",
                SubjectName = "Programming",
                IsPrivate = false,
            };

            Subject newSubject = new Subject()
            {
                SubjectName = "Programming II.",
                IsPrivate = false,
            };

            subjectRepository.Setup(subject => subject.Update(oldSubject.SubjectID, newSubject));

            SubjectLogic subjectLogic = new SubjectLogic();

            subjectLogic.EditSubject(oldSubject.SubjectID, newSubject);
            subjectRepository.Verify(repo => repo.Update(oldSubject.SubjectID, newSubject), Times.Once);
        }

        [Test]
        public void GetOneSubjectTest()
        {
            SubjectLogic subjectLogic = new SubjectLogic();

            List<Subject> subjects = new List<Subject>()
            {
                new Subject()
                {
                  SubjectID = "bvadubw89bcyií",
                  SubjectName = "Programming",
                  IsPrivate = false,
                },
                new Subject()
                {
                  SubjectID = "oihngw9u947bwe",
                  SubjectName = "Programming II.",
                  IsPrivate = false,
                },
                new Subject()
                {
                  SubjectID = "8743hsvb9whssgb",
                  SubjectName = "Programming III.",
                  IsPrivate = false,
                },
            };

            subjectRepository.Setup(subject => subject.GetOne(subjects[1].SubjectID)).Returns(subjects[1]);

            subjectLogic.GetOneSubject(subjects[1].SubjectID);
            subjectRepository.Verify(repo => repo.GetOne("oihngw9u947bwe"), Times.Once);
        }

        [Test]
        public void GetAllCommentTest()
        {
            SubjectLogic subjectLogic = new SubjectLogic();

            List<Subject> subjects = new List<Subject>()
            {
                new Subject()
                {
                  SubjectID = "bvadubw89bcyií",
                  SubjectName = "Programming",
                  IsPrivate = false,
                },
                new Subject()
                {
                  SubjectID = "oihngw9u947bwe",
                  SubjectName = "Programming II.",
                  IsPrivate = false,
                },
                new Subject()
                {
                  SubjectID = "8743hsvb9whssgb",
                  SubjectName = "Programming III.",
                  IsPrivate = false,
                },
            };

            subjectRepository.Setup(subject => subject.GetAll()).Returns(subjects.AsQueryable());

            subjectLogic.GetAllSubject();
            subjectRepository.Verify(repo => repo.GetAll(), Times.Once);
        }
    }
}
