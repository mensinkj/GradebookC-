using System.Reflection;
using System;
using Xunit;

namespace Gradebook.Tests
{
    public class TypeTests

    {
        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42,x);


        }
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Josh";
            var upper = MakeUpperCase(name);

            Assert.Equal("JOSH",upper);
        }

        private string MakeUpperCase(string name)
        {
            return name.ToUpper();
        }

        private void SetInt(ref Int32 x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);

        }
        private void GetBookSetName(ref Book book, string name){
            book = new Book(name);
        }
        [Fact]
        public void CSharpIsPassByValue()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);

        }
        private void GetBookSetName(Book book, string name){
            book = new Book(name);
        }
        
        [Fact]
        public void CanSetNameFromReference()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);

        }
        private void SetName(Book book, string name){
            book.Name = name;
        }
        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1,book2);

        }
        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            // Arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1,book2);
            Assert.True(Object.ReferenceEquals(book1,book2));

        }
        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
