using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ASPQuiz.Domain.Entities;
using PagedList;

namespace ASPQuiz.Models
{
    public class QuizPagedListViewModel
    {
        public IPagedList<Question> PagedList;

        public Quiz Quiz;

    }
}