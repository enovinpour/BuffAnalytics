using FitnessApp.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessApp.BLL
{
    public static class UserManager
    {
        public static Users GetInfo(int id)
        {
            var context = new FitnessAppContext();
            var user = context.Users.SingleOrDefault(a => a.Userid == id);

            return user;
        }
    }
}
