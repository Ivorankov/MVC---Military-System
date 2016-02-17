namespace MilitarySystem.Web.Areas.Administration.Models.BaseModels
{
    public class EquipmentInputModel
    {
        public int Id { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public int ManufacturerId { get; set; }
    }
}