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
        private IMapper mapper;

        public BaseController()
        {

        }

        protected IMapper Mapper
        {
            get
            {
                if(mapper != null)
                {
                    return this.mapper;
                }
                else
                {
                    this.mapper = AutoMapperConfig.Configuration.CreateMapper();
                    return this.mapper;
                }
            }
        }
    }
}