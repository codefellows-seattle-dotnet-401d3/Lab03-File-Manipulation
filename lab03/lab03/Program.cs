using System;
using System.IO;

namespace lab03
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = "..\\..\\..\\source.txt";
            MenuLoop(filePath);
        }

        public static void MenuLoop(string path)
        {
            Console.WriteLine("Please select an option\na) Play Game!\nb) View source file\nc) Exit");
            try
            {
                //Init file data
                //If file dose not exist create it
                if (!(File.Exists(path)))
                {
                    using (StreamWriter sw = new StreamWriter(path))
                    {
                        sw.Write("thestral dirigible plums viktor krum hexed memory charm animagus invisibility cloak three headed dog half blood prince cauldron cakes");
                    }
                }
                //Init words array
                string[] words = GetWordList(path);
                //User response to intro
                string userPath = Console.ReadLine();
                //Gamepath
                if (userPath == "a")
                {
                    GameLoop(path);
                }
                //File menu path
                if (userPath == "b")
                {
                    FileMenu(path);
                }
                //Exit path
                if (userPath == "c")
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// The basic game loop
        /// </summary>
        /// <param name="path"></param>
        public static void GameLoop(string path)
        {
            string targetWord = GetRandWord(path);
            bool loop = true;
            Console.WriteLine("Let’s play!\nI’ve got a word ready for you.");
            Console.WriteLine("Enter a letter to guess\nor\nEnter 1 to return the the main menu\nEnter 2 to give up and get a new word");
            while(loop)
            {

            }

        }
        /// <summary>
        /// Runs the file menu
        /// </summary>
        /// <param name="path"></param>
        public static void FileMenu(string path)
        {
            Console.WriteLine("Please select an option\na) View source file\nb) Add a word\nc) Delete a word\nd) Delete the file\ne) Exit");
            string userPath = Console.ReadLine();
            try
            {
                //View file path
                if (userPath == "a")
                {
                    //Pull the current words list
                    string[] words = GetWordList(path);
                    //Print current word list to console
                    for (int i = 0; i < words.Length-1; i++)
                    {
                        Console.WriteLine(words[i]);
                        Console.WriteLine(); //Console formatting
                    }
                    Console.ReadLine();
                    FileMenu(path); // GO back to the file menu
                }
                //Add word path
                if (userPath == "b")
                {
                    Console.WriteLine("What word woul you like to add?");
                    string newValue = Console.ReadLine();
                    AddToFile(path, newValue);
                    Console.WriteLine("Update Complete");
                    Console.ReadLine();
                    FileMenu(path); //Go back to the file menu
                }
                //Remove word path
                if (userPath == "c")
                {
                    //Get current word list
                    string[] words = GetWordList(path);
                    Console.WriteLine("Please select the word to remove");
                    //Display the options
                    for (int i = 0; i < words.Length; i++)
                    {
                        Console.WriteLine($"{i}) {words[i]}");
                    }
                    int indexToDelete = int.Parse(Console.ReadLine());
                    words = RemoveWordFromArray(path, words, indexToDelete);
                    //Write the current words list to the file
                    UpdateFile(path, words);
                    Console.WriteLine("Update Complete");
                    Console.ReadLine();
                    FileMenu(path); //Go back to the file menu
                }
                //Delete the file path
                if (userPath == "d")
                {
                    Console.WriteLine("Delete the source file, restore defaults and return to the main menu?\ny / n");
                    string userDeleteConfirm = Console.ReadLine();
                    if (userDeleteConfirm == "y")
                    {
                        File.Delete(path);
                    }
                    MenuLoop(path); //Go back to the main menu
                }
                //Menu return path
                if (userPath == "e")
                {
                    MenuLoop(path); //Go back to the main menu
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter the number value of the word to delete");
                FileMenu(path);
            }
            catch (Exception)
            {
                Console.WriteLine("I'm not sure what happened there. Lets try again.");
                FileMenu(path);
            }
        }
        /// <summary>
        /// Adds a single line to the new file
        /// </summary>
        /// <param name="path"></param>
        /// <param name="newValue"></param>
        public static void AddToFile(string path, string newValue)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(newValue);
            }
        }
        /// <summary>
        /// Will pull in all the lines from a file and put them into a string[]
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string[] GetWordList(string path)
        {
            string[] rawWords = File.ReadAllLines(path);
            string[] words = rawWords[0].Split(" ");
            return words;
        }
        /// <summary>
        /// remove a given index from the words array
        /// </summary>
        /// <param name="path"></param>
        /// <param name="words"></param>
        /// <returns></returns>
        public static string[] RemoveWordFromArray(string path, string[] words, int targetIndex)
        {
            string[] newWords = new string[words.Length - 1];
            for (int i = 0; i < newWords.Length; i++)
            {
                if (i < targetIndex)
                {
                    newWords[i] = words[i];
                }
                else
                {
                    newWords[i] = words[i + 1];
                }
            }
            return newWords;
        }
        /// <summary>
        /// Overwrites the file with the current word list
        /// </summary>
        /// <param name="path"></param>
        /// <param name="words"></param>
        public static void UpdateFile(string path, string[] words)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    for (int i = 0; i < words.Length; i++)
                    {
                        sw.WriteLine(words[i]);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Pulls a random word from the word list
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetRandWord(string path)
        {
            string[] words = GetWordList(path);
            Random rand = new Random();
            int wordindex = rand.Next(0, words.Length);
            return words[wordindex];
        }
        /// <summary>
        /// Masks the string
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string MaskString(string target)
        {
            
        }
    }
}
