using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

       
        public virtual Answer CorrectAnswer { get; set; }

        public virtual Answer Answer1 { get; set; }

        public virtual Answer Answer2 { get; set; }
        

    }
}
