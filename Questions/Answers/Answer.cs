namespace OOPExam.Questions.Answers
{
    internal class Answer
    {
        public int AnswerId { get; set; }
        public String AnswerText { get; set; }

        public Answer(int id , string text)
        {
            AnswerId = id;
            AnswerText = text;
        }
    }
}
