using System;
using Xunit;
using Word_Guess_Game;
using static Word_Guess_Game.Program;

namespace WordGameTest
{
    public class UnitTest1
    {
        [Fact]
        public void GuessCheck1()
        { 
            // SetInitial is the only non-void, non-bolean method.  It randomly returns a word from and array.  For a three word array, you would have a one in three chance of a passing test.  One word arrays greatly increases your odds.

            string[] newArray = new string[] { "red" };
            Assert.Equal("red", Program.SetInitial(newArray));
        }

        [Fact]
        public void GuessCheck2()
        {
            string[] newArray = new string[] { "blue" };
            Assert.Equal("blue", Program.SetInitial(newArray));

        }

        [Fact]
        public void GuessCheck3()
        {
            string[] newArray = new string[] { "green" };
            Assert.Equal("green", Program.SetInitial(newArray));

        }
    }

}
