namespace RitaApp.Data.Models
{
    public class ProductCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public Unit Unit { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
