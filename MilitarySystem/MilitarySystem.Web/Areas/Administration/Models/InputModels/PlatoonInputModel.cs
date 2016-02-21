using MilitarySystem.Common;
using MilitarySystem.Models;
using MilitarySystem.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MilitarySystem.Web.Areas.Administration.Models.InputModels
{
    public class PlatoonInputModel : IMapFrom<Platoon>, IMapTo<Platoon>
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelsConstraints.NameMaxLength)]
        public string Name { get; set; }
    }
}