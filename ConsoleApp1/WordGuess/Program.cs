using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ReadFile();

        }


        public static void CreateAFile(string path)
        {

            byte[] words = new UTF8Encoding(true).GetBytes("Test");


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









    }
    
}
