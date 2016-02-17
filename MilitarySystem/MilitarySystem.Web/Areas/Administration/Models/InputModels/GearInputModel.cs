namespace MilitarySystem.Web.Areas.Administration.Models.InputModels
{
    using MilitarySystem.Models;
    using MilitarySystem.Web.Infrastructure.Mapping;
    using BaseModels;

    public class GearInputModel : EquipmentInputModel, IMapTo<Gear>
    {

    }
}