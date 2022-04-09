using System;
using System.ComponentModel.DataAnnotations;

namespace DifferenceStoredProcedureTransactionsCodeApp.Models
{
    public class Product
    {
        [Required(ErrorMessage = "IdProduct jest wymagane")]
        public int _IdProduct { get; set; }

        [Required(ErrorMessage = "IdWareHouse jest wymagane")]
        public int _IdWareHouse { get; set; }
        [Required(ErrorMessage = "Amount jest wymagane")]
        public int _Amount { get; set; }

        [Required(ErrorMessage = "CreatedAt(Data) jest wymagana")]
        public DateTime _CreatedAt { get; set; }

    }
}
