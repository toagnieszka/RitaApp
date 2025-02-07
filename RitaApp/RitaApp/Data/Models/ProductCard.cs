namespace RitaApp.Data.Models
{
    public class ProductCard : ModelBase
    {
        public string Name { get; set; }

        public required List<Category> Categories { get; set; }
        public required Unit Unit { get; set; }
        public int UnitId { get; set; }
    }
}
