namespace MilitarySystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;
    using System.Linq;

    using MilitarySystem.Models;
    using MilitarySystem.Services.Contracts;
    using MilitarySystem.Web.Areas.Administration.Models.InputModels;
    using MilitarySystem.Web.Controllers;
    using Models;
    using Infrastructure.Mapping;

    public class VehicleAdministrationController : GridAdministrationController<Vehicle, VehicleInputModel>
    {
        private IVehiclesService vehicles;

        private IManufacturersService manufacturers;

        public VehicleAdministrationController(IVehiclesService vehicles, IManufacturersService manufacturers, IDataService<Vehicle> test) :base(test)
        {
            this.vehicles = vehicles;
            this.manufacturers = manufacturers;
        }
        // GET: Administration/VehicleAdministration
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