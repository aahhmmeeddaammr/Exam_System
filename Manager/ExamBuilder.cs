using OOPExam.Exams;
using OOPExam.Questions;
using OOPExam.Questions.Answers;
using OOPExam.Subjects;
namespace OOPExam.Manager
{
    internal class ExamBuilder
    {
        private Question[] questions;
        private Answer[] Answers;
        private Answer CorrectAnswer;
        private string? subjectName ;
        private int subjectid = 0;

        public Exam createExam()
        {
            Console.WriteLine("===>>Create Exam<<===");
            do
            {
                Console.WriteLine("Enter Subject ID : ");
            } while (!int.TryParse(Console.ReadLine(), out subjectid));
            do
            {
                Console.WriteLine("Enter Subject Name : ");
                subjectName = Console.ReadLine();
            } while (subjectName == null);

            Subject newSubject = new Subject(subjectid, subjectName);
            return getDataOfExamFromUser();
        }

        private Exam getDataOfExamFromUser()
        {
            string? type;
            int time = 0;
            int NoOfQ = 0;

            do
            {
                Console.WriteLine("Enter Type Of Exam (Final , Practical) :");
                type = Console.ReadLine();
            } while (type == null || (type != "Final" && type != "Practical"));

            do
            {
                Console.WriteLine("Enter Time Of Exam :");
            } while (!int.TryParse(Console.ReadLine(), out time) || time < 0 );

            do
            {
                Console.WriteLine("Enter Number Of Questions Of Exam :");
            } while (!int.TryParse(Console.ReadLine(), out NoOfQ) || NoOfQ <0 );

            questions = new Question[NoOfQ];
            GetQuestionsFromUser(NoOfQ , type=="Final"?1:2);
            Subject newsubject = new Subject(subjectid, subjectName);
            Console.Clear();
            return newsubject.CreateExam(type , time , NoOfQ , questions);
        }

        private void GetQuestionsFromUser(int num , int _type)
        {
            string type = "";
            if (_type == 1) {
                type = "Final";
            }else if (_type == 2)
            {
                type = "Practical";
            }
            else
            {
                throw new Exception("Invalid Type");
            }
            if(type == "Final")
            {
                CreateFinalExam(num);
            }
            else if(type == "Practical")
            {
                CreatePracticalExam(num);
            }
        }
        private void CreatePracticalExam(int num )
        {
            string body = "";
            int mark;
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine($"Enter Data Of  Qestion {i + 1}:");


                do
                {
                    Console.WriteLine("Enter Body Of Question : ");
                    body = Console.ReadLine();
                } while (body == null); // body

                do
                {
                    Console.WriteLine("Enter Mark : ");
                } while (!int.TryParse(Console.ReadLine(), out mark)); // mark 
                Answers = new Answer[3];
                for (int j = 0; j < 3; j++)
                {
                    string? txt;

                    do
                    {
                        Console.WriteLine($"Enter Answer Text ID : {j}");
                        txt = Console.ReadLine();
                    } while (txt == null);
                    Answer newAns = new Answer(j, txt);
                    Answers[j] = newAns;
                }
                int id;
                do
                {
                    Console.WriteLine("Enter ID Of Correct Answer");
                } while (!int.TryParse(Console.ReadLine(), out id));
                CorrectAnswer = Answers[id];
                questions[i] = new MSQ(body, mark, Answers, CorrectAnswer);

            }
        }

        private void CreateFinalExam(int num)
        {
            string? body = "";
            int mark, header;
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine($"Enter Data Of {i + 1} Qestion:");
                do
                {
                    Console.WriteLine("Enter Header Of Question ( 1 for MSQ , 2 for TrueOrFalse ) : ");
                } while (!int.TryParse(Console.ReadLine(), out header) || (header != 1 && header != 2)); //header

                do
                {
                    Console.WriteLine("Enter Mark : ");
                } while (!int.TryParse(Console.ReadLine(), out mark) || mark < 0); // mark 

                do
                {
                    Console.WriteLine("Enter Body Of Question : ");
                    body = Console.ReadLine();
                } while (body == null); // body


                int numberOfAnswers = 0;
                if (header == 1)
                {
                    numberOfAnswers = 3;
                }
                else
                {
                    numberOfAnswers = 2;
                }


                if (header == 1)
                {

                    Answers = new Answer[numberOfAnswers];
                    for (int j = 0; j < numberOfAnswers; j++)
                    {
                        string? txt;

                        do
                        {
                            Console.WriteLine($"Enter Answer Text ID : {j}");
                            txt = Console.ReadLine();
                        } while (txt == null);
                        Answer newAns = new Answer(j, txt);
                        Answers[j] = newAns;
                    }
                    int id;
                    do
                    {
                        Console.WriteLine("Enter ID Of Correct Answer");
                    } while (!int.TryParse(Console.ReadLine(), out id));
                    CorrectAnswer = Answers[id];
                    questions[i] = new MSQ(body, mark, Answers, CorrectAnswer);

                }
                else if (header == 2)
                {
                    Answers = new Answer[2]
                    {
                        new Answer(0,"True"),
                        new Answer(1, "False")
                    };


                    int id;
                    do
                    {
                        Console.WriteLine("Enter Id Of Correct Answer (0 For True , 1 For False )");
                    } while (!int.TryParse(Console.ReadLine(), out id) || (id < 0 || id > 1));
                    CorrectAnswer = Answers[id];
                    questions[i] = new TrueOrFalseQuestion(body, mark, Answers, CorrectAnswer);

                }

            }
        }

    }
}
