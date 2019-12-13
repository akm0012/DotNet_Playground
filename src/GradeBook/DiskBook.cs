using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override void AddGrade(double grade)
        {
            using var writer = File.AppendText(Name + ".txt");
            writer.WriteLine(grade);
            GradeAdded?.Invoke(this, new EventArgs());
        }

        public override Statistics GetStatistics()
        {
            String line;
            List<Double> grades = new List<double>();
            
            using var reader = File.OpenText(Name + ".txt");
            while ((line = reader.ReadLine()) != null)
            {
                grades.Add(double.Parse(line));
            }
            
            return new Statistics(grades);
        }

        public override event GradeAddedDelegate GradeAdded;
    }
}