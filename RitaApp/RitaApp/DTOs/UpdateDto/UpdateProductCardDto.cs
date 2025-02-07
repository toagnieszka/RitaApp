using RitaApp.Data.Models;

namespace RitaApp.DTOs.UpdateDto
{
    public class UpdateProductCardDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
       // public int CategoryId { get; set; }
        public int UnitId { get; set; }
    }
}
