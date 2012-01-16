using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using MyRadio.Controllers;
using MyRadio.Domain.Repositories;
using MyRadio.Models;


namespace MyRadio.Tests
{
    [TestClass]
    public class RadioControllerTests
    {
        private Mock<IMediaRepository> mockRepository;
        private RadioController target;

        public RadioControllerTests()
        {
            mockRepository = new Mock<IMediaRepository>();

            mockRepository.Setup(r => r.Medias).Returns(
                new[]
                {
                    new Media{ MediaId = 1, Url = "http://www.youtube.com/watch?v=d78K4rCEfAo"},
                    new Media{ MediaId = 2, Url = "http://www.youtube.com/watch?v=nvZqLchakTo"},
                    new Media{ MediaId = 3, Url = "http://www.youtube.com/watch?v=Wxuo_fY7fU0"},
                    new Media{ MediaId = 4, Url = "http://vimeo.com/34653846"},
                    new Media{ MediaId = 5, Url = "http://www.ted.com/talks/michelle_borkin_can_astronomers_help_doctors.html"},                    
                }.AsQueryable()
            );

            target = new RadioController(mockRepository.Object);
        }

        [TestMethod]
        public void Index_Should_Contain_All_Medias()
        {
            var result = ((IEnumerable<Media>)target.Index().Model).ToList();
            Assert.AreEqual(5, result.Count);
        }


        [TestMethod]
        public void Index_Returns_The_First_Media_In_Order()
        {
            var result = (IEnumerable<Media>)target.Index().Model;
            Assert.AreEqual(1, result.First().MediaId);
            Assert.AreEqual("http://www.youtube.com/watch?v=d78K4rCEfAo", result.First().Url);
        }

        [TestMethod]
        public void Index_Returns_The_Last_Media_In_Order()
        {
            var result = (IEnumerable<Media>)target.Index().Model;
            Assert.AreEqual(5, result.Last().MediaId);
            Assert.AreEqual("http://www.ted.com/talks/michelle_borkin_can_astronomers_help_doctors.html", result.Last().Url);
        }

        [TestMethod]
        public void On_Adding_Media_Should_Call_Save_Method()
        {
            target.AddMedia(new Media { MediaId = 10, Url = "Url" });

            mockRepository.Verify(m => m.SaveMedia(It.IsAny<Media>()), Times.Once());
        }

        [TestMethod]
        public void Cannot_Save_Invalid_Media()
        {
            target.ModelState.AddModelError("Error", "Url is Required.");
            target.AddMedia(new Media());

            mockRepository.Verify(m => m.SaveMedia(It.IsAny<Media>()), Times.Never());
        }

        [TestMethod]
        public void Invalid_Media_Should_Return_Edit_View()
        {

            var media = new Media();
            target.ModelState.AddModelError("Error", "Url is Required.");
            var result = target.AddMedia(media);            

            Assert.IsNotInstanceOfType(result, typeof(RedirectToRouteResult));
        }

        [TestMethod]
        public void Can_Save_Valid_Media()
        {
            target.AddMedia(new Media { MediaId = 10, Url = "Url" });

            mockRepository.Verify(m => m.SaveMedia(It.IsAny<Media>()), Times.Once());
        }

        [TestMethod]
        public void Valid_Media_Should_Return_Index_View()
        {
            var result = target.AddMedia(new Media { MediaId = 10, Url = "Url" });
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));
        }

    }
}
