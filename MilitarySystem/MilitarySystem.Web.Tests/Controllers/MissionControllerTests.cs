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
    public class MissionControllerTests
    {
        [TestMethod]
        public void AddMissionShouldRenderCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(UserController).Assembly);
            const int Name = 1;
            var usersServiceMock = new Mock<IUsersService>();
            usersServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new User { FirstName = "Test", SquadId = 1 });

            var squadsServiceMock = new Mock<ISquadsService>();
            squadsServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Squad { Name = "Test" });

            var missionsServiceMock = new Mock<IMissionsService>();
            squadsServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Squad { Name = "Test" });

            var controller = new MissionController(missionsServiceMock.Object, usersServiceMock.Object, squadsServiceMock.Object);
            controller.WithCallTo(x => x.AssignMission(1))
                .ShouldRenderPartialView("_AddMissionBox")
                .WithModel<AddMIssionInputModel>(
                    viewModel =>
                    {
                        Assert.AreEqual(Name, viewModel.SquadId);
                    }).AndNoModelErrors();
        }

        [TestMethod]
        public void AddMissionShouldRenderInCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(UserController).Assembly);
            const int Name = 0;
            var usersServiceMock = new Mock<IUsersService>();
            usersServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new User { FirstName = "Test", SquadId = 1 });

            var squadsServiceMock = new Mock<ISquadsService>();
            squadsServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Squad { Name = "Test", ActiveMissionId = 1 });

            var missionsServiceMock = new Mock<IMissionsService>();
            squadsServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Squad { Name = "Test" });

            var controller = new MissionController(missionsServiceMock.Object, usersServiceMock.Object, squadsServiceMock.Object);
            controller.WithCallTo(x => x.AssignMission(1))
                .ShouldRenderPartialView("_AddMissionBox")
                .WithModel<AddMIssionInputModel>(
                    viewModel =>
                    {
                        Assert.AreNotEqual(Name, viewModel.SquadId);
                    }).AndNoModelErrors();
        }

        [TestMethod]
        public void MissionShouldRenderCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(UserController).Assembly);
            const string Info = null;
            var usersServiceMock = new Mock<IUsersService>();
            usersServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new User { FirstName = "Test", SquadId = 1 });

            var squadsServiceMock = new Mock<ISquadsService>();
            squadsServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Squad { Name = "Test", ActiveMissionId = 1 });

            var missionsServiceMock = new Mock<IMissionsService>();
            missionsServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Mission { SquadId = 0 });

            var controller = new MissionController(missionsServiceMock.Object, usersServiceMock.Object, squadsServiceMock.Object);
            controller.WithCallTo(x => x.Mission("asd"))
                .ShouldRenderPartialView("_MissionDetails")
                .WithModel<MissionDetailsViewModel>(
                    viewModel =>
                    {
                        Assert.AreEqual(Info, viewModel.Info);
                    }).AndNoModelErrors();
        }

        [TestMethod]
        public void MissionShouldRenderInCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(UserController).Assembly);
            const string Info = "A";
            var usersServiceMock = new Mock<IUsersService>();
            usersServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new User { FirstName = "Test", SquadId = 1 });

            var squadsServiceMock = new Mock<ISquadsService>();
            squadsServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Squad { Name = "Test", ActiveMissionId = 1 });

            var missionsServiceMock = new Mock<IMissionsService>();
            missionsServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Mission { SquadId = 0 });

            var controller = new MissionController(missionsServiceMock.Object, usersServiceMock.Object, squadsServiceMock.Object);
            controller.WithCallTo(x => x.Mission("asd"))
                .ShouldRenderPartialView("_MissionDetails")
                .WithModel<MissionDetailsViewModel>(
                    viewModel =>
                    {
                        Assert.AreNotEqual(Info, viewModel.Info);
                    }).AndNoModelErrors();
        }

        [TestMethod]
        public void MissionShouldRenderWithNullActiveMissionIdCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(UserController).Assembly);
            var usersServiceMock = new Mock<IUsersService>();
            usersServiceMock.Setup(x => x.GetById(It.IsAny<string>()))
                .Returns(new User { FirstName = "Test", SquadId = 1 });

            var squadsServiceMock = new Mock<ISquadsService>();
            squadsServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Squad { Name = "Test" });

            var missionsServiceMock = new Mock<IMissionsService>();
            missionsServiceMock.Setup(x => x.GetById(It.IsAny<int>()))
                .Returns(new Mission { SquadId = 0 });

            var controller = new MissionController(missionsServiceMock.Object, usersServiceMock.Object, squadsServiceMock.Object);
            controller.WithCallTo(x => x.Mission("asd"))
                .ShouldRenderPartialView("_MissionDetails");
        }
    }
}
