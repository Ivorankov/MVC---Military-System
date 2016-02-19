using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MilitarySystem.Web.Areas.Administration.Models.BaseModels
{
    public class EquipmentInputModel
    {
        [HiddenInput(DisplayValue = false)]
        public int? Id { get; set; }

        [Required]
        [UIHint("Model")]
        public string Model { get; set; }

        [Required]
        [UIHint("Price")]
        public decimal Price { get; set; }

        [Required]
        [UIHint("ManufacturerId")]
        public int ManufacturerId { get; set; }
    }
}