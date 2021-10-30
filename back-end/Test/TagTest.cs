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
    public class TagTest
    {
        public Mock<ITagRepository> tagRepository = new Mock<ITagRepository>();

        [Test]
        public void CreateTagTest()
        {
            tagRepository.Setup(subject => subject.Add(It.IsAny<Tag>()));

            TagLogic tagLogic = new TagLogic();

            Tag tag = new Tag()
            {
                TagID = "bvadubw89bcyií",
                TagName = "Learnig",
            };

            tagLogic.CreateTag(tag);
            tagRepository.Verify(repo => repo.Add(tag), Times.Once);
        }

        [Test]
        public void DeleteTagTest()
        {
            tagRepository.Setup(tag => tag.Delete(It.IsAny<string>()));

            TagLogic tagLogic = new TagLogic();

            Tag tag = new Tag()
            {
                TagID = "bvadubw89bcyií",
                TagName = "Learnig",
            };

            tagLogic.DeleteTag(tag.TagID);
            tagRepository.Verify(repo => repo.Delete(tag.TagID), Times.Once);
        }

        [Test]
        public void EditTagTest()
        {
            Tag oldTag = new Tag()
            {
                TagID = "bvadubw89bcyií",
                TagName = "Learnig",
            };

            Tag newTag = new Tag()
            {
                TagName = "School",
            };

            tagRepository.Setup(tag => tag.Update(oldTag.TagID, newTag));

            TagLogic tagLogic = new TagLogic();

            tagLogic.EditTag(oldTag.TagID, newTag);
            tagRepository.Verify(repo => repo.Update(oldTag.TagID, newTag), Times.Once);
        }

        [Test]
        public void GetOneTagTest()
        {
            TagLogic tagLogic = new TagLogic();

            List<Tag> tags = new List<Tag>()
            {
                new Tag()
                {
                  TagID = "bvadubw89bcyií",
                  TagName = "Learnig",
                },
                new Tag()
                {
                  TagID = "oihngw9u947bwe",
                  TagName = "School",
                },
                new Tag()
                {
                  TagID = "8743hsvb9whssgb",
                  TagName = "Test",
                },
            };

            tagRepository.Setup(tag => tag.GetOne(tags[1].TagID)).Returns(tags[1]);

            tagLogic.GetOneTag(tags[1].TagID);
            tagRepository.Verify(repo => repo.GetOne("oihngw9u947bwe"), Times.Once);
        }

        [Test]
        public void GetAllTagTest()
        {
            TagLogic tagLogic = new TagLogic();

            List<Tag> tags = new List<Tag>()
            {
                new Tag()
                {
                  TagID = "bvadubw89bcyií",
                  TagName = "Learnig",
                },
                new Tag()
                {
                  TagID = "oihngw9u947bwe",
                  TagName = "School",
                },
                new Tag()
                {
                  TagID = "8743hsvb9whssgb",
                  TagName = "Test",
                },
            };

            tagRepository.Setup(tag => tag.GetAll()).Returns(tags.AsQueryable());

            tagLogic.GetAllTag();
            tagRepository.Verify(repo => repo.GetAll(), Times.Once);
        }
    }
}
