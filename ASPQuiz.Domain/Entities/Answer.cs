using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPQuiz.Domain.Entities
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }

        public String AnswerText { get; set; }

        public Question AnswerQuestion { get; set; }
    }
}
