using FitnessApp.Data.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FitnessApp.BLL
{
    public class WorkoutManager
    {
        public static List<Workouts> GetAll()
        {
            var context = new FitnessAppContext();
            var workouts = context.Workouts.ToList();

            return workouts;
        }


        public static IList GetAsKeyValuePair()
        {
            var context = new FitnessAppContext();
            var types = context.Workouts.Select(type => new
            {
                Value = type.Workoutid,
                Text = type.Workoutname
            }).ToList();

            return types;
        }
    }
}
