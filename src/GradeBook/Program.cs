using System;
using System.Collections.Generic;
using System.Linq;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            IBook book = new DiskBook("My Grade Book");
            book.GradeAdded += OnGradeAdded;            
            book.GradeAdded += OnGradeAdded;    
            
            // You can remove delegates  
            book.GradeAdded -= OnGradeAdded;            
            book.GradeAdded += OnGradeAdded;            
            
            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"Average is {stats.Average:N1}");
            Console.WriteLine($"Low grade is {stats.Low}");
            Console.WriteLine($"High grade is {stats.High}");
            Console.WriteLine($"Letter Grade is {stats.LetterGrade}");
        }

        private static void EnterGrades(IBook book)
        {
            // Get Input
            do
            {
                Console.WriteLine("Please enter a grade (q to quit): ");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Invalid input. Try Again. {e.Message}");
                }
            } while (true);
        }

        static void OnGradeAdded(object sender, EventArgs eventArgs)
        {
            Console.WriteLine("A grade was added!");
        }
    }
}