namespace MilitartySystem.Models
{
    public abstract class BaseEquipment
    {
        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }
    }
}
