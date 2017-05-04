using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPQuiz.Domain.Entities;

namespace ASPQuiz.Domain.Abstract
{
    public interface IQuizRepository
    {
        IEnumerable<Question> Questions { get; }

        IEnumerable<Answer> Answers { get; }
    }
}
