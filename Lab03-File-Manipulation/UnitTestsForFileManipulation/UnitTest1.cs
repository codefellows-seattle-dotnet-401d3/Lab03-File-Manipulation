using System;
using Xunit;
using System.IO;
using Lab03_File_Manipulation;

namespace UnitTestsForFileManipulation
{
    public class UnitTest1
    {
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
            Assert.Equal(expect, Program.WordList(path));
        }

        [Fact]
        public void CanJudgeGuess()//(string expected, string current, string word, string guess)
        {
            string[] expected = { "_", "_", "e", "e", "_" };
            Word w = new Word("green");
            w.NextDisplay("e");
            Assert.Equal(expected, w.Current);
        }

        [Fact]
        public void CanAddWord()
        {
            //Arrange
            string words = "blue green\nred";
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
            //Checking Arrangement
            Assert.Equal(-1, (Array.IndexOf(Program.WordList(path), "blueberry")));
            //Act
            Program.Add("blueberry", path, Program.WordList(path));
            //Assert
            Assert.NotEqual(-1, (Array.IndexOf(Program.WordList(path), "blueberry")));
        }

        [Fact]
        public void CanAddWordWithoutDeleting()
        {
            string words = "blue green\nred";
            string path = "..\\..\\testcase.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.Write(words);
            }
            Program.Add("blueberry", path, Program.WordList(path));
            Assert.NotEqual(-1, (Array.IndexOf(Program.WordList(path), "green")));
        }

        [Fact]
        public void CanRemoveWord()
        {
            // Arrange
            string words = "blue green\nred";
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
            //First assert makes sure test arrangement was successful
            Assert.NotEqual(-1, (Array.IndexOf(Program.WordList(path), "blue")));

            //Act
            Program.Remove("blue", path, Program.WordList(path));

            //Assert word can be removed
            Assert.Equal(-1, (Array.IndexOf(Program.WordList(path), "blue")));
        }
    }
}
