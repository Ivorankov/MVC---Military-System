namespace MilitarySystem.Web.Areas.Administration.Controllers
{
    using System.Web.Mvc;

    using Services.Contracts;
    using Models.InputModels;
    using MilitarySystem.Models;
    using Web.Controllers;

    public class ManufacturerAdministrationController : BaseController
    {
        private IManufacturersService manufacturers;

        public ManufacturerAdministrationController(IManufacturersService manufacturers)
        {
            this.manufacturers = manufacturers;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddManufacturer(ManufacturerInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            this.manufacturers.Add(this.Mapper.Map<Manufacturer>(model));

            return Json(null);
        }
    }
}