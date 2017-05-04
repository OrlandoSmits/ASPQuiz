using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPQuiz.Domain.Abstract;
using ASPQuiz.Domain.Entities;

namespace ASPQuiz.Domain.Concrete
{
    public class EFQuizRepository : IQuizRepository
    {
        private EFDbContext _dbContext = new EFDbContext();

        public IEnumerable<Question> Questions
        {
            get { return _dbContext.Questions.ToList(); }
        }

        public IEnumerable<Answer> Answers
        {
            get { return _dbContext.Answers.ToList();  }
        }
    }
}
