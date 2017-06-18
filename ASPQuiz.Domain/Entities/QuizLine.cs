using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPQuiz.Domain.Entities
{
    public class QuizLine
    {
        public Question Question { get; set; }
        public Answer Answer { get; set; }


        public Boolean isAnswerCorrect()
        {
            return this.Question.CorrectAnswer.Id == this.Answer.Id;
        }
    }
}
