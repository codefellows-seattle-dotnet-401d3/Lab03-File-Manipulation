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
            string myPath = "..\\..\\..\\cats.txt";
            //calling the string path and invoking the static void at the same time.
            // CreateAFile(myPath);
            ReadFile(myPath);

            Console.WriteLine("--adding stuff---");

            upDateFile(myPath);
            Console.WriteLine("--Reading the 2nd line--");

            ReadFile(myPath);
            
            Console.ReadKey();

            DeleteFile(myPath);


        }


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

        static void upDateFile(string path)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(" This is a new line");
            }
        }

        static void DeleteFile(string path)
        {
            File.Delete(path);
        }


     


            
            


            //// CreateAFile(myPath);
            // ReadFile(myPath);

            // Console.WriteLine("---- ADDING IN A NAME---");

            // UpdateFile(myPath);

            // Console.WriteLine("---- READ IT OUT --");

            // ReadFile(myPath);

            // DeleteFile(myPath);

            //  PracticeUsingSplit();

            ////Show Random Class

            //Random rand = new Random();
            //int first = rand.Next(0, 11);
            //Console.WriteLine(first);
            //Console.WriteLine(rand.Next(0, 11));
            //Console.WriteLine(rand.Next(0, 11));
            //Console.WriteLine(rand.Next(0, 11));


            // show Contains

            /*string word = "coffee";

            if (word.Contains("O"))
            {
                Console.WriteLine($"there is an O in {word}");
            }
            else
            {
                Console.WriteLine("Nope");
            }
        }

        public static void CreateAFile(string path)
        {

            byte[] words = new UTF8Encoding(true).GetBytes("Hello Class");


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
                fs.Write(words, 0, words.Length);
            }

        }


        /*public static void ReadFile(string path)
        {
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
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
        /*
        public static void UpdateFile(string path)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(".NET is cool!");
            }
        }*/

            /*public static void DeleteFile(string path)
            {
                File.Delete(path);
            }*/

            /*public static void PracticeUsingSplit()
            {
                char[] delims = { ' ', ',', '.', ':', '\t' };
                string text = "one two three four five six seven";

                string[] words = text.Split(' ');

                foreach (string s in words)
                {
                    Console.WriteLine(s);

                }
            }*/
        }



       


    
}
