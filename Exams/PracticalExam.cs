using OOPExam.Questions;
using OOPExam.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam.Exams
{
    
    internal class PracticalExam :Exam
    {
        private string[] answers;
        public PracticalExam(Subject _subject, int Time, int numberofq, Question[] _questions) : base(_subject, Time, numberofq, _questions)
        {
            answers = new string[numberofq];
            type = "Practical";
        }
        public override void Show()
        {
            if (questions is null) return;
            for (int i = 0; i < questions.Length; i++)
            {
                questions[i].ShowQuestion(i);
                int UserAnswer = GetAnsweFromUser();
                if (questions[i].ValidAnswer(UserAnswer))
                {
                    answers[i] = ($"Question number {i} => Correct Answer!!");
                }
                else
                {
                    answers[i] = ($"Question number {i} => Wrong Answer!!");

                }
            }
            Console.WriteLine("End Of Exam");
            ShowUserAnswers();

        }

        private int GetAnsweFromUser()
        {
            int answer = 0;
            bool flag = int.TryParse(Console.ReadLine(), out answer);
            if (!flag)
            {
                while (!flag)
                {
                    flag = int.TryParse(Console.ReadLine(), out answer);
                }
            }
            return answer;
        }

        private void ShowUserAnswers()
        {
            if (answers is null) return;
            for(int i = 0;i < answers.Length; i++)
            {
                Console.WriteLine(answers[i]);
            }
        }

    }
}
