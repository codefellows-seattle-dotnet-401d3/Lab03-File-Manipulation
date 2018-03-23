using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;

namespace Lab03_File_Manipulation
{
    public class Program
    {
        public static string MY_PATH = "..\\..\\..\\..\\words.txt";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string words = "blue green red";
            try
            {
                using (StreamWriter sw = new StreamWriter(MY_PATH))
                {
                    sw.Write(words);
                }
            }
            catch
            {
                throw;
            }
            string[] current = { "_", "_", "_", "_", "_" };
            string word = "green";
            string guess = "e";
            NextDisplay(current, word, guess);
        }

        public static bool MatchExists(string match, string source)
        {
            Regex rx = new Regex(match);
            return rx.IsMatch(source);
        }

        public static string[] WordList(string path)
        {
            string text = "";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    text = sr.ReadToEnd();
                }
            }
            catch
            {
                throw;
            }
            Regex whiteSpace = new Regex("\\s+");
            return whiteSpace.Replace(text, ",").Split(',');
        }

        public static string[] NextDisplay (string[] current, string word, string guess)
        {
            int ind = word.IndexOf(guess);
            while (0 <= ind && ind < current.Length)
            {
                current[ind] = word.Substring(ind, 1);
                ind = word.IndexOf(guess, ind + 1);
            }
            return current;
        }

        public static void AddWord (string word, string path)
        {
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(word);
                }
            }
            catch
            {
                throw;
            }
        }
    }

    
}
