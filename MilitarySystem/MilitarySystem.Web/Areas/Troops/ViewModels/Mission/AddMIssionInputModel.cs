﻿using MilitarySystem.Common;
using MilitarySystem.Models;
using MilitarySystem.Web.Infrastructure.Mapping;
using System.ComponentModel.DataAnnotations;

namespace MilitarySystem.Web.Areas.Troops.ViewModels
{
    public class AddMIssionInputModel : IMapTo<Mission>
    {
        [Required]
        public int SquadId { get; set; }

        [Required]
        [MaxLength(ModelsConstraints.MessageMaxLength)]
        public string Info { get; set; }

        [Required]
        [Range(-90, 90)]
        public decimal Lat { get; set; }

        [Required]
        [Range(-180, 180)]
        public decimal Lgn { get; set; }
    }
}