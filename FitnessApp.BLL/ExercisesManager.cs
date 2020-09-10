using FitnessApp.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FitnessApp.BLL
{
    public class ExercisesManager
    {
        public static List<Exercises> GetExercises()
        {
            var context = new FitnessAppContext();
            var exercises = context.Exercises.Include(a => a.Workout).ToList();
            return exercises;
        }

        public static void Add(Exercises exercise)
        {
            var context = new FitnessAppContext();
            context.Exercises.Add(exercise);
            context.SaveChanges();
        }

        public static void Delete(int id)
        {
            var context = new FitnessAppContext();
            Exercises delex = (Exercises)context.Exercises.Where(e => e.Exerciseid == id).SingleOrDefault();
            context.Exercises.Remove(delex);
            context.SaveChanges();
        }
    }
}
