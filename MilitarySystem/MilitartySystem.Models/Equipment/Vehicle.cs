namespace MilitarySystem.Models
{
    public class Vehicle : BaseEquipment
    {
        public int Id { get; set; }

        public int? SquadId { get; set; }

        public virtual Squad Squad { get; set; }

    }
}
