namespace MilitarySystem.Web.Areas.Administration.Models
{
    using MilitarySystem.Web.Areas.Administration.Models.InputModels;
    using BaseModels;

    public class IndexWeaponModel : EquipmentViewModel
    {
        public WeaponInputModel SendData { get; set; }
    }
}