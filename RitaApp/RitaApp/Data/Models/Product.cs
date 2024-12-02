using System.Diagnostics.Contracts;

namespace RitaApp.Data.Models
{
    public class Product : ModelBase
    {
        public ProductCard ProductCard { get; set; }
        public int ProductCardId { get; set; }
        public Magazine Magazine { get; set; }
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
