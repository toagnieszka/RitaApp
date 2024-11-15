using RitaApp.Data.Models;

namespace RitaApp.DTOs
{
    public class CreateProductCardDto
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public Unit Unit { get; set; }
    }
}
