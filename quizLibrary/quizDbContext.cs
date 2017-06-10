using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace quizLibrary
{
    public class quizDbContext : DbContext
    {
        public quizDbContext()
         : base("name=DefaultConnection")
        {
        }

        public DbSet<Quiz> QuizTable { get; set; }
        public DbSet<Question> QuestionTable { get; set; }
        public DbSet<Answer> AnswerTable { get; set; }


    }
}
