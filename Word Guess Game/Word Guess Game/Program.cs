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
        static string[] words = new string[] { "Each", "time", "new", "game", "session", "starts" };
        StringBuilder guesses = new StringBuilder(""); // The letters guessed by the user so far
        static int tries = 15;

        /// <summary>
        /// Main Menu, display and IO
        /// </summary>
        /// <returns>Returns nothing</returns>
        private static bool MainMenu()
        {
            string answer;

            string word = SetInitial(words);

            Console.WriteLine("Word Guess Game");
            Console.WriteLine("Chose a letter");

            while (tries > 0)
            {
                Display(word, guesses, tries);
                answer = Console.ReadLine();
                tries--;
            }
            
        }

        /// <summary>
        /// The initial random pick of a word from the provided list
        /// </summary>
        /// <param name="words[]">The array of words to be chosen from randomly</param>
        /// <returns>A random word from the list</returns>
        public string SetInitial(words[])
        {
            Random rnd = new Random();
            int word = rnd.Next(0, words.Length);
            return word;
        }

        /// <summary>
        /// Displays the progress on the word and guesses so far
        /// </summary>
        /// <param name="word">The word to be guessed by the user</param>
        /// <param name="guesses">The string of letters already guessed by the user</param>
        /// <returns>A console display of game progress</returns>
        public string Display(word, guesses, tries)
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
                        Console.Write(-);
                    }
                }
                Console.WriteLine("");
                Console.WriteLine($"You have {tries} left.");
            }
        }
        
    }
}
