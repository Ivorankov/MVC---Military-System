namespace MilitarySystem.Web.Areas.Administration.Models
{
    using MilitarySystem.Web.Areas.Administration.Models.InputModels;
    using BaseModels;

    public class IndexVehicleModel : EquipmentModel
    {
        public VehicleInputModel SendData { get; set; }
    }
}