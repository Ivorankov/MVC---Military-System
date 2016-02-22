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
    public class UserInputModel : IMapFrom<User>, IMapTo<User>
    {

        [HiddenInput(DisplayValue = false)]
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        public string UserName { get; set; }

        [Required]
        [MaxLength(ModelsConstraints.NameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(ModelsConstraints.NameMaxLength)]
        public string LastName { get; set; }

        public decimal Wage { get; set; }

        [Range(0, 56)]
        public int Rank { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

    }
}