namespace RitaApp.Data.Models
{
    public class Category : ModelBase
    {
        public string Name { get; set; }
        public List<ProductCard> ProductCards { get; set; }

    }
}
