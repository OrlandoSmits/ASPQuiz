using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASPQuiz.Domain.Entities;

namespace ASPQuiz.Domain.Concrete
{
    public class QuizInitializer : DropCreateDatabaseIfModelChanges<EFDbContext>
    {
        protected override void Seed(EFDbContext context)
        {
            context.Database.Initialize(true);

            var Answers = new List<Answer>();

            Answer q1a1 = new Answer()
            {
                AnswerText = "vraag 1 antwoord 1"
            };
            Answers.Add(q1a1);
            Answer q1a2 = new Answer()
            {
                AnswerText = "vraag 1 antwoord 2"
            };
            Answers.Add(q1a2);

            Answer q1a3 = new Answer()
            {
                AnswerText = "vraag 1 antwoord 3"
            };
            Answers.Add(q1a3);

            Answer q1a4 = new Answer()
            {
                AnswerText = "vraag 1 antwoord 4"
            };
            Answers.Add(q1a4);

       

            var Questions = new List<Question>();

            Question q1 = new Question()
            {
                QuestionText = "vraag 1",
                CorrectAnswer = q1a1,
            };
            Questions.Add(q1);


            Answers.ForEach(x => context.Answers.AddOrUpdate(x));
            context.SaveChanges();

            Questions.ForEach(x => context.Questions.AddOrUpdate(x));
            context.SaveChanges();
        }
    }
}