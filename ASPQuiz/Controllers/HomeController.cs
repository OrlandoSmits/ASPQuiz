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
    }
}