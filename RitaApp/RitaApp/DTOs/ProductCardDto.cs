using RitaApp.Data.Models;

namespace RitaApp.DTOs
{
    public class ProductCardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CategoryDto> Categories { get; set; }
        public int UnitId { get; set; }
        public UnitDto Unit { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
