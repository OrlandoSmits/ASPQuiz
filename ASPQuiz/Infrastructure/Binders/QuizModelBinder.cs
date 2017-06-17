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
            Question question = null;
            if (controllerContext.HttpContext.Session != null)
            {
                question = (Question) controllerContext.HttpContext.Session[sessionKey];
            }

            if (question == null)
            {
                question = new Question();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = question;
                }
            }

            return question;
        }
      
    }
}