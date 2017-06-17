using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPQuiz.Domain.Entities;

namespace ASPQuiz.Models
{
    public class QuizIndexViewModel
    {
        public Quiz Quiz { get; set; }
        public string ReturnUrl { get; set; }
    }
}