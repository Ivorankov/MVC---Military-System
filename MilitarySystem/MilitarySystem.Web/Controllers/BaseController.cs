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
        public BaseController()
        {

        }
        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}