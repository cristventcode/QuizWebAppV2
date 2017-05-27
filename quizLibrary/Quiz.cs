using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quizLibrary
{
    public class Quiz
    {
        public Quiz()
        {
            Questions = new List<Question>();
        }
        public int QuizId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublishDate { get; set; }
        public List<Question> Questions { get; set; }
    }
}
