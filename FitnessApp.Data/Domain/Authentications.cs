using System;
using System.Collections.Generic;

namespace FitnessApp.Data.Domain
{
    public partial class Authentications
    {
        public decimal Userid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual Users Users { get; set; }
    }
}
