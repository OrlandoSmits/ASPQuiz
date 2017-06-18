using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ASPQuiz.Domain.Abstract;
using ASPQuiz.Domain.Concrete;
using ASPQuiz.Domain.Entities;
using ASPQuiz.Models;
using PagedList;

namespace ASPQuiz.Controllers
{
    public class QuizController : Controller
    {
        private EFDbContext _context;
        private static List<Question> _questionList = new List<Question>();

        public QuizController(EFDbContext context)
        {
            _context = context;
        }

        // GET: Quiz
        public ViewResult Index(Quiz quiz, string returnUrl, int? page)
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

            int pageSize = 3;
            int pageNumber = (page ?? 1);

          return View(new QuizPagedListViewModel
            {
                PagedList = _questionList.ToPagedList(pageNumber, pageSize),
                Quiz = quiz
            });
        }

        public RedirectResult AddToQuiz(Quiz quiz, int questionId, int answerId, string returnUrl)
        {
            Question question = _context.Questions
                .FirstOrDefault(q => q.Id == questionId);

            Answer answer = _context.Answers
                .FirstOrDefault(a => a.Id == answerId);

            if (question != null && answer != null)
            {
                quiz.AddItem(question, answer);
            }


            return Redirect(returnUrl);
        }

        public RedirectResult RemoveFromQuiz(Quiz quiz, int questionId, string returnUrl)
        {
            Question question = _context.Questions
                .FirstOrDefault(q => q.Id == questionId);

            if (question != null)
            {
                quiz.RemoveItem(question);
            }

            return Redirect(returnUrl);
        }

        public ViewResult quizView(string returnUrl)
        {
            Quiz quiz = GetQuiz();

            if (quiz.Lines.Count() < 5)
            {
                // TODO: Give Error to User
            }


            return View(new QuizIndexViewModel
            {
                Quiz = GetQuiz(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult ToHome(Quiz quiz)
        {
            quiz.Clear();
            _questionList.Clear();

            return RedirectToAction("Index", "Home");
        }

        public Quiz GetQuiz()
        {
            Quiz quiz = (Quiz) Session["Quiz"];

            return quiz;
        }
    }
}