namespace MilitarySystem.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common;

    public class Squad
    {
        private ICollection<Message> messages;

        private ICollection<User> soldiers;

        private ICollection<Mission> missions;

        private ICollection<Vehicle> vehicles;

        public Squad()
        {
            this.messages = new HashSet<Message>();
            this.soldiers = new HashSet<User>();
            this.missions = new HashSet<Mission>();
            this.vehicles = new HashSet<Vehicle>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelsConstraints.NameMaxLength)]
        public string Name { get; set; }

        public string SquadLeaderId { get; set; }

        public virtual User SquadLeader { get; set; }

        public int? CurrentLocationId { get; set; }

        public virtual Location CurrentLocation { get; set; }

        public int? PlatoonId { get; set; }

        public virtual Platoon Platton { get; set; }

        public int? ActiveMissionId { get; set; }

        public virtual Mission ActiveMission { get; set; }

        public virtual ICollection<Message> Messages { get { return this.messages; } set { this.messages = value; } }

        public virtual ICollection<User> Soldiers { get { return this.soldiers; } set { this.soldiers = value; } }

        public virtual ICollection<Mission> Missions { get { return this.missions; } set { this.missions = value; } }

        public virtual ICollection<Vehicle> Vehicles { get { return this.vehicles; } set { this.vehicles = value; } }
    }
}
