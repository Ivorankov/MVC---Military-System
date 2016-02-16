namespace MilitarySystem.Web.Areas.Administration.Models.InputModels
{
    using System.Collections.Generic;

    using MilitarySystem.Models;
    using MilitarySystem.Web.Infrastructure.Mapping;

    public class WeaponInputModel
    {
        public string Model { get; set; }

        public decimal Price { get; set; }

        public int ManufacturerId { get; set; }

    }
}