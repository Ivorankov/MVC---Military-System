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
    public class ChatControllerTests
    {
        [TestMethod]
        public void ChatDetailsShouldRenderCorrectly()
        {
            var controller = new ChatController();
            controller.WithCallTo(x => x.Chat())
                .ShouldRenderPartialView("_Chat");
        }
    }
}
