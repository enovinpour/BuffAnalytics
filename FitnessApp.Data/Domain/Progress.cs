using System;
using System.Collections.Generic;

namespace FitnessApp.Data.Domain
{
    public partial class Progress
    {
        public DateTime Date { get; set; }
        public decimal Userid { get; set; }
        public decimal Exerciseid { get; set; }
        public int? Setnumber { get; set; }
        public decimal? Workingweight { get; set; }
        public int? Reps { get; set; }
        public int? Rpe { get; set; }

        public virtual Exercises Exercise { get; set; }
        public virtual Users User { get; set; }
    }
}
