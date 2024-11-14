using RitaApp.Data.Models;

namespace RitaApp.DTOs
{
    public class ProductCardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public Unit Unit { get; set; }
    }
}
