using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text;

namespace FitnessApp.Domain
{
    public class User
    {
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public DateTime StartDate { get; set; }
        public decimal GoalWeight { get; set; }
        public Authentication Authentications { get; set; }
        public UserExercise UserExercises { get; set; }
        public Progress Progresses { get; set; }
    }
}
