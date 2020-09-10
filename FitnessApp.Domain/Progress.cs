using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FitnessApp.Domain
{
    public class Progress
    {
        [Required]
        public DateTime date { get; set; }
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        [Required]
        public int SetNumber { get; set; }
        [Required]
        public int WorkingWeight { get; set; }
        [Required]
        public int Reps { get; set; }
        public int? RPE { get; set; }
        public User Users { get; set; }
        public Exercise Exercises { get; set; }
    }
}
