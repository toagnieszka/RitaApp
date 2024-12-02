namespace RitaApp.Data.Models
{
    public class ProductCard : ModelBase
    {
        public string Name { get; set; }
        public List<Category> Category { get; set; }
        public int CategoryId { get; set; }
        public Unit Unit { get; set; }
        public int UnitId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
