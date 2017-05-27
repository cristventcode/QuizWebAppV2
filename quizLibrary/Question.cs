using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizLibrary
{
    public class Question
    {
        public Question()
        {
            Answers = new List<Answer>();
        }
        public int QuestionId { get; set; }
        public int QuizId { get; set; }
        public string Content { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
