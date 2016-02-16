namespace MilitarySystem.Web.Areas.Administration.Models.InputModels
{
    using MilitarySystem.Models;
    using MilitarySystem.Web.Infrastructure.Mapping;

    public class ManufacturerInputModel : IMapTo<Manufacturer>
    {
        public string Name { get; set; }
    }
}