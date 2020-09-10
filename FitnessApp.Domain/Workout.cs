using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FitnessApp.Domain
{
    public class Workout
    {
        public int WorkoutId { get; set; }
        public string WorkoutName { get; set; }
        public string WorkoutType { get; set; }
        public Exercise Exercises { get; set; }
    }
}
