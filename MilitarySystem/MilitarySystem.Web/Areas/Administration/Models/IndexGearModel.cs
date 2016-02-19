namespace MilitarySystem.Web.Areas.Administration.Models
{
    using MilitarySystem.Web.Areas.Administration.Models.BaseModels;
    using InputModels;

    public class IndexGearModel : EquipmentViewModel
    {
        public GearInputModel SendData { get; set; }
    }
}