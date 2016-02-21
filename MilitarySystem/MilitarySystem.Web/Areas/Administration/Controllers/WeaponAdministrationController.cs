namespace MilitarySystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using System.Linq;

    using MilitarySystem.Services.Contracts;
    using MilitarySystem.Models;
    using Models.InputModels;
    using Web.Controllers;
    using Models;
    using Kendo.Mvc.UI;
    using System;
    using Kendo.Mvc.Extensions;
    using AutoMapper.Mappers;
    using AutoMapper.QueryableExtensions;
    using Infrastructure.Mapping;
    using System.Web;

    public class WeaponAdministrationController : GridAdministrationController<Weapon, WeaponInputModel>
    {
        private IManufacturersService manufacturers;

        private IWeaponsService weapons;

        public WeaponAdministrationController(
            IManufacturersService manufacturers,
            IWeaponsService weapons,
            IDataService<Weapon> weapon
            ) : base(weapon)
        {
            this.weapons = weapons;
            this.manufacturers = manufacturers;
        }

        // GET: Administration/WeaponAdministration
        public ActionResult Index()
        {
            var manufacturers = this.manufacturers
                                .GetAll()
                                .To<ManufacturerInputModel>()
                                .ToList();

            ViewBag.Manufacturers = manufacturers;

            return View();
        }
    }
}