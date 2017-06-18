using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ASPQuiz.Controllers;
using ASPQuiz.Domain.Abstract;
using ASPQuiz.Domain.Concrete;
using ASPQuiz.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ASPQuiz.Tests.Tests
{
    [TestClass]
    public class SessionTest
    {
        [TestMethod]
        public void Add_Question_To_Quiz_Session()
        {

            // Arrange - Create answers
            Answer q1a1 = new Answer()
            {
                Id = 1,
                AnswerText = "Antwoord1"
            };
            Answer q1a2 = new Answer()
            {
                Id = 2,
                AnswerText = "Antwoord2"
            };
            Answer q1a3 = new Answer()
            {
                Id = 3,
                AnswerText = "Antwoord3"
            };

            // Arrange - Create Answerlist for use in moq
            var answers = new List<Answer>
            {
                q1a1,
                q1a2,
                q1a3,
            }.AsQueryable();
           

            // Arrange - Create Questionlist for use in moq
            var Questions = new List<Question>
            {
                new Question
                {
                    Id = 1,
                    QuestionText = "Vraag 1",
                    Answer1 =  q1a1,
                    Answer2 =  q1a2,
                    CorrectAnswer = q1a3
                   
                }
            }.AsQueryable();

            // Arange - Create The MockSet for the DbSet Question
            var mockSetQuestion = new Mock<DbSet<Question>>();
            mockSetQuestion.As<IQueryable<Question>>().Setup(m => m.Provider).Returns(Questions.Provider);
            mockSetQuestion.As<IQueryable<Question>>().Setup(m => m.Expression).Returns(Questions.Expression);
            mockSetQuestion.As<IQueryable<Question>>().Setup(m => m.ElementType).Returns(Questions.ElementType);
            mockSetQuestion.As<IQueryable<Question>>().Setup(m => m.GetEnumerator()).Returns(Questions.GetEnumerator);

            // Arange - Create The MockSet for the DbSet Answer
            var mockSetAnswer = new Mock<DbSet<Answer>>();
            mockSetAnswer.As<IQueryable<Answer>>().Setup(m => m.Provider).Returns(answers.Provider);
            mockSetAnswer.As<IQueryable<Answer>>().Setup(m => m.Expression).Returns(answers.Expression);
            mockSetAnswer.As<IQueryable<Answer>>().Setup(m => m.ElementType).Returns(answers.ElementType);
            mockSetAnswer.As<IQueryable<Answer>>().Setup(m => m.GetEnumerator()).Returns(answers.GetEnumerator);

            // Arrange - Setup the MockContext with the mockSets
            var mockContext = new Mock<EFDbContext>();
            mockContext.Setup(c => c.Questions).Returns(mockSetQuestion.Object);
            mockContext.Setup(c => c.Answers).Returns(mockSetAnswer.Object);
            
            // Arange - Create the QuizController with the mocked EFDbContext
            var target = new QuizController(mockContext.Object);
           
            // Arange - Create Quiz
            Quiz quiz = new Quiz();


            // Act - Add Question with ID 1 to the Quiz. Together with the Answer ID 3
            target.AddToQuiz(quiz, 1, 3, "/Quiz");

            // Assert - The Lines in the Quiz object has to have te length 1
            Assert.AreEqual(quiz.Lines.Count(), 1);

            // Assert - The Question at index 0 has to be the inserted question
            Assert.AreEqual(quiz.Lines.ToArray()[0].Question.Id, 1);

        }

        [TestMethod]
        public void Remove_Question_From_Quiz()
        {

            // Arrange - Create answers
            Answer q1a1 = new Answer()
            {
                Id = 1,
                AnswerText = "Antwoord1"
            };
            Answer q1a2 = new Answer()
            {
                Id = 2,
                AnswerText = "Antwoord2"
            };
            Answer q1a3 = new Answer()
            {
                Id = 3,
                AnswerText = "Antwoord3"
            };

            // Arrange - Create Answerlist for use in moq
            var answers = new List<Answer>
            {
                q1a1,
                q1a2,
                q1a3,
            }.AsQueryable();


            // Arrange - Create Questionlist for use in moq
            var Questions = new List<Question>
            {
                new Question
                {
                    Id = 1,
                    QuestionText = "Vraag 1",
                    Answer1 =  q1a1,
                    Answer2 =  q1a2,
                    CorrectAnswer = q1a3

                }
            }.AsQueryable();

            // Arange - Create The MockSet for the DbSet Question
            var mockSetQuestion = new Mock<DbSet<Question>>();
            mockSetQuestion.As<IQueryable<Question>>().Setup(m => m.Provider).Returns(Questions.Provider);
            mockSetQuestion.As<IQueryable<Question>>().Setup(m => m.Expression).Returns(Questions.Expression);
            mockSetQuestion.As<IQueryable<Question>>().Setup(m => m.ElementType).Returns(Questions.ElementType);
            mockSetQuestion.As<IQueryable<Question>>().Setup(m => m.GetEnumerator()).Returns(Questions.GetEnumerator);

            // Arange - Create The MockSet for the DbSet Answer
            var mockSetAnswer = new Mock<DbSet<Answer>>();
            mockSetAnswer.As<IQueryable<Answer>>().Setup(m => m.Provider).Returns(answers.Provider);
            mockSetAnswer.As<IQueryable<Answer>>().Setup(m => m.Expression).Returns(answers.Expression);
            mockSetAnswer.As<IQueryable<Answer>>().Setup(m => m.ElementType).Returns(answers.ElementType);
            mockSetAnswer.As<IQueryable<Answer>>().Setup(m => m.GetEnumerator()).Returns(answers.GetEnumerator);

            // Arrange - Setup the MockContext with the mockSets
            var mockContext = new Mock<EFDbContext>();
            mockContext.Setup(c => c.Questions).Returns(mockSetQuestion.Object);
            mockContext.Setup(c => c.Answers).Returns(mockSetAnswer.Object);

            // Arange - Create the QuizController with the mocked EFDbContext
            var target = new QuizController(mockContext.Object);

            // Arange - Create Quiz
            Quiz quiz = new Quiz();


            // Act - Add Question with ID 1 to the Quiz. Together with the Answer ID 3
            target.AddToQuiz(quiz, 1, 3, "/Quiz");

            // Assert - The Lines in the Quiz object has to have te length 1
            Assert.AreEqual(quiz.Lines.Count(), 1);

            // Assert - The Question at index 0 has to be the inserted question
            Assert.AreEqual(quiz.Lines.ToArray()[0].Question.Id, 1);

            target.RemoveFromQuiz(quiz, 1, "/Quiz");

            // Assert - The Lines in the Quiz object has to have te length 1
            Assert.AreEqual(quiz.Lines.Count(), 0);
        }
    }
}