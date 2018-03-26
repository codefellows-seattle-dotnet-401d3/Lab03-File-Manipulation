using System;
using System.IO;
using System.Text;

namespace Class03Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //calling the string my path so its a public main signature
           // string myPath = "..\\..\\..\\cats.txt";
            //calling the string path and invoking the static void at the same time.
           //  CreateAFile(myPath); --nEEDED
           // ReadFile(myPath); --

            //Console.WriteLine("--adding stuff---"); --nEEDED 
            
            //upDateFile(myPath); --
            //Console.WriteLine("--Reading the 2nd line--"); --nEEDED

           //ReadFile(myPath);----nEEDED
         
            //note for deleting a file, read a file that dose't exist might throw an error. 
           // DeleteFile(myPath);

            //Console.ReadLine();

            //UseSplit();
            //Console.ReadLine();
            
            /*
            /// Random Class 
            /// bring in a random array and utilize an random index of an array [i], this rand gives random number between 
            /// array = [0-11]
             Random rand = new Random ();
            rand.Next(0, 11);
             Console.WriteLine(rand.Next(0, 11));
            Console.ReadLine();
            */

            //shows Contain
            string word = "coffee";
            if (word.Contains("tt"))
            {
                Console.WriteLine($"there is a {word}");
                
            }
            else
            {
                Console.WriteLine("Note really");
            }
            Console.ReadLine();


        }

        //this is creating a file using the path in designated in the main method 
        static void CreateAFile(string path)
        {
            // my path is a direction in your solutions directory which tells where to put this .txt file
           // string myPath = "..\\..\\..\\cats.txt";
            // creates a start point for bytes and words using t
            byte[] words = new UTF8Encoding(true).GetBytes(" Hello cate");

            
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write("this is my third test");
                }
            }
            catch (Exception)
            {
                throw;
            }

            using (FileStream fs = File.Create(path))
            {
                fs.Write(words, 0, words.Length);
            }

        }


        // This is the signature method to read a document that exists in a path
        static void ReadFile(string path)
        {
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = " ";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }

                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        //this is the signature method to update the existing path with another text
        static void upDateFile(string path)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(" This is a new line");
            }
        }

        // This is the signature method to delete the path string
        static void DeleteFile(string path)
        {
            File.Delete(path);
        }


        //remembe dont apend to the file, just write onto the file, 
        static void UseSplit()
        {
            char[] delims = { ',', ',', ','};
            string text = "words,words,words words.";
            string[] words = text.Split(delims);

            foreach (string s in words)
            {
                Console.WriteLine(s);
            }

        }


     }
}
