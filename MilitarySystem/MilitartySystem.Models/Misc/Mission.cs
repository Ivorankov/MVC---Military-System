namespace MilitarySystem.Models
{
    public class Mission
    {
        public int Id { get; set; }

        public string Info { get; set; }

        public int TargetLocationId { get; set; }

        public virtual Location TargetLocation { get; set; }

        public int SquadId { get; set; }

        public virtual Squad Squad { get; set; }

        public bool IsActive { get; set; }

        //Type enum TODO maybe
    }
}
