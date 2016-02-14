namespace MilitarySystem.Models
{
    using Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Platoon
    {
        private ICollection<Message> messages;

        private ICollection<Squad> squads; 

        public Platoon()
        {
            this.messages = new HashSet<Message>();
            this.squads = new HashSet<Squad>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ModelsConstraints.NameMaxLength)]
        public string Name { get; set; }

        public string PlatoonCommanderId { get; set; }

        public virtual User PlatoonCommander { get; set; }

        public virtual ICollection<Message> Messages { get { return this.messages; } set { this.messages = value; } }

        public virtual ICollection<Squad> Squads { get {return this.squads; } set {this.squads = value; } }

    }
}
