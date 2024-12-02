using RitaApp.Data.Models;

namespace RitaApp.DTOs.CreateDto
{
    public class CreateProductCardDto
    {
        public string Name { get; set; }
        public List<Category> Category { get; set; }
        public int CategoryId { get; set; }
        public Unit Unit { get; set; }
        public int UnitId { get; set; }
    }
}
