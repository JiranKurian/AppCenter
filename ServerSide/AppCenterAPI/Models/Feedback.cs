using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AppCenterData.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Login Login { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public FeedbackStatus FeedbackStatus { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
