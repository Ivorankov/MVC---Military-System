namespace MilitarySystem.Web.Areas.Administration.Models.BaseModels
{
    using System.Collections.Generic;

    using InputModels;

    public abstract class EquipmentViewModel
    {
        public List<ManufacturerInputModel> Manufacturers { get; set; }
    }
}