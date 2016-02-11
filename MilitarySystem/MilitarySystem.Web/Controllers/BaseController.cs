namespace MilitarySystem.Web.Controllers
{
    using MilitarySystem.Models;
    using Services.Contracts;

    using System.Web.Mvc;

    public class BaseController : Controller
    {
        private IUsersService users;

        public BaseController(IUsersService users)
        {
            this.users = users;
            
        }

        protected IUsersService Users { get { return this.users; } private set { this.users = value; } }

        protected User CurrentUser { get; set; }
    }
}