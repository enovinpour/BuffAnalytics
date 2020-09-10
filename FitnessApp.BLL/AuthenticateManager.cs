using FitnessApp.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessApp.BLL
{
    public class AuthenticateManager
    {
        public static Authentications GetAuthentication(string username, string password)
        {
            var context = new FitnessAppContext();
            var authenticatedUser = context.Authentications.SingleOrDefault(a => a.Username == username
                && a.Password == password);

            return authenticatedUser;
        }
    }
}
