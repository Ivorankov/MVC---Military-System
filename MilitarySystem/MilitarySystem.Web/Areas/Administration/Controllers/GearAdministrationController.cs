namespace MilitarySystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using MilitarySystem.Models;
    using MilitarySystem.Services.Contracts;
    using MilitarySystem.Web.Areas.Administration.Models.InputModels;

    public class GearAdministrationController : GridAdministrationController<Gear, GearInputModel>
    {
        // GET: Administration/GearAdministration
        private IManufacturersService manufacturers;

        private IGearService gear;

        public GearAdministrationController(
            IManufacturersService manufacturers,
            IGearService gear,
            IDataService<Gear> test)
            : base(test) 
        {
            this.gear = gear;
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