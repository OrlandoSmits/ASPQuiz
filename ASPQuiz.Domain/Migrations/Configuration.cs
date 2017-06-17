using System.Collections.Generic;
using ASPQuiz.Domain.Concrete;
using ASPQuiz.Domain.Entities;

namespace ASPQuiz.Domain.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ASPQuiz.Domain.Concrete.EFDbContext>
    {
        public EFDbContext Context;

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ASPQuiz.Domain.Concrete.EFDbContext";
        }

        protected override void Seed(ASPQuiz.Domain.Concrete.EFDbContext context)
        {
            this.Context = context;

            Answer q1a1 = new Answer()
            {
                AnswerText = "Jazeker"
            };
            Answer q1a2 = new Answer()
            {
                AnswerText = "Meh"
            };
            Answer q1a3 = new Answer()
            {
                AnswerText = "Zeker niet"
            };

            List<Answer> answers = new List<Answer>();
            answers.Add(q1a1);
            answers.Add(q1a2);
            answers.Add(q1a3);

            context.Answers.AddRange(answers);
            

            Question q1 = new Question()
            {
                QuestionText = "Is ASP Awesome",
                Answer1 = q1a1,
                Answer2 =   q1a2,
                CorrectAnswer = q1a3
            };

            Question q2 = new Question()
            {
                QuestionText = "Is deze vraag getoond?",
                Answer1 = q1a1,
                Answer2 = q1a2,
                CorrectAnswer = q1a3
            };


            context.Questions.AddOrUpdate(q1);
            context.Questions.AddOrUpdate(q2);


            base.Seed(context);
        }
    }
}