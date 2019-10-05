using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppCenterData.Models
{
    public class FeedbackStatus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
