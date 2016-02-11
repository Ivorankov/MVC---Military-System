namespace MilitarySystem.Web.Controllers
{
    using System.Web.Mvc;

    using AutoMapper;

    using MilitarySystem.Models;
    using Services.Contracts;
    using Infrastructure;
    using Infrastructure.Mapping;

    public class BaseController : Controller
    {
        private IUsersService users;

        public BaseController(IUsersService users)
        {
            this.users = users;

        }
        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }


        protected IUsersService Users { get { return this.users; } private set { this.users = value; } }

        protected User CurrentUser { get; set; }
    }
}