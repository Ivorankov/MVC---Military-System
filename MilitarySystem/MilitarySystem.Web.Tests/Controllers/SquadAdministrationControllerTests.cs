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
    public class SquadAdministrationControllerTests
    {
        [TestMethod]
        public void SquadDetailsShouldRenderCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(UserController).Assembly);
            const string Name = "Test";
            var usersServiceMock = new Mock<IUsersService>();
            usersServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new User { FirstName = "Test", SquadId = 1 });

            var squadsServiceMock = new Mock<ISquadsService>();
            squadsServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Squad { Name = "Test" });

            var vehiclesServiceMock = new Mock<IVehiclesService>();
            vehiclesServiceMock.Setup(x => x.GetAll())
                .Returns(new List<Vehicle>() { new Vehicle() { Model = "Test", Id = 1 } }.AsQueryable());

            var controller = new SquadAdministrationController(usersServiceMock.Object, squadsServiceMock.Object, vehiclesServiceMock.Object);
            controller.WithCallTo(x => x.SquadDetails(1))
                .ShouldRenderView("SquadDetails")
                .WithModel<SquadViewModel>(
                    viewModel =>
                    {
                        Assert.AreEqual(Name, viewModel.Name);
                    }).AndNoModelErrors();
        }

        [TestMethod]
        public void SquadDetailsShouldRenderInCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(UserController).Assembly);
            const string Name = "Bat boy is not BATMAN!";
            var usersServiceMock = new Mock<IUsersService>();
            usersServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new User { FirstName = "Test", SquadId = 1 });

            var squadsServiceMock = new Mock<ISquadsService>();
            squadsServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Squad { Name = "Test" });

            var vehiclesServiceMock = new Mock<IVehiclesService>();
            vehiclesServiceMock.Setup(x => x.GetAll())
                .Returns(new List<Vehicle>() { new Vehicle() { Model = "Test", Id = 1 } }.AsQueryable());

            var controller = new SquadAdministrationController(usersServiceMock.Object, squadsServiceMock.Object, vehiclesServiceMock.Object);
            controller.WithCallTo(x => x.SquadDetails(1))
                .ShouldRenderView("SquadDetails")
                .WithModel<SquadViewModel>(
                    viewModel =>
                    {
                        Assert.AreNotEqual(Name, viewModel.Name);
                    }).AndNoModelErrors();
        }
    }
}
