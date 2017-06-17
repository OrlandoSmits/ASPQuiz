﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPQuiz.Domain.Concrete;
using ASPQuiz.Domain.Entities;
using Ninject;
using PagedList;

namespace ASPQuiz.Controllers
{
    public class HomeController : Controller
    {
        private EFDbContext _context;

        public HomeController(EFDbContext context)
        {
            _context = context;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult QuestionOverView()
        {
            IEnumerable<Question> Questions = _context.Questions;

            return View(Questions);
        }

        public ActionResult AnswerOverView()
        {
            IEnumerable<Answer> Answers = _context.Answers;

            return View(Answers);
        }

		public ViewResult Quiz(int? page)
		{
			IEnumerable<Question> Questions = _context.Questions;

		    IEnumerable<Question> questionList = Questions.OrderBy(q => q.QuestionText);
		    int pageSize = 1;
		    int pageNumber = (page ?? 1);
			return View(questionList.ToPagedList(pageNumber, pageSize));
		}

    }
}