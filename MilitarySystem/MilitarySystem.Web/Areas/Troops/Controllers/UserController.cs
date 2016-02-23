namespace MilitarySystem.Web.Areas.Troops.Controllers
{
    using System.Web.Mvc;

    using MilitarySystem.Services.Contracts;
    using MilitarySystem.Web.Areas.Troops.ViewModels;

    public class UserController : TroopsController
    {
        private IUsersService users;

        public UserController(IUsersService users)
        {
            this.users = users;
        }

        [HttpGet]
        public ActionResult UserDetails(string userId)
        {
           // var userId = User.Identity.GetUserId();
            var user = this.users.GetById(userId);
            var userModel = this.Mapper.Map<UserDetailsViewModel>(user);

            return PartialView("_UserDetails", userModel);
        }
    }
}