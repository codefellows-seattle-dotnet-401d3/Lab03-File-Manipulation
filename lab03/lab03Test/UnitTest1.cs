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
    }
}
