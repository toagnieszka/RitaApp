﻿using RitaApp.Data.Models;
using RitaApp.Data;

namespace RitaApp.DTOs.CreateDto
{
    public class CreateProductDto
    {
        public int ProductCardId { get; set; }
        public int MagazineId { get; set; }
        public float Amount { get; set; }
        public Status Status { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Comment { get; set; }
        public DateTime LoanDate { get; set; }
        public string Lender { get; set; }
        public string Borrower { get; set; }
    }
}
