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

    public class WeaponAdministrationController : GridAdministrationController<Weapon, IndexWeaponModel>
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

        [HttpGet]
        public ActionResult AddWeapon()
        {
            var manufacturers = this.manufacturers
                .GetAll()
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