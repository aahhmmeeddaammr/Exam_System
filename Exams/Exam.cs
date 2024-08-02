using OOPExam.Questions;
using OOPExam.Subjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPExam.Exams
{
	internal abstract class Exam
	{
		protected int timeofexam;
		protected int numberofquestions;
		protected Question[] questions;
		protected Subject subject;
        protected string type;
        public string Type
        {
            get
            {
                return type;
            }
        }
        public string Subject{
			get
			{
				return subject.SubjectName;
			}
			}

		public  int NumberOfQustions
		{
		 	 get { return numberofquestions; }
			 set { numberofquestions = value; }
		}


		public  int TimeOfExam
		{
			get { return timeofexam; }
			set { timeofexam = value; }
		}

        public Exam(Subject _subject , int Time , int numberofq , Question[] _questions )
        {
			if (numberofq == 0 || _subject is null || Time == 0 || _questions is null)
			{
				throw new Exception("Invalid Exam");
			}
            subject = _subject;
			numberofquestions = numberofq;
            questions = _questions;
			TimeOfExam = Time ;
        }



        public abstract void Show();

        public override string ToString()
        {
            return $"{this.subject}";
        }
    }
}
