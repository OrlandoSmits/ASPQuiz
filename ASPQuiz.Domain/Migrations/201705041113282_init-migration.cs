namespace ASPQuiz.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AnswerText = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        QuestionText = c.String(),
                        Answer1_Id = c.Int(),
                        Answer2_Id = c.Int(),
                        CorrectAnswer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Answers", t => t.Answer1_Id)
                .ForeignKey("dbo.Answers", t => t.Answer2_Id)
                .ForeignKey("dbo.Answers", t => t.CorrectAnswer_Id)
                .Index(t => t.Answer1_Id)
                .Index(t => t.Answer2_Id)
                .Index(t => t.CorrectAnswer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "CorrectAnswer_Id", "dbo.Answers");
            DropForeignKey("dbo.Questions", "Answer2_Id", "dbo.Answers");
            DropForeignKey("dbo.Questions", "Answer1_Id", "dbo.Answers");
            DropIndex("dbo.Questions", new[] { "CorrectAnswer_Id" });
            DropIndex("dbo.Questions", new[] { "Answer2_Id" });
            DropIndex("dbo.Questions", new[] { "Answer1_Id" });
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
        }
    }
}
