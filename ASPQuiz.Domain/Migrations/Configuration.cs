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
            context.Database.Delete();

            context.Database.Create();
            Answer q1a1 = new Answer()
            {
                AnswerText = "Angerfist"
            };
            Answer q1a2 = new Answer()
            {
                AnswerText = "Korsakoff"
            };
            Answer q1a3 = new Answer()
            {
                AnswerText = "Paul Elstak"
            };
            Answer q2a1 = new Answer()
            {
                AnswerText = "Brennan Thera"
            };
            Answer q2a2 = new Answer()
            {
                AnswerText = "Brensakoff"
            };
            Answer q2a3 = new Answer()
            {
                AnswerText = "Brennan & Heart"
            };
            Answer q3a1 = new Answer()
            {
                AnswerText = "Karel"
            };
            Answer q3a2 = new Answer()
            {
                AnswerText = "Willem"
            };
            Answer q3a3 = new Answer()
            {
                AnswerText = "Pjotr"
            };
            Answer q4a1 = new Answer()
            {
                AnswerText = "B-Front"
            };
            Answer q4a2 = new Answer()
            {
                AnswerText = "Coone"
            };
            Answer q4a3 = new Answer()
            {
                AnswerText = "2Sidez"
            };
            Answer q5a1 = new Answer()
            {
                AnswerText = "Vlaggenzwaaier"
            };
            Answer q5a2 = new Answer()
            {
                AnswerText = "Producer"
            };
            Answer q5a3 = new Answer()
            {
                AnswerText = "Master of Ceremonies (MC)"
            };
            Answer q6a1 = new Answer()
            {
                AnswerText = "Angerfist"
            };
            Answer q6a2 = new Answer()
            {
                AnswerText = "Joey van Ingen"
            };
            Answer q6a3 = new Answer()
            {
                AnswerText = "Miss K8"
            };
            Answer q7a1 = new Answer()
            {
                AnswerText = "D-House & S-Te-Block"
            };
            Answer q7a2 = new Answer()
            {
                AnswerText = "D-Fence & S-Te-House"
            };
            Answer q7a3 = new Answer()
            {
                AnswerText = "DBSTF"
            };
            Answer q8a1 = new Answer()
            {
                AnswerText = "200bpm"
            };
            Answer q8a2 = new Answer()
            {
                AnswerText = "128bpm"
            };
            Answer q8a3 = new Answer()
            {
                AnswerText = "150bpm"
            };
            Answer q9a1 = new Answer()
            {
                AnswerText = "Peter"
            };
            Answer q9a2 = new Answer()
            {
                AnswerText = "Wieland"
            };
            Answer q9a3 = new Answer()
            {
                AnswerText = "Randy"
            };
            Answer q10a1 = new Answer()
            {
                AnswerText = "60min"
            };
            Answer q10a2 = new Answer()
            {
                AnswerText = "30min"
            };
            Answer q10a3 = new Answer()
            {
                AnswerText = "90min"
            };


            List<Answer> answers = new List<Answer>();
            answers.Add(q1a1);
            answers.Add(q1a2);
            answers.Add(q1a3);
            answers.Add(q2a1);
            answers.Add(q2a2);
            answers.Add(q2a3);
            answers.Add(q3a1);
            answers.Add(q3a2);
            answers.Add(q3a3);
            answers.Add(q4a1);
            answers.Add(q4a2);
            answers.Add(q4a3);
            answers.Add(q5a1);
            answers.Add(q5a2);
            answers.Add(q5a3);
            answers.Add(q6a1);
            answers.Add(q6a2);
            answers.Add(q6a3);
            answers.Add(q7a1);
            answers.Add(q7a2);
            answers.Add(q7a3);
            answers.Add(q8a1);
            answers.Add(q8a2);
            answers.Add(q8a3);
            answers.Add(q9a1);
            answers.Add(q9a2);
            answers.Add(q9a3);
            answers.Add(q10a1);
            answers.Add(q10a2);
            answers.Add(q10a3);

            context.Answers.AddRange(answers);


            Question q1 = new Question()
            {
                QuestionText = "Welke Hardcore DJ was dit jaar de beste van de wereld?",
                Answer1 = q1a3,
                Answer2 =   q1a2,
                CorrectAnswer = q1a1
            };

            Question q2 = new Question()
            {
                QuestionText = "Wat was de DJ naam van het voormalige DJ duo, nu bekend als Brennan Heart & DJ Thera",
                Answer1 = q2a1,
                Answer2 = q2a2,
                CorrectAnswer = q2a3
            };

            Question q3 = new Question()
            {
                QuestionText = "Wat is de voornaam van Headhunterz?",
                Answer1 = q3a1,
                Answer2 = q3a3,
                CorrectAnswer = q3a2
            };

            Question q4 = new Question()
            {
                QuestionText = "Surprise Surprise its:",
                Answer1 = q4a1,
                Answer2 = q4a2,
                CorrectAnswer = q4a3
            };

            Question q5 = new Question()
            {
                QuestionText = "Wat is de belangrijkste taak van DJ Chain Reaction binnen de groep 'Minus Militia'?",
                Answer1 = q5a2,
                Answer2 = q5a3,
                CorrectAnswer = q5a1
            };

            Question q6 = new Question()
            {
                QuestionText = "Wie is de grote man achter Radical Redemption, MissK8 en eigenlijk het hele Minus is More Label?",
                Answer1 = q6a2,
                Answer2 = q6a3,
                CorrectAnswer = q6a1
            };

            Question q7 = new Question()
            {
                QuestionText = "Wat is de house Alias van het DJ-Duo D-Block & S-Te-Fan?",
                Answer1 = q7a1,
                Answer2 = q7a2,
                CorrectAnswer = q7a3
            };

            Question q8 = new Question()
            {
                QuestionText = "Op hoevel BPM (Beats Per Minute) wordt Hardstyle geproduceerd?",
                Answer1 = q8a1,
                Answer2 = q8a2,
                CorrectAnswer = q8a3
            };

            Question q9 = new Question()
            {
                QuestionText = "Wat is de echte naam van DJ Ran-D",
                Answer1 = q9a1,
                Answer2 = q9a2,
                CorrectAnswer = q9a3
            };

            Question q10 = new Question()
            {
                QuestionText = "Wat is de gemiddelde duur van een DJ-set",
                Answer1 = q10a1,
                Answer2 = q10a2,
                CorrectAnswer = q10a1
            };


            context.Questions.AddOrUpdate(q1);
            context.Questions.AddOrUpdate(q2);
            context.Questions.AddOrUpdate(q3);
            context.Questions.AddOrUpdate(q4);
            context.Questions.AddOrUpdate(q5);
            context.Questions.AddOrUpdate(q6);
            context.Questions.AddOrUpdate(q7);
            context.Questions.AddOrUpdate(q8);
            context.Questions.AddOrUpdate(q9);
            context.Questions.AddOrUpdate(q10);


            base.Seed(context);
        }
    }
}