using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NamedObject
    {
        public NamedObject(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }
    
    public abstract class Book : NamedObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract void AddGrade(double grade);
        
        // Virtual means a child class may use their own implementation 
        public abstract Statistics GetStatistics();

        public abstract event GradeAddedDelegate GradeAdded;
    }

    public class InMemoryBook : Book
    {
        public override event GradeAddedDelegate GradeAdded;

        // Fields with custom getter / setter logic must be backed by private member
        public string customField
        {
            get => "Logic Here";
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    _customField = value;
                }
            }
        }

        private string _customField;

        public const string CATEGORY = "Science";

        public readonly List<double> Grades;

        public InMemoryBook(string name) : base(name)
        {
            Name = name;
            Grades = new List<double>();
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;

                case 'B':
                    AddGrade(80);
                    break;

                case 'C':
                    AddGrade(70);
                    break;

                case 'D':
                    AddGrade(60);
                    break;

                case 'F':
                    AddGrade(50);
                    break;

                default:
                    AddGrade(0);
                    break;
            }
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                Grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)} Value: {grade}");
            }
        }

        public override Statistics GetStatistics()
        {
            return new Statistics(Grades);
        }
    }
}