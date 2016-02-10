namespace MilitarySystem.Models
{
    using System.Collections.Generic;

    public class Platoon
    {
        private ICollection<Message> messages;

        private ICollection<Squad> squads; 

        public Platoon()
        {
            this.messages = new HashSet<Message>();
            this.squads = new HashSet<Squad>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string PlatoonCommanderId { get; set; }

        public virtual User PlatoonCommander { get; set; }

        public ICollection<Message> Messages { get { return this.messages; } set { this.messages = value; } }

        public ICollection<Squad> Squads { get {return this.squads; } set {this.squads = value; } }

    }
}
