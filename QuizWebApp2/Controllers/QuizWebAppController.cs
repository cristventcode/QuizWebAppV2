using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quizLibrary;


namespace QuizWebApp2.Controllers
{
    public class QuizWebAppController : Controller
    {

        public static quizRepo _quizRepo = new quizRepo();
        // GET: QuizWebApp

        public ActionResult Index()
        {
            return View(_quizRepo.GetQuizAll());
        }

        // GET: QuizWebApp/Details/5
        public ActionResult Details(int id)
        {
            return View(_quizRepo.GetQuizById(id));
        }

        // GET: QuizWebApp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuizWebApp/Create
        [HttpPost]
        public ActionResult Create(Quiz newQuiz, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                newQuiz.PublishDate = DateTime.Now;
                _quizRepo.AddQuiz(newQuiz);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: QuizWebApp/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_quizRepo.GetQuizById(id));
        }

        // POST: QuizWebApp/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Quiz EditedQuiz, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                _quizRepo.EditQuiz(EditedQuiz);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuizWebApp/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_quizRepo.GetQuizById(id));
        }

        // POST: QuizWebApp/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _quizRepo.DeleteQuiz(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult GameArea(int id)
        {
            ViewBag.QuizId = id;
            return View();
        }
    }
}
