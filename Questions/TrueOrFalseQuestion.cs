using OOPExam.Questions.Answers;

namespace OOPExam.Questions
{
    internal class TrueOrFalseQuestion : Question
    {
        public TrueOrFalseQuestion( string _body , int mark, Answer[] _answers, Answer _CorrectAnswer) : base("True Or False", _body, mark, _answers, _CorrectAnswer)
        {

        }   
    }
}
