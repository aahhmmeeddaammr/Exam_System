using OOPExam.Questions.Answers;

namespace OOPExam.Questions
{
    internal abstract class Question 
    {
		private protected string header;
		private protected string body;
		private protected int mark;
		private protected Answer CorrectAnswer;
		private protected Answer[] Answers;
		public int Mark
		{
			get { return mark; }
			set { mark = value; }
		}
		public string Body
		{
			get { return body; }
			set { body = value; }
		}
		public string Header
		{
			get { return header; }
			set { header = value; }
		}
		public Answer[] AnswersOfQuestion
		{
			get { return Answers; }
		}
		public Answer CorrectAnswerOfQuestion
		{
			get { return CorrectAnswer; }
		}

		public Question(string _header , string _body ,int _mark, Answer[] _answers , Answer _CorrectAnswer)
		{
			if (_header == null ||
				_body == null ||
				_answers == null ||
                _mark ==0||
				_CorrectAnswer == null
				) throw new NullReferenceException();
			header = _header;
			body = _body;
			Answers = _answers;
			mark = _mark;
			CorrectAnswer = _CorrectAnswer;
		}
		public bool ValidAnswer(int text)
		{
			return CorrectAnswer?.AnswerId.Equals(text) ?? false;
		}
		public void ShowQuestion(int i)
		{
            Console.WriteLine($"\n{this.Header}     {this.Mark} Mark");
            Console.WriteLine($"{i + 1}.{this.Body}");
            for (int j = 0; j < this.AnswersOfQuestion.Length; j++)
            {
                Console.WriteLine($"\t{this.AnswersOfQuestion[j].AnswerId}. {this.AnswersOfQuestion[j].AnswerText}");
            }
        }
        //public object Clone()
        //{
        //    return new Question(this.header , this.body , this.mark ,this.Answers , this.CorrectAnswer);
        //}
        
    }
}
