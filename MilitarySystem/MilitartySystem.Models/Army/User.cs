namespace MilitarySystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Misc;

    public class User : IdentityUser
    {
        ICollection<Weapon> weapons;

        ICollection<Gear> gear;

        ICollection<Mission> missions;

        public User()
        {
            this.weapons = new HashSet<Weapon>();
            this.gear = new HashSet<Gear>();
            this.missions = new HashSet<Mission>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public decimal Wage { get; set; }

        public int Rank { get; set; }

        public int ImageId { get; set; }

        public Image Image { get; set; }

        public ICollection<Weapon> Weapons { get { return this.weapons; } set { this.weapons = value; } }

        public ICollection<Gear> Gear { get { return this.gear; } set { this.gear = value; } }

        public ICollection<Mission> Missions { get { return this.missions; } set { this.missions = value; } }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
