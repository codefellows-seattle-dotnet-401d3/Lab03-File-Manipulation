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
            string words = "blue green red";//default wordlist is boring
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
            GameLoop();
        }

        /// <summary>
        /// Loops the user through the menu until they specify the quit option.
        /// Each time valid user input is detected, this will run the appropriate functions.
        /// Note: exceptions have distinctive messages so you can find where they are being thrown.
        /// </summary>
        static void GameLoop()
        {
            Boolean playing = true;
            Random rand = new Random();
            while (playing)
            {
                string[] wordList = WordList(MY_PATH);
                Console.Clear();
                Console.WriteLine("Would you like to play a game?");
                Console.WriteLine("1. Play with random word\n" +
                                  "2. Add a word to list\n" +
                                  "3. Remove a word from list\n" +
                                  "4. Display word list\n" +
                                  "5. quit.");
                byte option = 0;
                for (byte count = 0; count < 10 && option < 1; count++)
                {
                    try
                    {
                        option = byte.Parse(Console.ReadLine());
                        if (option < 1)
                        {
                            throw new Exception("Run git blame");
                        }
                        if (option > 5)
                        {
                            throw new Exception("invald input, number too large!");
                        }
                    }
                    catch
                    {
                        Console.WriteLine("invalid input");
                    }
                }
                switch (option) // making sure this works in c# like in other languages. It does.
                {
                    case 1://start guessing with a random word from the list
                        GuessingLoop(wordList[rand.Next(0, wordList.Length)]);
                        break;
                    case 2://Add word to list
                        AddWord(wordList);
                        break;
                    case 3://Remove word from list
                        RemoveWord(wordList);
                        break;
                    case 4://displays word list
                        Console.Clear();
                        foreach(string wrd in wordList)
                        {
                            Console.WriteLine(wrd);
                        }
                        Console.WriteLine("Press any key to continue");
                        Console.ReadKey();
                        break;
                    case 5://quit
                        playing = false;
                        break;
                    default: throw new Exception("this should never run");
                }
            }

        }

        /// <summary>
        /// Builds a word list array of strings based on the text in the file at path
        /// </summary>
        /// <param name="path">path to the file</param>
        /// <returns>string array of words in file</returns>
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

        public static void AddWord (string[] wl)
        {
            Console.Clear();
            Console.WriteLine("What word would you like to add?");
            string w = Console.ReadLine().ToLower();
            if (Array.Exists(wl, x => x == w))
            {
                Console.WriteLine("That word already exists in the list!\n" +
                    "Press any key to continue");
                Console.ReadKey();
            }
            else
            {
                Add(w, MY_PATH, wl);
            }
        }

        public static void Add (string word, string path, string[] wordList)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(word);
                    //must rewrite all existing words
                    foreach (string wd in wordList)
                    {
                        sw.WriteLine(wd);
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Gets user input to find and remove a word from the file.
        /// </summary>
        /// <param name="wordList">current word list</param>
        public static void RemoveWord(string[] wordList)
        {
            Console.WriteLine("What word would you like to remove?");
            string word = Console.ReadLine().ToLower();
            Remove(word, MY_PATH, wordList);
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        /// <summary>
        /// overwrites a file at location path with every word on word list except the matching word.
        /// seperated from RemoveWord to be testable.
        /// </summary>
        /// <param name="word">word to remove</param>
        /// <param name="path">target file</param>
        /// <param name="wordList">list of words in the file.</param>
        public static void Remove (string word, string path, string[] wordList)
        {
            if (-1 == Array.IndexOf(wordList, word))//word does not exist in array
            {
                Console.WriteLine("Could not find that word in the list. Try again?");
            }
            else
            {//word exists
                using (StreamWriter sw = new StreamWriter(path))
                {
                    foreach (string w in wordList)
                    {
                        if (w != word) //write everything that isn't the removed word
                        {
                            sw.WriteLine(w);
                        }
                    }
                }
                Console.WriteLine("success!");
            }
        }

        /// <summary>
        /// The actual game itself.
        /// </summary>
        /// <param name="w">The word the user is trying to guess</param>
        public static void GuessingLoop(string w)
        {
            Word wrd = new Word(w);
            while (-1 != Array.IndexOf(wrd.Current, "_"))// a least one letter has not been guessed
            {
                Console.Clear();
                string letter = "";
                wrd.Display();
                Console.WriteLine("What letter would you like to guess next?");
                try
                {
                    letter = Console.ReadLine().ToLower();
                    if (letter.Length > 1 || letter.Length == 0)
                    {
                        throw new Exception("invalid input");
                    }
                    wrd.NextDisplay(letter);
                }
                catch
                {
                    Console.WriteLine("Sorry, that input was not processed correctly.");
                }
            }
            Console.WriteLine($"Congratulations, you guessed the word {wrd.Text.ToUpper()}!");
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
