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

            Question q1 = new Question()
            {
                QuestionText = "Is ASP Awesome",
            };

            context.Questions.AddOrUpdate(q1);


            base.Seed(context);
            
        }
    }
}
