using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("My Grade Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(64.5);
            
            var stats = book.GetStatistics();
            
            Console.WriteLine($"Average is {stats.Average:N1}");
            Console.WriteLine($"Low grade is {stats.Low}");
            Console.WriteLine($"High grade is {stats.High}");
        }
    }
}