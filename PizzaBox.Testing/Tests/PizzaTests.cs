using PizzaBox.Domain.Models;
using Xunit;

namespace PizzaBox.Testing.Tests
{

    public class PizzaTests
    {

        [Fact]
        public void Test1()
        {

            // arrange
            var s = new AStore();
            s.StoreId = 1;
            s.StoreLocation = "hi";

            // act
            var a = s.StoreId;
            var d = s.StoreLocation;

            // assert
            Assert.True(a == 1);
            Assert.True(d.Equals("hi"));

        }

        [Fact]
        public void Test2()
        {

            // arrange
            var s = new AStore();
            s.StoreId = 1;
            s.StoreLocation = "hi";

            // act
            var a = s.StoreId;
            var d = s.StoreLocation;

            // assert
            Assert.True(a == 1);
            Assert.True(d.Equals("hi"));

        }

        [Fact]
        public void Test3()
        {

            // arrange
            var s = new AStore();
            s.StoreId = 1;
            s.StoreLocation = "hi";

            // act
            var a = s.StoreId;
            var d = s.StoreLocation;

            // assert
            Assert.True(a == 1);
            Assert.True(d.Equals("hi"));

        }

        [Fact]
        public void Test4()
        {

            // arrange
            var s = new AStore();
            s.StoreId = 1;
            s.StoreLocation = "hi";

            // act
            var a = s.StoreId;
            var d = s.StoreLocation;

            // assert
            Assert.True(a == 1);
            Assert.True(d.Equals("hi"));

        }

        [Fact]
        public void Test5()
        {

            // arrange
            var s = new AStore();
            s.StoreId = 1;
            s.StoreLocation = "hi";

            // act
            var a = s.StoreId;
            var d = s.StoreLocation;

            // assert
            Assert.True(a == 1);
            Assert.True(d.Equals("hi"));

        }

        [Fact]
        public void Test7()
        {

            // arrange
            var s = new AStore();
            s.StoreId = 1;
            s.StoreLocation = "hi";

            // act
            var a = s.StoreId;
            var d = s.StoreLocation;

            // assert
            Assert.True(a == 1);
            Assert.True(d.Equals("hi"));

        }
    }
}
