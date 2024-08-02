using OOPExam.Questions;
using OOPExam.Subjects;
namespace OOPExam.Exams
{
    internal class FinalExam : Exam
    {
        private int StudentMark;
        
        public FinalExam(Subject _subject, int Time, int numberofq, Question[] _questions) :base( _subject , Time , numberofq , _questions ){
            type = "Final";
        }
        public override void Show()
        {
            if (questions is null) return;
            for (int i = 0; i < questions.Length; i++)
            {
                questions[i].ShowQuestion(i);
                if ( questions[i].ValidAnswer( GetAnsweFromUser() ) )
                {
                    StudentMark += questions[i].Mark;
                }
            }
            Console.WriteLine("End Of Exam");
            Console.WriteLine($"Your Mark is : {StudentMark}");
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
    }
}
