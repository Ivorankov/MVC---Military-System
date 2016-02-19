namespace MilitarySystem.Web.Areas.Administration.Models.InputModels
{
    using MilitarySystem.Models;
    using BaseModels;
    using MilitarySystem.Web.Infrastructure.Mapping;

    public class WeaponInputModel : EquipmentInputModel, IMapFrom<Weapon>, IMapTo<Weapon>
    {

    }
}