using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using quizLibrary;

namespace QuizWebApp2.Controllers
{
    public class AnswersController : Controller
    {
        public static quizRepo _quizRepo = new quizRepo();
        // GET: Answers
        public ActionResult Index(int questionId)
        {
            Question questionTarget = _quizRepo.GetQuestionById(questionId);
            ViewBag.QuizTitle = _quizRepo.GetQuizById(questionTarget.QuizId).Title;
            ViewBag.QuestionInfo = questionTarget;
            ViewBag.QuestionId = questionId;
            return View(_quizRepo.GetAnswers(questionId));
        }

        // GET: Answers/Details/5
        public ActionResult Details(int id)
        {
            return View(_quizRepo.GetAnswerById(id));
        }

        // GET: Answers/Create
        public ActionResult Create(int questionId)
        {
            ViewBag.QuestionId = questionId;
            return View();
        }

        // POST: Answers/Create
        [HttpPost]
        public ActionResult Create(Answer newAnswer, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                _quizRepo.AddAnswer(newAnswer);
                return RedirectToAction("Index", new { questionId = newAnswer.QuestionId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Answers/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_quizRepo.GetAnswerById(id));
        }

        // POST: Answers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Answer editedAnswer, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                _quizRepo.EditAnswer(editedAnswer);
                return RedirectToAction("Index", new { questionId = editedAnswer.QuestionId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Answers/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_quizRepo.GetAnswerById(id));
        }

        // POST: Answers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _quizRepo.DeleteAnswer(id);
                return RedirectToAction("Index", new { quizId = _quizRepo.GetAnswerById(id).QuestionId });
            }
            catch
            {
                return View();
            }
        }
    }
}
