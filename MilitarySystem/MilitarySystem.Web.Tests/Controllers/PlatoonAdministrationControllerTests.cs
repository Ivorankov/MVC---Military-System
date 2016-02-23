using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestStack.FluentMVCTesting;

using Moq;

using MilitarySystem.Services.Contracts;
using MilitarySystem.Web.Infrastructure.Mapping;
using MilitarySystem.Models;
using MilitarySystem.Web.Areas.Troops.Controllers;
using MilitarySystem.Web.Areas.Administration.Controllers;
using MilitarySystem.Web.Areas.Administration.Models;
using MilitarySystem.Web.Areas.Administration.Models.ViewModels;

namespace MilitarySystem.Web.Tests.Controllers
{
    [TestClass]
    public class PlatoonAdministrationControllerTests
    {
        [TestMethod]
        public void IndexShouldRenderCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(UserController).Assembly);
            List<Platoon> Platoons = new List<Platoon>() { new Platoon() { Name = "Test", Id = 1, PlatoonCommander = new User() { FirstName = "Asd", LastName = "Asd", Id = "asd" } } };
            var usersServiceMock = new Mock<IUsersService>();
            usersServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new User { FirstName = "Test", SquadId = 1 });

            var squadsServiceMock = new Mock<ISquadsService>();
            squadsServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Squad { Name = "Test" });

            var platoonsServiceMock = new Mock<IPlatoonsService>();
            platoonsServiceMock.Setup(x => x.GetAll())
                .Returns(new List<Platoon>() { new Platoon() { Name = "Test", Id = 1, PlatoonCommander = new User() { FirstName = "Asd", LastName = "Asd", Id="asd"} } }.AsQueryable());

            var controller = new PlatoonAdministrationController(platoonsServiceMock.Object, squadsServiceMock.Object, usersServiceMock.Object);
            controller.WithCallTo(x => x.Index())
                .ShouldRenderView("Index")
                .WithModel<PlatoonIndexModel>(
                    viewModel =>
                    {
                        Assert.AreEqual(Platoons.First().Id, viewModel.Platoons.First().Id);
                    }).AndNoModelErrors();
        }

        [TestMethod]
        public void IndexShouldRenderInCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(UserController).Assembly);
            List<Platoon> Platoons = new List<Platoon>() { new Platoon() { Name = "Test", Id = 2, PlatoonCommander = new User() { FirstName = "Asd", LastName = "Asd", Id = "asd" } } };
            var usersServiceMock = new Mock<IUsersService>();
            usersServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new User { FirstName = "Test", SquadId = 1 });

            var squadsServiceMock = new Mock<ISquadsService>();
            squadsServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Squad { Name = "Test" });

            var platoonsServiceMock = new Mock<IPlatoonsService>();
            platoonsServiceMock.Setup(x => x.GetAll())
                .Returns(new List<Platoon>() { new Platoon() { Name = "Test", Id = 1, PlatoonCommander = new User() { FirstName = "Asd", LastName = "Asd", Id = "asd" } } }.AsQueryable());

            var controller = new PlatoonAdministrationController(platoonsServiceMock.Object, squadsServiceMock.Object, usersServiceMock.Object);
            controller.WithCallTo(x => x.Index())
                .ShouldRenderView("Index")
                .WithModel<PlatoonIndexModel>(
                    viewModel =>
                    {
                        Assert.AreNotEqual(Platoons.First().Id, viewModel.Platoons.First().Id);
                    }).AndNoModelErrors();
        }

        [TestMethod]
        public void PlatoonDetailsShouldRenderCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(UserController).Assembly);
            const string Name = "Name";
            var usersServiceMock = new Mock<IUsersService>();
            usersServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new User { FirstName = "Test", SquadId = 1 });

            var squadsServiceMock = new Mock<ISquadsService>();
            squadsServiceMock.Setup(x => x.GetAll())
                .Returns(new List<Squad>() { new Squad { Name = "Test" } }.AsQueryable());

            var platoonsServiceMock = new Mock<IPlatoonsService>();
            platoonsServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Platoon() { Name = "Name", Id = 1 });

            var controller = new PlatoonAdministrationController(platoonsServiceMock.Object, squadsServiceMock.Object, usersServiceMock.Object);
            controller.WithCallTo(x => x.PlatoonDetails(1))
                .ShouldRenderView("PlatoonDetails")
                .WithModel<PlatoonViewModel>(
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
            const string Name = "No NO No NO :P";
            var usersServiceMock = new Mock<IUsersService>();
            usersServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new User { FirstName = "Test", SquadId = 1 });

            var squadsServiceMock = new Mock<ISquadsService>();
            squadsServiceMock.Setup(x => x.GetAll())
                .Returns(new List<Squad>() { new Squad { Name = "Name" } }.AsQueryable());

            var platoonsServiceMock = new Mock<IPlatoonsService>();
            platoonsServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Platoon() { Name = "Test", Id = 1 });

            var controller = new PlatoonAdministrationController(platoonsServiceMock.Object, squadsServiceMock.Object, usersServiceMock.Object);
            controller.WithCallTo(x => x.PlatoonDetails(1))
                .ShouldRenderView("PlatoonDetails")
                .WithModel<PlatoonViewModel>(
                    viewModel =>
                    {
                        Assert.AreNotEqual(Name, viewModel.Name);
                    }).AndNoModelErrors();
        }
    }
}
