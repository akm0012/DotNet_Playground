using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    public class Book
    {
        private string name;
        private List<double> grades;

        public Book(string name)
        {
            this.name = name;
            grades = new List<double>();
        }

        public void AddGrade(double grade)
        {
            grades.Add(grade);            
        }
        
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = grades.Average();
            result.High = grades.Max();
            result.Low = grades.Min();
            
            return result;
        }
    }
}