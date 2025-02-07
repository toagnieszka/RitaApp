using RitaApp.Data;

namespace RitaApp.DTOs
{
    public class ProductDto
    {
        public int Id { get; set; }
        public ProductCardDto ProductCard { get; set; }
        public int ProductCardId { get; set; }
        public MagazineDto Magazine { get; set; }
        public int MagazineId { get; set; }
        public float Amount { get; set; }
        public Status Status { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Comment { get; set; }
        public DateTime LoanDate { get; set; }
        public string Lender { get; set; }
        public string Borrower { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
