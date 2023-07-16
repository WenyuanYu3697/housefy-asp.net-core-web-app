using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace housefyBackend.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string FullName { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(40)]
        public string PhoneModel { get; set; }

        [Required]
        [StringLength(30)]
        public string PhoneNumber { get; set; }

        public ICollection<Feedback>? Feedbacks { get; set; } // Navigation property
    }


    public class Feedback
    {
        [Key]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rate { get; set; }

        [Required]
        [StringLength(200)]
        public string Comment { get; set; }

        public User User { get; set; } // Navigation property
    }
}
