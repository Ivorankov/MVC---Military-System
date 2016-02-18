namespace MilitarySystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using System.Linq;

    using MilitarySystem.Models;
    using MilitarySystem.Services.Contracts;
    using MilitarySystem.Web.Areas.Administration.Models.InputModels;
    using MilitarySystem.Web.Controllers;
    using Models;

    public class VehicleAdministrationController : BaseController
    {
        private IVehiclesService vehicles;

        private IManufacturersService manufacturers;

        public VehicleAdministrationController(IVehiclesService vehicles, IManufacturersService manufacturers)
        {
            this.vehicles = vehicles;
            this.manufacturers = manufacturers;
        }
        // GET: Administration/VehicleAdministration
        public ActionResult Index()
        {
            return View();
        }

        //[HttpGet]
        //public ActionResult AddVehicle()
        //{
        //    var manufacturers = this.manufacturers
        //                            .GetAll()
        //                            .ToList();

        //    var weaponIndexModel = new IndexVehicleModel()
        //    {
        //        Manufacturers = manufacturers,
        //        SendData = new VehicleInputModel()
        //    };

        //    return View(weaponIndexModel);
        //}

        [HttpPost]
        public ActionResult AddVehicle(IndexVehicleModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.vehicles.Add(this.Mapper.Map<Vehicle>(model.SendData));

            return View();
        }
    }
}