namespace MilitarySystem.Web.Areas.Administration.Models.ViewModels
{
    using MilitarySystem.Models;
    using MilitarySystem.Web.Infrastructure.Mapping;

    public class UserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImgUrl { get; set; }
    }
}