using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPQuiz.Domain.Entities
{
    public class Question
    {
        [Key]
        public int Id { get; set; }

        public String QuestionText { get; set; }

        public Answer CorrectAnswer { get; set; }

        public List<Answer> AnswerList { get; set; }

    }
}
