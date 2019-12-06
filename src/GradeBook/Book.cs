using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    public class Book
    {
        public string Name;
        public readonly List<double> Grades;

        public Book(string name)
        {
            Name = name;
            Grades = new List<double>();
        }

        public void AddLetterGrade(char letter)
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

        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                Grades.Add(grade);
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)} Value: {grade}");
            }
        }

        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = Grades.Average();
            result.High = Grades.Max();
            result.Low = Grades.Min();

            // Old Way
            switch (result.Average)
            {
                case var d when d >= 90.0:
                    result.LetterGrade = 'A';
                    break;

                case var d when d >= 80.0:
                    result.LetterGrade = 'B';
                    break;

                case var d when d >= 70.0:
                    result.LetterGrade = 'C';
                    break;

                case var d when d >= 60.0:
                    result.LetterGrade = 'D';
                    break;

                default:
                    result.LetterGrade = 'F';
                    break;
            }
            
            // New Way
            result.LetterGrade = result.Average switch
            {
                var grade when grade >= 90.0 => 'A',
                var grade when grade >= 80.0 => 'B',
                var grade when grade >= 70.0 => 'C',
                var grade when grade >= 60.0 => 'D',
                _ => 'F'
            };

            return result;
        }
    }
}