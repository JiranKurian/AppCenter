using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppCenterData.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Login Login { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public DateTime DOB { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public long Phone { get; set; }
        [Required]
        public DateTime JoinDate { get; set; }
    }
}
