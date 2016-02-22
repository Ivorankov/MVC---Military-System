namespace MilitarySystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Services.Contracts;
    using MilitarySystem.Models;
    using Models.InputModels;

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