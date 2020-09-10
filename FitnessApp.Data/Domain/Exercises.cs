using System;
using System.Collections.Generic;

namespace FitnessApp.Data.Domain
{
    public partial class Exercises
    {
        public Exercises()
        {
            Progress = new HashSet<Progress>();
            UserExercises = new HashSet<UserExercises>();
        }

        public decimal Exerciseid { get; set; }
        public string Dayoftheweek { get; set; }
        public decimal? Startweight { get; set; }
        public decimal? Goalweight { get; set; }
        public int? Startset { get; set; }
        public int? Goalset { get; set; }
        public int? Startrep { get; set; }
        public int? Goalrep { get; set; }
        public decimal? Maxonerep { get; set; }
        public decimal? Workoutid { get; set; }

        public virtual Workouts Workout { get; set; }
        public virtual ICollection<Progress> Progress { get; set; }
        public virtual ICollection<UserExercises> UserExercises { get; set; }
    }
}
