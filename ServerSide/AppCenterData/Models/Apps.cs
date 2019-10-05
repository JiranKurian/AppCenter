using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppCenterData.Models
{
    public class Apps
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Category Category { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Apk { get; set; }
        [Required]
        public string Version { get; set; }
        [Required]
        public DateTime LatestUpdate { get; set; }
        [Required]
        public bool Mature { get; set; }
    }
}
