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

            SubjectLogic subjectLogic = new SubjectLogic(subjectRepository.Object);

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

            SubjectLogic subjectLogic = new SubjectLogic(subjectRepository.Object);

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

            SubjectLogic subjectLogic = new SubjectLogic(subjectRepository.Object);

            subjectLogic.EditSubject(oldSubject.SubjectID, newSubject);
            subjectRepository.Verify(repo => repo.Update(oldSubject.SubjectID, newSubject), Times.Once);
        }

        [Test]
        public void GetOneSubjectTest()
        {
            SubjectLogic subjectLogic = new SubjectLogic(subjectRepository.Object);

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
        public void GetAllSubjectTest()
        {
            SubjectLogic subjectLogic = new SubjectLogic(subjectRepository.Object);

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

        [Test]
        public void GetAllSubjectsOfYear()
        {
            SubjectLogic subjectLogic = new SubjectLogic(subjectRepository.Object);

            Subject s1 = new Subject()
            {
                YearID = "2022",
                SubjectID = "bvadubw89bcyií",
                SubjectName = "Programming",
                IsPrivate = false,
            };

            Subject s2 = new Subject()
            {
                YearID = "2022",
                SubjectID = "oihngw9u947bwe",
                SubjectName = "Programming II.",
                IsPrivate = false,
            };

            Subject s3 = new Subject()
            {
                YearID = "2020",
                SubjectID = "8743hsvb9whssgb",
                SubjectName = "Programming III.",
                IsPrivate = false,
            };

            List<Subject> allSubjects = new List<Subject>();
            allSubjects.Add(s1);
            allSubjects.Add(s2);
            allSubjects.Add(s3);

            List<Subject> expectedOutput = new List<Subject>();
            expectedOutput.Add(s1);
            expectedOutput.Add(s2);

            subjectRepository.Setup(subject => subject.GetAll()).Returns(allSubjects.AsQueryable());

            List<Subject> queryOutput = subjectLogic.GetAllSubjectsOfYear("2022").ToList();
            Assert.AreEqual(expectedOutput, queryOutput);
        }
    }
}
