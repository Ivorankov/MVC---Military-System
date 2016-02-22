namespace MilitarySystem.Web.Areas.Administration.Models.InputModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using MilitarySystem.Common;
    using MilitarySystem.Models;
    using MilitarySystem.Web.Infrastructure.Mapping;

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