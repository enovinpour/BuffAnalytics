using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FitnessApp.BLL;
using FitnessApp.Data.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using Microsoft.AspNetCore.Authorization;

namespace FitnessApp.PresentationLayer.Controllers
{
    [Authorize]
    public class ExerciseController : Controller
    {
        // GET: ExerciseController
        public IActionResult Index()
        {
            var exercises = ExercisesManager.GetExercises().OrderBy(a=>a.Dayoftheweek);

            return View(exercises);
        }

        // GET: ExerciseController/Create
        public IActionResult Create()
        {
            var types = WorkoutManager.GetAsKeyValuePair();
            var list = new SelectList(types, "Value", "Text").ToList() ;

            ViewBag.Workoutid = list;

            return View();
        }

        // POST: ExerciseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Exercises exercise)
        {
            try
            {
                ExercisesManager.Add(exercise);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExerciseController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExerciseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExerciseController/Delete/5
        public IActionResult Delete()
        {
            return View();
        }

        // POST: ExerciseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Exercises exercise)
        {
            try
            {
                ExercisesManager.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
