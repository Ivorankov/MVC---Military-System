﻿namespace MilitarySystem.Web.Areas.Administration.Models.BaseModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class EquipmentInputModel
    {
        [Required]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int ManufacturerId { get; set; }
    }
}