using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppCenterData.Models
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Login Login { get; set; }
        [Required]
        public Apps Apps { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
        [Required]
        public int Amount { get; set; }
    }
}
