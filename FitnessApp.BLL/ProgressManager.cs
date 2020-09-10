using FitnessApp.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessApp.BLL
{
    public static class ProgressManager
    {
        public static IList<Progress> GetAll()
        {
            var context = new FitnessAppContext();
            var progress = context.Progress.Include(a => a.User).Include(a => a.Exercise).ToList();

            return progress; 
        }
    }
}
