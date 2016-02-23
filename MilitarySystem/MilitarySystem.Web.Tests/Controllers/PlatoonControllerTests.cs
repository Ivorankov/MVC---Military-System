using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestStack.FluentMVCTesting;

using Moq;

using MilitarySystem.Services.Contracts;
using MilitarySystem.Web.Infrastructure.Mapping;
using MilitarySystem.Models;
using MilitarySystem.Web.Areas.Troops.Controllers;
using MilitarySystem.Web.Areas.Troops.ViewModels;

namespace MilitarySystem.Web.Tests.Controllers
{
    [TestClass]
    public class PlatoonControllerTests
    {
        [TestMethod]
        public void PlatoonDetailsShouldRenderCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(UserController).Assembly);
            const string Name = "Test";
            var usersServiceMock = new Mock<IUsersService>();
            usersServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new User { FirstName = "Test", Id = "asd" });

            var platoonsServiceMock = new Mock<IPlatoonsService>();
            platoonsServiceMock.Setup(x => x.GetAll())
                .Returns(new List<Platoon>() { new Platoon() { Name = "Test", PlatoonCommanderId = "asd" } }.AsQueryable());

            var squadsServiceMock = new Mock<ISquadsService>();
            squadsServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Squad { Name = "Test" });

            var controller = new PlatoonController(platoonsServiceMock.Object, squadsServiceMock.Object, usersServiceMock.Object);
            controller.WithCallTo(x => x.PlatoonDetails("asd"))
                .ShouldRenderPartialView("_PlatoonDetails")
                .WithModel<PlatoonDetailsViewModel>(
                    viewModel =>
                    {
                        Assert.AreEqual(Name, viewModel.Name);
                    }).AndNoModelErrors();
        }

        [TestMethod]
        public void PlatoonDetailsShouldRenderInCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(UserController).Assembly);
            const string Name = "NANANNA";
            var usersServiceMock = new Mock<IUsersService>();
            usersServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new User { FirstName = "Test", Id="asd" });

            var platoonsServiceMock = new Mock<IPlatoonsService>();
            platoonsServiceMock.Setup(x => x.GetAll())
                .Returns(new List<Platoon>() { new Platoon() { Name = "Test", PlatoonCommanderId = "asd" } }.AsQueryable());

            var squadsServiceMock = new Mock<ISquadsService>();
            squadsServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Squad { Name = "Test" });

            var controller = new PlatoonController(platoonsServiceMock.Object, squadsServiceMock.Object, usersServiceMock.Object);
            controller.WithCallTo(x => x.PlatoonDetails("asd"))
                .ShouldRenderPartialView("_PlatoonDetails")
                .WithModel<PlatoonDetailsViewModel>(
                    viewModel =>
                    {
                        Assert.AreNotEqual(Name, viewModel.Name);
                    }).AndNoModelErrors();
        }
    }
}
