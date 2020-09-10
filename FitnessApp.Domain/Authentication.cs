using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessApp.Domain
{
    public class Authentication
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string PassWord { get; set; }
        public User Users { get; set; }
    }
}
