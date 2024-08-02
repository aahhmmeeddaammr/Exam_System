using OOPExam.Exams;

namespace OOPExam.Manager
{
    internal static class ExamsManager
    {
        private static readonly List<Exam> _exams;
        static ExamsManager()
        {
            _exams = new List<Exam>();
        }
        private static void displayMenuOfExams()
        {
            if (_exams.Count >= 1)
            {
                int i = 0;
                Console.WriteLine("Our Subjects: ");
                foreach (var item in _exams)
                {
                    Console.WriteLine($"{i++}.{item}   {item.Type}");
                }
                int id = 0;
                do
                {
                    Console.WriteLine("Choose Topic (Write The id Like 0): ");

                } while (!int.TryParse(Console.ReadLine(), out id) || (id < 0 || id >= _exams.Count));

                _exams[id].Show();
            }
            else
            {
                Console.WriteLine("NO EXAMS NOW");
            }
        }
        public static void RunApp()
        {
            Console.WriteLine("**************************Welcome!!**************************");
            while (true)
            {
                int Role = 0;
                do
                {
                    Console.WriteLine("\nChoose :");
                    Console.WriteLine("1-Student \n2-Teacher\n3-Exist");

                } while (!int.TryParse(Console.ReadLine(), out Role) || (Role != 1 && Role != 2 && Role != 3));
                if (Role == 1)
                {
                    displayMenuOfExams();
                }
                else if (Role == 2)
                {
                    ExamBuilder X = new ExamBuilder();
                    Exam newExam = X.createExam();
                    _exams.Add(newExam);
                }
                else
                {
                    Console.WriteLine("Thank You See You Next Time");
                    break;
                }
            }
        }
    }
}
