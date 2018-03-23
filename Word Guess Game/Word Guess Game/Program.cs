using System;
using System.Text;

namespace Word_Guess_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            // Persist the main menu
            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu();
            }
        }
        public static string[] words = new string[] { "each", "time", "new", "game", "session", "starts" };
        public static StringBuilder guesses = new StringBuilder(""); // The letters guessed by the user so far
        static int tries = 1000; // Set to a high number for testing (debugging) purposes

        /// <summary>
        /// Main Menu, display and IO
        /// </summary>
        /// <returns>Returns false</returns>
        public static bool MainMenu()
        {
            string answer;

            string word = SetInitial(words);

            Console.WriteLine("Word Guess Game");
            Console.WriteLine("Chose a letter");

            while (tries > 0)
            {
                Display(word, guesses.ToString(), tries);
                answer = Console.ReadLine();
                guesses.Append(answer); // Adds the guessed letter to the end of the guesses WordBuilder string
                tries--;
            }
            return false;
        }

        /// <summary>
        /// The initial random pick of a word from the provided list
        /// </summary>
        /// <param name="words[]">The array of words to be chosen from randomly</param>
        /// <returns>A string of a random word from the list</returns>
        public static string SetInitial(string[] words)
        {
            Random rnd = new Random();
            int wordPos = rnd.Next(0, words.Length);
            return words[wordPos];
        }

        /// <summary>
        /// Displays the progress on the word and guesses so far
        /// </summary>
        /// <param name="word">The word to be guessed by the user</param>
        /// <param name="guesses">The string of letters already guessed by the user</param>
        /// <returns>A console display of game progress</returns>
        public static void Display(string word, string guesses, int tries)
        {
            for (int i = 0; i < word.Length; i++)
            {
                for (int j = 0; j < guesses.Length; j++)
                {
                    if (word[i] == guesses[j])
                    {
                        Console.Write(words[i]);
                    }
                    else
                    {
                        Console.Write("-");
                    }
                }

            }
            Console.WriteLine("");
            Console.WriteLine($"Guesses so far: {guesses.ToString()}");
            Console.WriteLine($"You have {tries} left.");
            return;
        }
        
    }
}
