namespace MilitartySystem.Models
{
    using System.Collections.Generic;

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

        public int Id { get; set; }

        public string Name { get; set; }

        public string SquadLeaderId { get; set; }

        public virtual User SquadLeader { get; set; }

        public Location CurrentLocation { get; set; }

        public ICollection<Message> Messages { get { return this.messages; } set { this.messages = value; } }

        public ICollection<User> Soldiers { get { return this.soldiers; } set { this.soldiers = value; } }

        public ICollection<Mission> Missions { get { return this.missions; } set { this.missions = value; } }

        public ICollection<Vehicle> Vehicles { get { return this.vehicles; } set { this.vehicles = value; } }
    }
}
