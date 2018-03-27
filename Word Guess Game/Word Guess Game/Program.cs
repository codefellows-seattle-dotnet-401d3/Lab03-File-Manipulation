using System;
using System.Text;
using System.IO;

namespace Word_Guess_Game
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Persist the main menu
            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu();
            }
        }

        
        //public static string[] words = new string[] { "each", "time", "new", "game", "session", "starts" };
        public static StringBuilder guesses = new StringBuilder(""); // The letters guessed by the user so far
        static int tries = 1000; // Set to a high number for testing (debugging) purposes
        public static bool continueGame = true;  // Set to true so that it runs the first time


        /// <summary>
        /// Main Menu, display and IO
        /// </summary>
        /// <returns>Returns false</returns>
        public static bool MainMenu()
        {
            
            string myPath = "..\\..\\..\\words.txt";

            string wordString = ReadFile(myPath); // Change to wordBuilder
            string[] words = ConvertString(wordString);
            string answer;
            // Menu for adding/deleting words goes here
            bool menu = true;
            while (menu)
            {
                Console.WriteLine("Word Guess Game:");
                Console.WriteLine("1. Play the game");
                Console.WriteLine("2. Add word to dictionary");
                Console.WriteLine("3. Remove word from dictionary");
                Console.WriteLine("4. See dictionary");
                Console.WriteLine("5. Quit");
                answer = Console.ReadLine();

                // Add options here
                if (answer == "5")
                    return false;
                if (answer == "4")
                {
                    PrintDictionary(words);
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
                if (answer == "2")
                {
                    Console.WriteLine("You pressed 2");
                }
                if (answer == "1")
                {
                    // continue control below
                    break;
                }
                
            }
            bool metaPlay = true;
            while (metaPlay)
            {
                tries = 1000; // repeated here for replay ability
                guesses = new StringBuilder(""); // repeated here for replay ability
                string word = SetInitial(words);

                Console.WriteLine("Word Guess Game");
                Console.WriteLine("Chose a letter");

                while (tries > 0)
                {
                    Display(word, guesses.ToString(), tries); // Display initial dashed word
                    while (continueGame)
                    {
                        Console.WriteLine($"You have {tries} tries left.");
                        continueGame = false; // Set to false to end if never set back to true
                        answer = Console.ReadLine();

                        guesses.Append(answer); // Adds the guessed letter to the end of the guesses WordBuilder string
                        Display(word, guesses.ToString(), tries);
                        tries--;
                    }
                    tries = 0; // Run out 'tries' to trip the end of the game
                }
                if (!continueGame)
                    Console.WriteLine("You've won the game!");
                else
                    Console.WriteLine("You've run out of tries");

                Console.WriteLine("Play again Y/N?");
                string response = Console.ReadLine();
                if (response == "Y" || response == "y")
                    metaPlay = true;
                else
                    metaPlay = false;
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
            for (int i = 0; i < word.Length; i++) // iterate through word to be guessed
            {
                string letter = "_"; // Set default letter as a dash in case of no match from word
                for (int j = 0; j < guesses.Length; j++) // iterate through letters guessed so far
                {
                    if (word[i] == guesses[j])
                    {
                        letter = (word[i].ToString()); // Match found between guesses and the word to be guessed, put that leter into a variable to be printed
                    }
                    //Console.WriteLine($" At end of j iteration: i: {i}, j:{j}, word:{word}, word[i]:{word[i]}, guesses:{guesses}, guesses[j]:{guesses[j]}, continueGame:{continueGame}");
                }
                Console.Write(letter); // Write either a found letter or a dash for the unfound parts
                if (letter == "_")
                {
                    continueGame = true; // if there is a dash anywhere in the word, the word must not be complete
                    //Console.WriteLine($" A dash, continueGame is set to true. word: {word}");
                }
                else
                {
                   // Console.WriteLine($" No dash, continueGame should still be false. continueGame:{continueGame}");
                }
            }

            Console.WriteLine(""); // cariage return
            Console.WriteLine($"Guesses so far: {guesses.ToString()}");

            return;
        }

        public static void CreateAFile(string path)
        {


            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write("This is a test");
                }
            }
            catch (Exception)
            {

                throw;
            }

            using (FileStream fs = File.Create(path))
            {
                //fs.Write(words, 0, words.Length); // Error: cannot convert from 'string[]' to 'byte[]'
            }

        }


        public static string ReadFile(string path)
        {
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    StringBuilder builtWord = new StringBuilder(""); // The dictionary file

                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        builtWord.Append(s);
                        //Console.WriteLine(s);
                    }
                    return builtWord.ToString(); // convert to a string
                }

            }
            catch (Exception e)
            {
                if (e.Source != null)
                    Console.WriteLine($"Exception {e}");
                throw;
            }
        }

        public static void UpdateFile(string path)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(".NET is cool!");
            }
        }

        public static void DeleteFile(string path)
        {
            File.Delete(path);
        }

        /// <summary>
        /// Converts a string of words seperated by spaces to an array
        /// </summary>
        /// <param name="wordString"></param>
        /// <returns>Array of strings</returns>
        public static string[] ConvertString(string wordString)
        {
            int counter = 0;
            for (int i = 0; i < wordString.Length; i++) // iterate through wordString to find the total number of words
            {
                // count the spaces
                if (wordString[i] == Convert.ToChar(" "))
                    counter ++;              
            }

            string[] word = new string[counter + 1]; // Set to total number of words.  There is one more word than spaces.
            StringBuilder progress = new StringBuilder(""); // word being built up
            counter = 0; // reset counter
            for (int i = 0; i < wordString.Length; i++) // iterate through words
            {
                if (wordString[i] == Convert.ToChar(" "))
                {
                    // there is a space
                    word[counter] = progress.ToString(); // add word to array
                    counter++; // Next array member
                    progress.Length = 0; // clear out progress
                }
                else // There is not a space.  build up word in progress
                    progress.Append(wordString[i]);
            }

            word[counter] = progress.ToString(); // enter in last word


            return word;
        }

        /// <summary>
        /// Prints the contents of the dictionary
        /// </summary>
        /// <param name="words">The array containing the word list</param>
        public static void PrintDictionary(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                Console.Write(words[i] + " ");
            }
            Console.WriteLine(""); // Carriage return
        }

    }
}
