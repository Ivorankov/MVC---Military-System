namespace MilitartySystem.Models
{
    public class Weapon : BaseEquipment
    {
        public int Id { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }
    }
}
