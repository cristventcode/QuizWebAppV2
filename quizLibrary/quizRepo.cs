using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace quizLibrary
{
    public class quizRepo
    {

        public void AddQuiz(Quiz newQuiz)
        {
            using (var db = new quizDbContext())
            {
                db.QuizTable.Add(newQuiz);
                db.SaveChanges();
            }
        }

        public Quiz GetQuizById(int id)
        {
            using (var db = new quizDbContext())
            {
                Quiz targetQuiz = db.QuizTable.Find(id);
                return targetQuiz;
            }
        }

        public List<Quiz> GetQuizAll()
        {
            using (var db = new quizDbContext())
            {
                var quizzes = from quiz in db.QuizTable
                              select quiz;

                return quizzes.ToList();
            }
        }

        public void EditQuiz(Quiz editedQuiz)
        {
            using (var db = new quizDbContext())
            {
                db.QuizTable.Attach(editedQuiz);
                var entry = db.Entry(editedQuiz);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteQuiz(int id)
        {
            using (var db = new quizDbContext())
            {
                var targetQuiz = db.QuizTable.Find(id);
                db.QuizTable.Remove(targetQuiz);
                db.SaveChanges();
            }
        }

        public void AddQuestion(Question newQuestion)
        {
            using (var db = new quizDbContext())
            {
                db.QuestionTable.Add(newQuestion);
                db.SaveChanges();
            }
        }

        public List<Question> GetQuestions(int QuizId)
        {
            using (var db = new quizDbContext())
            {
                var questions = from question in db.QuestionTable
                                where question.QuizId == QuizId
                                select question;
                return questions.ToList();
            }
        }

        public Question GetQuestionById(int id)
        {
            using (var db = new quizDbContext())
            {
                var question = db.QuestionTable.Find(id);
                db.Entry(question).Collection(quest => quest.Answers).Load();
                return question;
            }
        }

        public void EditQuestion(Question editedQuestion)
        {
            using (var db = new quizDbContext())
            {
                db.QuestionTable.Attach(editedQuestion);
                var entry = db.Entry(editedQuestion);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteQuestion(int id)
        {
            using (var db = new quizDbContext())
            {
                db.QuestionTable.Remove(GetQuestionById(id));
                db.SaveChanges();
            }
        }

        public void AddAnswer(Answer newAnswer)
        {
            using (var db = new quizDbContext())
            {
                db.AnswerTable.Add(newAnswer);
                db.SaveChanges();
            }
        }

        public List<Answer> GetAnswers(int QuestionId)
        {
            using (var db = new quizDbContext())
            {
                var answers = from answer in db.AnswerTable
                              where answer.QuestionId == QuestionId
                              select answer;
                return answers.ToList();
            }
        }

        public Answer GetAnswerById(int id)
        {
            using (var db = new quizDbContext())
            {
                var answer = db.AnswerTable.Find(id);
                return answer;
            }
        }

        public void EditAnswer(Answer editedAnswer)
        {
            using (var db = new quizDbContext())
            {
                db.AnswerTable.Attach(editedAnswer);
                var entry = db.Entry(editedAnswer);
                entry.State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void DeleteAnswer(int id)
        {
            using (var db = new quizDbContext())
            {
                db.AnswerTable.Remove(GetAnswerById(id));
                db.SaveChanges();
            }
        }
    }
}
