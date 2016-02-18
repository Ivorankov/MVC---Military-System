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
            ) :base(weapon)
        {
            this.weapons = weapons;
            this.manufacturers = manufacturers;
        }

        // GET: Administration/WeaponAdministration
        public ActionResult Index()
        {
            return View();
        }

        public override void Update([DataSourceRequest] DataSourceRequest request, WeaponInputModel model)
        {
            HttpRequestBase requestData = HttpContext.Request;
            var test = new WeaponInputModel()
            {
                Id = int.Parse(requestData.Form.Get("Id")),
                ManufacturerId = int.Parse(requestData.Form.Get("ManufacturerId")),
                Model = requestData.Form.Get("Model")               
            };
            base.Update(request, test);
        }

        [HttpGet]
        public ActionResult AddWeapon()
        {
            var manufacturers = this.manufacturers
                .GetAll()
                .To<ManufacturerInputModel>()
                .ToList();

            var weaponIndexModel = new IndexWeaponModel()
            {
                Manufacturers = manufacturers,
                SendData = new WeaponInputModel()
            };

            return View(weaponIndexModel);
        }

        [HttpPost]
        public ActionResult AddWeapon(IndexWeaponModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.weapons.Add(this.Mapper.Map<Weapon>(model.SendData));
            return View();
        }

    }
}