using System;
using Xunit;
using lab03;
using static lab03.Program;

namespace lab03Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("..\\..\\..\\source.txt", new string[] {"thestral", "dirigible", "plums", "viktor", "krum", "hexed", "memory", "charm", "animagus", "invisibility", "cloak", "three", "headed", "dog", "half", "blood", "prince", "cauldron", "cakes"})]
        public void CanPullWords(string path, string[] expected)
        {
            Assert.Equal(expected, GetWordList(path));
        }

        [Theory]
        [InlineData("gust", new string[] { "g", "b"}, "g***")]
        [InlineData("gust", new string[] { "g", "b", "u"}, "gu**")]
        [InlineData("gust", new string[] { "g", "b", "u", "s"}, "gus*")]
        [InlineData("gust", new string[] { "g", "b", "u", "s", "t"}, "gust")]

        public void CanMask(string target, string[] guesses, string expected)
        {
            Assert.Equal(expected, MaskString(target, guesses));
        }

        [Theory]
        [InlineData("u", new string[] { "g", "b" }, new string[] { "g", "b", "u" })]
        [InlineData("s", new string[] { "g", "b", "u" }, new string[] { "g", "b", "u", "s" })]
        [InlineData("t", new string[] { "g", "b", "u", "s" }, new string[] { "g", "b", "u", "s", "t" })]

        public void CanBuildGUessArray(string newValue, string[] guessArray, string[] expected)
        {
            Assert.Equal(expected, GuessArrayBuilder(guessArray, newValue));
        }

        [Theory]
        [InlineData(new string[] { "g", "b" }, "g b ")]
        [InlineData(new string[] { "g", "b", "u" }, "g b u ")]

        public void CanStringGUessArray(string[] guessArray, string expected)
        {
            Assert.Equal(expected, StringGuessArray(guessArray));
        }
    }
}
