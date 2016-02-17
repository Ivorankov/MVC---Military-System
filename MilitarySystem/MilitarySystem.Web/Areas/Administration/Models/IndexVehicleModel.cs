namespace MilitarySystem.Web.Areas.Administration.Models
{
    using MilitarySystem.Web.Areas.Administration.Models.InputModels;
    using BaseModels;

    public class IndexVehicleModel : EquipmentViewModel
    {
        public VehicleInputModel SendData { get; set; }
    }
}