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
            ViewBag.QuizTitle = _quizRepo.GetQuizById(quizId).Title;
            ViewBag.QuizId = quizId;
            return View(_quizRepo.GetQuestions(quizId));
        }

        // GET: Questions/Details/5
        public ActionResult Details(int id)
        {
            return View(_quizRepo.GetQuestionById(id));
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
            return View(_quizRepo.GetQuestionById(id));
        }

        // POST: Questions/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Question editedQuestion, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                _quizRepo.EditQuestion(editedQuestion);
                return RedirectToAction("Index", new { quizId = editedQuestion.QuizId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Questions/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_quizRepo.GetQuestionById(id));
        }

        // POST: Questions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _quizRepo.DeleteQuestion(id);
                return RedirectToAction("Index", new { quizId = _quizRepo.GetQuestionById(id).QuizId });
            }
            catch
            {
                return View();
            }
        }
    }
}
