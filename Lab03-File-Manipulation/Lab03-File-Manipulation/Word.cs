using System;
using System.Collections.Generic;
using System.Text;

namespace Lab03_File_Manipulation
{
    public class Word
    {
        public string Text { get; set; } // actual word
        public string[] Current { get; set; } // guessed as letters, unguessed as underscore

        /// <summary>
        /// Constructor assigns text to word and initializes the Current array to underscores.
        /// </summary>
        /// <param name="text"></param>
        public Word(string text)
        {
            Text = text;
            Current = new string[text.Length];
            for (int i = 0; i < Current.Length; i++)
            {
                Current[i] = "_";
            }
        }

        /// <summary>
        /// Alters the Current parameter in accordance with the guess passed
        /// </summary>
        /// <param name="guess"></param>
        public void NextDisplay( string guess)
        {
            int ind = Text.IndexOf(guess);
            while (0 <= ind && ind < Current.Length)
            {
                Current[ind] = Text.Substring(ind, 1);
                ind = Text.IndexOf(guess, ind + 1);
            }
        }

        /// <summary>
        /// Prints to the console the current state of the word. Letters that have
        /// been guessed will be displayed, others will be rendered as "_"
        /// </summary>
        public void Display ()
        {
            foreach (string letter in Current)
            {
                Console.Write(letter + " ");
            }
            Console.WriteLine();
        }
    }
}
