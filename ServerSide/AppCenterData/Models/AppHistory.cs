using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppCenterData.Models
{
    public class AppHistory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Apps Apps { get; set; }
        [Required]
        public DateTime LastDate { get; set; }
        [Required]
        public string Version { get; set; }
    }
}
