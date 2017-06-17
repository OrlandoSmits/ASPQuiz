using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPQuiz.Domain.Entities;

namespace ASPQuiz.Infrastructure.Binders
{
    public class QuizModelBinder : IModelBinder
    {
        private const string sessionKey = "Quiz";

        public object BindModel(ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            Quiz quiz = null;
            if (controllerContext.HttpContext.Session != null)
            {
                quiz = (Quiz) controllerContext.HttpContext.Session[sessionKey];
            }

            if (quiz == null)
            {
                quiz = new Quiz();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = quiz;
                }
            }

            return quiz;
        }
      
    }
}