using System;
using Xunit;
using Word_Guessing;
using static Word_Guessing.Program;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        /*          NON-WORKING THEORY
        [Theory]
        [InlineData("blue")]

        public void CanReturnNum(string words)
        {
            Random rnd = new Random();
            Assert.Equal("blue", SetInitial(wordsd));
        }*/

        /*          NON-WORKING THEORY
        [Theory]
        //method to check pass new array of words into SetInitial method
        [InlineData(myarray)]

        public void Check(Array myArray[])
        {
            string[] newArray = new string[];
            Assert.Equal("blue", Program.SetInitial(newArray));
        }*/



        [Fact]
        public void Test1()
        {
            string [] newarray = new string[] { "josh" };
            Assert.Equal("josh", SetInitial(newarray));
        }



        [Fact]
        public void Test2()
        {
            string[] anotherArray = new string[] { "this" };
            Assert.Equal("this", SetInitial(anotherArray));
        }

        [Fact]
        public void Test3()
        {
            string[] thirdArray = new string[] { "yelp" };
            Assert.Equal("yelp", SetInitial(thirdArray));
        }

        [Fact]
        public void Test4()
        {
            string[] arrayOne = new string[] { "jess" };
            Assert.Equal("jess", SetInitial(arrayOne));
        }

        [Fact]
        public void Test5()
        {
            string[] six = new string[] { "two"};
            Assert.Equal("two", SetInitial(six));
        }

    }
}
