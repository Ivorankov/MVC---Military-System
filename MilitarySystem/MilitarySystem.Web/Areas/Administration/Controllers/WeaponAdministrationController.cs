namespace MilitarySystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using System.Collections.Generic;

    using System.Linq;
    using MilitarySystem.Services.Contracts;
    using MilitarySystem.Models;
    using Models.InputModels;
    using Web.Controllers;
    using Models;

    public class WeaponAdministrationController : BaseController
    {
        private IManufacturersService manufacturers;

        private IWeaponsService weapons;

        public WeaponAdministrationController(IManufacturersService manufacturers, IWeaponsService weapons)
        {
            this.manufacturers = manufacturers;
            this.weapons = weapons;
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

            var newWeapon = new Weapon()
            {
                Price = model.SendData.Price,
                ManufacturerId = model.SendData.ManufacturerId,
                Model = model.SendData.Model
            };

            this.weapons.Add(newWeapon);
            return View();
        }


    }
}