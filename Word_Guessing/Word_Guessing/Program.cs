using System;
using System.Text;
using System.IO;

namespace Word_Guessing
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // SETS THE MAIN METHOD OF MAIN MENU TO A LOOP UNTIL USER SELECTS 5 TO QUIT
            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = MainMenu();
            }

        }

        // SEPARATES  GUESSES INTO SPACES AND SETS THE NUMBER OF TIRES TO 10
        public static StringBuilder guesses = new StringBuilder(""); 
        static int tries = 10; 
        public static bool continueGame = true;  


        // CONSOLE FOR MAIN MENU
        public static bool MainMenu()
        {

            string myPath = "..\\..\\..\\words.txt";

            string wordString = ReadFile(myPath);
            string[] words = ConvertString(wordString);
            string answer;

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
                if (answer == null)
                {
                    try
                    {

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                if (answer == "5")
                    return false;

                //DELETE
                if (answer == "3")
                {
                    Console.WriteLine("Enter word to delete");
                    string word = Console.ReadLine();
                    words = DeleteWord(words, word);
                    RebuildFile(words, myPath);
                }
                //SHOWS DICTIONARY LIST
                if (answer == "4")
                {
                    PrintDictionary(words);
                    Console.WriteLine("Press enter to continue");
                    Console.ReadLine();
                }
                // CALLS METHOD FOR UPDATING A WORD
                if (answer == "2")
                {
                    Console.WriteLine("Enter new word");
                    string newWord = Console.ReadLine();
                    UpdateFile(myPath, newWord);
                    wordString = ReadFile(myPath);

                    words = ConvertString(wordString); 

                }
                if (answer == "1")
                {
                    
                    break;
                }

            }
            // COUNTER FOR 10 TRIES COUNTING DOWN TO 0 FOR PLAYER ATTEMPT
            bool metaPlay = true;
            while (metaPlay)
            {
                tries = 10;
                guesses = new StringBuilder(""); 
                string word = SetInitial(words);

                Console.WriteLine("Word Guess Game");
                Console.WriteLine("Chose a letter");

                while (tries > 0)
                {
                    Display(word, guesses.ToString(), tries); 
                    while (continueGame)
                    {
                        Console.WriteLine($"You have {tries} tries left.");
                        continueGame = false; 
                        answer = Console.ReadLine(); 
                        
                        answer = answer.ToLower(); 
                        if (answer.Length > 0) 
                            answer = answer[0].ToString();
                        guesses.Append(answer); 
                        Display(word, guesses.ToString(), tries);
                        tries--;
                        if (tries <= 0) 
                            break;
                    }
                    tries = 0; 
                }
                // CONTIUNE GAME , WIN GAME 
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

       
       // RANDOM FUNCTION TO DISPLAY WORDS INSIDE OF WORD LENGTH
        public static string SetInitial(string[] words)
        {
            Random rnd = new Random();
            int wordPos = rnd.Next(0, words.Length);
            return words[wordPos];

        }

       //METHOD TO DISPLAY NUMBER OF GUESSES AND DISPLAY CORRECT WORD IF SELECTED
        public static void Display(string word, string guesses, int tries)
        {
            for (int i = 0; i < word.Length; i++) 
            {
                string letter = "_"; 
                for (int j = 0; j < guesses.Length; j++) 
                {
                    if (word[i] == guesses[j])
                    {
                        letter = (word[i].ToString());
                    }
                 
                }
                Console.Write(letter);
                if (letter == "_")
                {
                    continueGame = true;
                    
                }
                else
                {
                   
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Guesses so far: {guesses.ToString()}");

            return;
        }

       //METHOD TO READ A FILE USING STREAM BUILDER
        public static string ReadFile(string path)
        {
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    StringBuilder builtWord = new StringBuilder(""); 

                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        builtWord.Append(s);
                      
                    }
                    return builtWord.ToString(); 
                }

            }
            catch (Exception e)
            {
                if (e.Source != null)
                    Console.WriteLine($"Exception {e}");
                throw;
            }
        }

      // METHOD TO ADD A FILE USING STREAM BUILDER
        public static void UpdateFile(string path, string newWord)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(" " + newWord);
            }
        }

      
        // METHOD TO READ THE FILE AFTER DELETE METHOD WAS ADDED
        public static void RebuildFile(string[] words, string path)
        {
            File.Delete(path);

            using (StreamWriter sw = new StreamWriter(path))
            {
                for (int i = 0; i < (words.Length - 1); i++)
                {
                    sw.Write(words[i] + " ");
                }
                sw.Write(words[words.Length - 1]); 
            }
        }

    //CONVERTING WORDS INTO AN ARRAY
        public static string[] ConvertString(string wordString)
        {
            int counter = 0;
            for (int i = 0; i < wordString.Length; i++)
            {
                
                if (wordString[i] == Convert.ToChar(" "))
                    counter++; 
            }

            string[] word = new string[counter + 1];
            StringBuilder progress = new StringBuilder("");
            counter = 0;
            for (int i = 0; i < wordString.Length; i++)
            {
                if (wordString[i] == Convert.ToChar(" "))
                {
                    word[counter] = progress.ToString();
                    counter++;
                    progress.Length = 0; 
                }
                else
                    progress.Append(wordString[i]);
            }

            word[counter] = progress.ToString();


            return word;
        }

      // LOOKING INTO AN ARRAY AND FINDING THAT WORD TO DELETE
        public static string[] DeleteWord(string[] words, string word)
        {
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == word)
                {
                    for (int j = i; j < (words.Length - 1); j++)
                    {
                        words[j] = words[j + 1];
                    }
                    int index = i;
                    break;
                }
            }

            words = CompressArray(words, words.Length);
            return words;
        }


      //METHOD TO TAKE NEW WORD AND ADD IT TO OLD ARRAY
        public static string[] CompressArray(string[] oldArray, int length)
        {
            string[] word = new string[length - 1];

            for (int i = 0; i < word.Length; i++)
            {
                word[i] = oldArray[i];
            }
            return word;
        }

        //METHOD TO SHOW THE NUMBER OF ITEMS INSIDE OF THE ARRAY
        public static void PrintDictionary(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                Console.Write(words[i] + " ");
            }
            Console.WriteLine();
        }



    } // BOTTOM OF THE MAIN CLASS
}