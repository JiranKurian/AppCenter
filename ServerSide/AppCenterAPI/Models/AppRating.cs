using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppCenterData.Models
{
    public class AppRating
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Apps Apps { get; set; }
        [Required]
        public Login Login { get; set; }
        [Required]
        public int Rating { get; set; }
    }
}
