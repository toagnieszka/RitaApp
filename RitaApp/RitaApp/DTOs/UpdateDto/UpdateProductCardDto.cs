using RitaApp.Data.Models;

namespace RitaApp.DTOs.UpdateDto
{
    public class UpdateProductCardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
		public List<int>? CategoryIds { get; set; } = new List<int>();
		public int UnitId { get; set; }
    }
}
