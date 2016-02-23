namespace MilitarySystem.Web.Areas.Administration.Controllers.Base
{
    using System.Web.Mvc;

    using MilitarySystem.Common;
    using MilitarySystem.Web.Controllers;

    [Authorize(Roles = ModelsConstraints.AdminRoleName)]
    public class AuthController : BaseController
    {

    }
}