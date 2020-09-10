using System;
using System.Collections.Generic;

namespace FitnessApp.Data.Domain
{
    public partial class Workouts
    {
        public Workouts()
        {
            Exercises = new HashSet<Exercises>();
        }

        public decimal Workoutid { get; set; }
        public string Workoutname { get; set; }
        public string Workouttype { get; set; }
        public string BodyPart { get; set; }

        public virtual ICollection<Exercises> Exercises { get; set; }
    }
}
