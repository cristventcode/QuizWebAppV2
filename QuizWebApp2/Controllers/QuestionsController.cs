using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quizLibrary;

namespace QuizWebApp2.Controllers
{
    public class QuestionsController : Controller
    {
        public static quizRepo _quizRepo = new quizRepo();
        // GET: Questions
        public ActionResult Index(int quizId)
        {
            ViewBag.QuizId = quizId;
            return View(_quizRepo.GetQuestions(quizId));
        }

        // GET: Questions/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Questions/Create
        public ActionResult Create(int quizId)
        {
            ViewBag.QuizId = quizId;
            return View();
        }

        // POST: Questions/Create
        [HttpPost]
        public ActionResult Create(Question newQuestion, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                _quizRepo.AddQuestion(newQuestion);
                return RedirectToAction("Index", new { quizId = newQuestion.QuizId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Questions/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Questions/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Questions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
