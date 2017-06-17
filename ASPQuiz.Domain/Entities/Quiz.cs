using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPQuiz.Domain.Entities
{
    public class Quiz
    {
        private List<QuizLine> lineCollection = new List<QuizLine>();

        public void AddItem(Question question, Answer answer)
        {
            QuizLine line = lineCollection
                .FirstOrDefault(q => q.Question.Id == question.Id);

            if (line == null)
            {
                lineCollection.Add(new QuizLine
                {
                    Question = question,
                    Answer = answer
                });
            }
        }

        public void RemoveLine(Question question)
        {
            lineCollection.RemoveAll(l => l.Question.Id == question.Id);
        }

        public void CalculateGrade()
        {
            //TODO: Calculate the Grade
        }

        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<QuizLine> Lines
        {
            get { return lineCollection; }
        }
    }

    public class QuizLine
    {
        public Question Question { get; set; }
        public Answer Answer { get; set; }
    }
}