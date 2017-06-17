using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPQuiz.Domain.Concrete;
using ASPQuiz.Domain.Entities;
using Castle.Core.Internal;
using Ninject;
using PagedList;

namespace ASPQuiz.Controllers
{
    public class HomeController : Controller
    {
        private EFDbContext _context;
        private static List<Question> _questionList = new List<Question>();

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
		    if (_questionList.Count == 0)
		    {
                Random rnd = new Random();
		        int r = rnd.Next(1, _context.Questions.Count());

                _questionList.Add(_context.Questions.FirstOrDefault(q => q.Id == r));
                
                for (var i = 0; i < 4; i++)
		        {
		            while (_questionList.Any(q => q.Id == r))
		            {
		                r = rnd.Next(1, _context.Questions.Count());
		            }

                    _questionList.Add(_context.Questions.FirstOrDefault(q => q.Id == r));
		        }
		    }

		    int pageSize = 1;
		    int pageNumber = (page ?? 1);
			return View(_questionList.ToPagedList(pageNumber, pageSize));
		}

    }
}