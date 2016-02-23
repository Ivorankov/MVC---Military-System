using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestStack.FluentMVCTesting;

using Moq;

using MilitarySystem.Services.Contracts;
using MilitarySystem.Web.Infrastructure.Mapping;
using MilitarySystem.Models;
using MilitarySystem.Web.Areas.Troops.Controllers;
using MilitarySystem.Web.Areas.Troops.ViewModels;

namespace MilitarySystem.Web.Tests
{
    [TestClass]
    public class SquadControllerTest
    {
        [TestMethod]
        public void SquadDetailsShouldRenderCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(UserController).Assembly);
            const string Name = "Test";
            var usersServiceMock = new Mock<IUsersService>();
            usersServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new User { FirstName = "Test", SquadId= 1 });

            var squadsServiceMock = new Mock<ISquadsService>();
            squadsServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Squad { Name="Test"});

            var controller = new SquadController(squadsServiceMock.Object, usersServiceMock.Object);
            controller.WithCallTo(x => x.SquadDetails("asd"))
                .ShouldRenderPartialView("_SquadDetails")
                .WithModel<SquadDetailsViewModel>(
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
            const string Name = "IsNan";
            var usersServiceMock = new Mock<IUsersService>();
            usersServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new User { FirstName = "Test", SquadId = 1 });

            var squadsServiceMock = new Mock<ISquadsService>();
            squadsServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Squad { Name = "Test" });

            var controller = new SquadController(squadsServiceMock.Object, usersServiceMock.Object);
            controller.WithCallTo(x => x.SquadDetails("asd"))
                .ShouldRenderPartialView("_SquadDetails")
                .WithModel<SquadDetailsViewModel>(
                    viewModel =>
                    {
                        Assert.AreNotEqual(Name, viewModel.Name);
                    }).AndNoModelErrors();
        }
    }
}
