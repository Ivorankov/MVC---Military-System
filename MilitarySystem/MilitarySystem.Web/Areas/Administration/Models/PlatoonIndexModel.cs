namespace MilitarySystem.Web.Areas.Administration.Models
{
    using System.Collections.Generic;

    using MilitarySystem.Web.Areas.Administration.Models.ViewModels;

    public class PlatoonIndexModel
    {
        public ICollection<PlatoonViewModel> Platoons { get; set; }
    }
}