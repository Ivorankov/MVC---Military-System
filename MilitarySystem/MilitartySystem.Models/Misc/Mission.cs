namespace MilitartySystem.Models
{
    public class Mission
    {
        public int Id { get; set; }

        public string Info { get; set; }

        public Location TargetLocation { get; set; }

        public int SquadId { get; set; }

        public virtual Squad Squad { get; set; }

        public bool HasSucceeded { get; set; }

        //Type enum TODO maybe
    }
}
