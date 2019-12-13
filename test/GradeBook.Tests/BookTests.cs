using System;
using System.Security.Cryptography;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // Arrange
            var book = new InMemoryBook("My Test Book");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);
            
            // Act
            var result = book.GetStatistics();
            
            // Assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
            Assert.Equal('B', result.LetterGrade);
        }
        
        [Fact]
        public void BookCalculatesAnAverageGradeWithLetters()
        {
            // Arrange
            var book = new InMemoryBook("My Test Book");
            book.AddGrade('A');
            book.AddGrade('B');
            
            // Act
            var result = book.GetStatistics();
            
            // Assert
            Assert.Equal(85.0, result.Average, 1);
            Assert.Equal(90.0, result.High, 1);
            Assert.Equal(80.0, result.Low, 1);
            Assert.Equal('B', result.LetterGrade);
        }

        [Fact]
        public void BookGradeCanNotBeInvalid()
        {
            // Arrange
            var book = new InMemoryBook("Test Book");
            
            // Act / Assert
            var exception =  Assert.Throws<ArgumentException>(() => book.AddGrade(105));
            Assert.Equal("Invalid grade Value: 105", exception.Message);
            Assert.DoesNotContain(105, book.Grades);
        }
    }
}
