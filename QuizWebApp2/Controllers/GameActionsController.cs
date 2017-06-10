using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using quizLibrary;
using System.Data.Entity;

namespace QuizWebApp2.Controllers
{
    public class GameActionsController : ApiController
    {
        public static quizRepo _quizRepo = new quizRepo();
        // GET: api/GameActions
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GameActions/5
        public List<Question> Get(int id)
        {
            using (var db = new quizDbContext())
            {
                var questions = db.QuestionTable
                                .Where(quest => quest.QuizId == id)
                                .Include(quest => quest.Answers);

                return questions.ToList();
            }
        }

        // POST: api/GameActions
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GameActions/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GameActions/5
        public void Delete(int id)
        {
        }
    }
}
