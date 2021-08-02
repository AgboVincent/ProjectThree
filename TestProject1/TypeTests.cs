using ProjectThree;
using System;
using Xunit;

namespace TestProject1
{
    public delegate string WriteLogDelegate(string logMessage);
       
    public class TypeTests
    {

        int count = 0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            WriteLogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;


            var result = log("Hello!");
            Assert.Equal(3, count);
        }
        string IncrementCount(string message)
        {
            count++;
            return message;
        }
        string ReturnMessage(string message)
        {
            count++;
            return message.ToLower();
        }
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            String name = "Vin";
            var upper = MakeUppercase(name);

            Assert.Equal("Vin", name);
            Assert.Equal("VIN", upper);
        }

        private string MakeUppercase(string parameter)
        {
           return parameter.ToUpper();
        }

        [Fact]
        public void ValueTyoesAlsoPassByValue()
        {
          var x = (int) GetInt();
            SetInt( ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private object GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            //arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            //act 
             
            //assert 
            Assert.Equal("New Name", book1.Name);
        }
        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }

        [Fact]
        public void CSharpISPassByValue() 
        {
            //arrange
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            //act 

            //assert 
            Assert.Equal("Book 1", book1.Name);
        }
        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }
         
        [Fact]
        public void CanSetNameFromReference()
        {
            //arrange
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            //act 

            //assert 
            Assert.Equal("New Name", book1.Name);
            

        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        { 
            //arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            //act
           
            //assert 
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);

        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            //arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;

            //act

            //assert 
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 1", book2.Name);

        }


        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}
