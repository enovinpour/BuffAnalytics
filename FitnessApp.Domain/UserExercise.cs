using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FitnessApp.Domain
{
    public class UserExercise
    {
        public int UserId { get; set; }
        public int ExerciseId { get; set; }
        public DateTime RoutineStartDate { get; set; }
        [Required]
        public bool RoutineActive { get; set; }

        public Exercise Exercises { get; set; }
        public User Users { get; set; }
    }
}
