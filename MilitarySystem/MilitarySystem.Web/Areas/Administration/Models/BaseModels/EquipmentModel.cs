namespace MilitarySystem.Web.Areas.Administration.Models.BaseModels
{
    using System.Collections.Generic;

    using MilitarySystem.Models;

    public abstract class EquipmentModel
    {
        public List<Manufacturer> Manufacturers { get; set; }
    }
}