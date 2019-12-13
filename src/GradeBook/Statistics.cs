using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    public class Statistics
    {
        public double Average;
        public double High;
        public double Low;
        public char LetterGrade;

        public Statistics(List<Double> grades)
        {
            Average = grades.Average(); 
            High = grades.Max();
            Low = grades.Min();

            // Old Way
            switch (Average)
            {
                case var d when d >= 90.0:
                    LetterGrade = 'A';
                    break;

                case var d when d >= 80.0:
                    LetterGrade = 'B';
                    break;

                case var d when d >= 70.0:
                    LetterGrade = 'C';
                    break;

                case var d when d >= 60.0:
                    LetterGrade = 'D';
                    break;

                default:
                    LetterGrade = 'F';
                    break;
            }

            // New Way
            LetterGrade = Average switch
            {
                var grade when grade >= 90.0 => 'A',
                var grade when grade >= 80.0 => 'B',
                var grade when grade >= 70.0 => 'C',
                var grade when grade >= 60.0 => 'D',
                _ => 'F'
            };
        }
    }
}