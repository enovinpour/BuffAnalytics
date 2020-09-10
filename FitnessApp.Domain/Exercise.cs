using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FitnessApp.Domain
{
    public class Exercise
    {
        public int ExerciseId { get; set; }
        [Required]
        public string DayOfTheWeek { get; set; }
        public decimal StartWeight { get; set; }
        public decimal GoalWeight { get; set; }
        public int StartSet { get; set; }
        public int GoalSet { get; set; }
        public int StartRep { get; set; }
        public int GoalRep { get; set; }
        public decimal MaxOneRep { get; set; }
        public int WorkoutId { get; set; }
        public Workout Workouts { get; set; }
        public UserExercise UserExercise { get; set; }
        public Progress Progresses { get; set; }
    }
}
