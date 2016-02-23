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
    public class UserControllerTests
    {
        [TestMethod]
        public void UserDetailsShouldRenderCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(UserController).Assembly);
            const decimal Wage = 0;
            var usersServiceMock = new Mock<IUsersService>();
            usersServiceMock.Setup(x => x.GetById(It.IsAny<string>())) //UserDetails()
                .Returns(new User { FirstName="Test", LastName="Me", Wage=0 });

            var controller = new UserController(usersServiceMock.Object);
            controller.WithCallTo(x => x.UserDetails("asd"))
                .ShouldRenderPartialView("_UserDetails")
                .WithModel<UserDetailsViewModel>(
                    viewModel =>
                    {
                        Assert.AreEqual(Wage, viewModel.Wage);
                    }).AndNoModelErrors();
        }

        [TestMethod]
        public void UserDetailsShouldRenderInCorrectly()
        {
            var autoMapperConfig = new AutoMapperConfig();
            autoMapperConfig.Execute(typeof(UserController).Assembly);
            const decimal Wage = 1;
            var usersServiceMock = new Mock<IUsersService>();
            usersServiceMock.Setup(x => x.GetById(It.IsAny<string>())) //UserDetails()
                .Returns(new User { FirstName = "Test", LastName = "Me", Wage = 0 });

            var controller = new UserController(usersServiceMock.Object);
            controller.WithCallTo(x => x.UserDetails("asd"))
                .ShouldRenderPartialView("_UserDetails")
                .WithModel<UserDetailsViewModel>(
                    viewModel =>
                    {
                        Assert.AreNotEqual(Wage, viewModel.Wage);
                    }).AndNoModelErrors();
        }
    }
}
