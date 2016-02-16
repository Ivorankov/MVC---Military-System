namespace MilitarySystem.Web.Areas.Administration.Models
{
    using System.Collections.Generic;

    using MilitarySystem.Models;
    using MilitarySystem.Web.Areas.Administration.Models.InputModels;

    public class IndexWeaponModel
    {
        public WeaponInputModel SendData { get; set; }

        public List<Manufacturer> Manufacturers { get; set; }
    }
}