﻿namespace MilitarySystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Common;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User : IdentityUser
    {
        private ICollection<Weapon> weapons;

        private ICollection<Gear> gear;

        private ICollection<Mission> missions;

        private ICollection<Message> messages;

        public User()
        {
            this.weapons = new HashSet<Weapon>();
            this.gear = new HashSet<Gear>();
            this.missions = new HashSet<Mission>();
            this.messages = new HashSet<Message>();
        }

        [Required]
        [MaxLength(ModelsConstraints.NameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(ModelsConstraints.NameMaxLength)]
        public string LastName { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EnrollmentDate { get; set; }

        public decimal Wage { get; set; }

        public string ImgUrl { get; set; }

        [Range(0,56)]
        public int Rank { get; set; }

        public int? SquadId { get; set; }

        public virtual Squad Squad { get; set; }

        public virtual ICollection<Weapon> Weapons { get { return this.weapons; } set { this.weapons = value; } }

        public virtual ICollection<Gear> Gear { get { return this.gear; } set { this.gear = value; } }

        public virtual ICollection<Mission> Missions { get { return this.missions; } set { this.missions = value; } }

        public virtual ICollection<Message> Messages { get { return this.messages; } set { this.messages = value; } }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
