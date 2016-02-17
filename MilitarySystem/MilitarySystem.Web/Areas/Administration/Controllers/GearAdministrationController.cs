namespace MilitarySystem.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using MilitarySystem.Models;
    using MilitarySystem.Services.Contracts;
    using MilitarySystem.Web.Areas.Administration.Models;
    using MilitarySystem.Web.Areas.Administration.Models.InputModels;
    using MilitarySystem.Web.Controllers;

    public class GearAdministrationController : BaseController
    {
        // GET: Administration/GearAdministration
        private IManufacturersService manufacturers;

        private IGearService gear;

        public GearAdministrationController(IManufacturersService manufacturers,IGearService gear) 
        {
            this.gear = gear;
            this.manufacturers = manufacturers;
        }

        // GET: Administration/WeaponAdministration
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddGear()
        {
            var manufacturers = this.manufacturers
                .GetAll()
                .ToList();

            var weaponIndexModel = new IndexGearModel()
            {
                Manufacturers = manufacturers,
                SendData = new GearInputModel()
            };

            return View(weaponIndexModel);
        }

        [HttpPost]
        public ActionResult AddGear(IndexGearModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.gear.Add(this.Mapper.Map<Gear>(model.SendData));
            return View();
        }
    }
}