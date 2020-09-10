using System;
using System.Collections.Generic;

namespace FitnessApp.Data.Domain
{
    public partial class Users
    {
        public Users()
        {
            Progress = new HashSet<Progress>();
            UserExercises = new HashSet<UserExercises>();
        }

        public decimal Userid { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public DateTime? Startdate { get; set; }
        public decimal? Goalweight { get; set; }

        public virtual Authentications User { get; set; }
        public virtual ICollection<Progress> Progress { get; set; }
        public virtual ICollection<UserExercises> UserExercises { get; set; }
    }
}
