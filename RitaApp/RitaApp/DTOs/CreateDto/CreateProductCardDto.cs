using RitaApp.Data.Models;

namespace RitaApp.DTOs.CreateDto
{
    public class CreateProductCardDto
    {
        public string Name { get; set; }
        public int UnitId { get; set; }
        public List<int>? CategoryIds { get; set; }   = new List<int>();
    }
}
