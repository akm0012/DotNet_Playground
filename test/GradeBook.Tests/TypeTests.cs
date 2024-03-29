using System;
using System.Security.Cryptography;
using Xunit;

namespace GradeBook.Tests
{

    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            // 1st log
            WriteLogDelegate log = ReturnMessage;

            // Long way
            log = new WriteLogDelegate(ReturnMessage);
            
            // Short way
            // 2nd log
            log += ReturnMessage;
            
            // 3rd log
            log += ReturnMessageWithBang;
            
            var result = log("This is a log");
            Assert.Equal("This is a log!", result);
        }

        string ReturnMessage(string message)
        {
            Console.WriteLine("Return Message: " + message);
            return message;
        }
        
        string ReturnMessageWithBang(string message)
        {
            Console.WriteLine("Return Message With Bang: " + message + "!");

            return message + "!";
        }
        
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Andrew";
            var upper = MakeUpperCase(name);
            
            Assert.Equal("ANDREW", upper);
            Assert.Equal("Andrew", name);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypeAlsoPassByRef()
        {
            var x = GetInt();
            SetIntRef(ref x);
            
            Assert.Equal(42, x);
        }

        private void SetIntRef(ref int x)
        {
            x = 42;
        }
        
        [Fact]
        public void ValueTypeAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(x);
            
            Assert.Equal(3, x);
        }

        private void SetInt(int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }
        
        [Fact]
        public void CSharpCanPassByReference()
        {
            var book1 = GetBook("Book 1");
            GetBookSetNameRef(ref book1, "New Name");
            
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetNameRef(ref InMemoryBook inMemoryBook, string newName)
        {
            inMemoryBook = new InMemoryBook(newName);
            inMemoryBook.Name = newName;
        }
        
        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");
            
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook inMemoryBook, string newName)
        {
            inMemoryBook = new InMemoryBook(newName);
            inMemoryBook.Name = newName;
        }
        
        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");
            
            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(InMemoryBook inMemoryBook, string newName)
        {
            inMemoryBook.Name = newName;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");
            
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }
        
        [Fact]
        public void TwoVariableCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;
         
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
