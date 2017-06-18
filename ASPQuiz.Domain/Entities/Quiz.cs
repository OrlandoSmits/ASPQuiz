using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPQuiz.Domain.Entities
{
    public class Quiz
    {
        private List<QuizLine> lineCollection = new List<QuizLine>();
        
        private int Grade;

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

        public void RemoveItem(Question question)
        {
            lineCollection.RemoveAll(l => l.Question.Id == question.Id);
        }

        public int CalculateGrade()
        {
            Grade = 0;
            foreach (QuizLine line in lineCollection)
            {
                if (line.isAnswerCorrect())
                {
                    Grade += 5;
                }
            }

            return Grade;
        }

        public void Clear()
        {
            lineCollection.Clear();
            Grade = 0;
        }

        public IEnumerable<QuizLine> Lines
        {
            get { return lineCollection; }
        }
    }
}