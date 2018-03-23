using System;
using Xunit;
using System.IO;
using static Lab03_File_Manipulation.Program;

namespace UnitTestsForFileManipulation
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(true, "a", "cat")]
        [InlineData(false, "b", "cat")]
        public void CanMatch(bool expected, string match, string compare)
        {
            Assert.Equal(expected, MatchExists(match, compare));
        }

        [Fact]
        public void CanGetWordList()
        {
            string words = "blue green\nred";
            string[] expect = { "blue", "green", "red" };
            string path = "..\\..\\testcase.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write(words);
                }
            }
            catch
            {
                throw;
            }
            Assert.Equal(expect, WordList(path));
        }

        [Fact]
        //[InlineData("_ _ _ _ n ", {"_", "_", "_", "_", "_"}, "green", "n")]
        public void CanJudgeGuess()//(string expected, string current, string word, string guess)
        {
            string[] expected = { "_", "_", "e", "e", "_" };
            string[] current = { "_", "_", "_", "_", "_" };
            string word = "green";
            string guess = "e";
            Assert.Equal(expected, NextDisplay(current, word, guess));
        }
        

    }
}
