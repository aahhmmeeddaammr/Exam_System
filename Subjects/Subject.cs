using OOPExam.Exams;
using OOPExam.Questions;

namespace OOPExam.Subjects
{
	internal class Subject
	{
		private int ID;
	
		private String subjectname;

		public String SubjectName
		{
			get { return subjectname; }
			set { subjectname = value; }
		}

		public int SubjectID
		{
			get 
			{ 
				return ID; 
			}
			set 
			{ 
				ID = value; 
			}
		}
        public Subject( int id , string name)
        {
			ID = id;
            subjectname = name;
        }
		public Exam CreateExam(String Type, int Time, int numberofq, Question[] _questions)
		{
			Exam result = default;
			if (Time <= 0 || _questions is null || numberofq <= 0)
			{
				throw new NullReferenceException();
			}
			if (Type == "Final")
			{
				result = new FinalExam(this, Time, numberofq, _questions);
			}
			if (Type == "Practical")
			{
				result = new PracticalExam(this, Time, numberofq, _questions);
			}
			if (result is not null)
			{
				return result;
			}
			throw new NullReferenceException();
		}
        public Exam CreateExam( String Type,int Time, int numberofq, Question[] _questions , Action create)
		{
			Exam result = default;
            if (Time <= 0 || _questions is  null  ||  numberofq <= 0)
			{
				throw new NullReferenceException();
			}
			if(Type == "Final")
			{
				 result= new FinalExam(this , Time , numberofq , _questions);
			}
			if (Type == "practical")
			{
                result = new PracticalExam(this, Time, numberofq, (MSQ[])_questions);
			}
			if(result is not null)
			{
				return result;
			}
			throw new NullReferenceException();
		}
        public override string ToString()
        {
            return $"{this.subjectname}";
        }

    }
}
