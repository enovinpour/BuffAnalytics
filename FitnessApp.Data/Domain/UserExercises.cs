using System;
using System.Collections.Generic;

namespace FitnessApp.Data.Domain
{
    public partial class UserExercises
    {
        public decimal Userid { get; set; }
        public decimal Exerciseid { get; set; }
        public DateTime? Routinestartdate { get; set; }
        public bool? Routineactive { get; set; }

        public virtual Exercises Exercise { get; set; }
        public virtual Users User { get; set; }
    }
}
