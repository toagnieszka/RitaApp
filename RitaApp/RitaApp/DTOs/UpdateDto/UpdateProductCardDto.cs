using RitaApp.Data.Models;

namespace RitaApp.DTOs.UpdateDto
{
    public class UpdateProductCardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Category> Category { get; set; }
        public int CategoryId { get; set; }
        public Unit Unit { get; set; }
        public int UnitId { get; set; }
    }
}
