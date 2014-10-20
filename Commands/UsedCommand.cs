namespace HangmanSix
{
    using System;
    using System.Collections.Generic;

    public class UsedCommand : ICommand
    {
        private const int ALLLETTERSIZE = 26;
        private const ConsoleColor REDCOLOR = ConsoleColor.Red;
        private const ConsoleColor DEFAULTCOLOR = ConsoleColor.Gray;

        public UsedCommand(HashSet<char> usedLetters)
        {
            this.UsedLetters = usedLetters;
            this.AllLetters = this.AddAllLetters();
        }

        public HashSet<char> UsedLetters { get; set; }

        private List<Letter> AllLetters { get; set; }

        public void Execute()
        {
            this.SetColorToTheUsedLetters();
            this.PrintAllLetters();
        }

        /// <summary>
        /// Load the alphabet. Perform the Prototype Design Pattern
        /// </summary>
        /// <returns>Returns a list where every element is of class Letter.</returns>
        private List<Letter> AddAllLetters()
        {
            var allLetters = new List<Letter>();
            Letter exampleLetter = new Letter();

            for (int i = 0; i < ALLLETTERSIZE; i++)
            {
                Letter currentLetter = (Letter)exampleLetter.Clone();
                currentLetter.Sign = Convert.ToChar(currentLetter.Sign + i);
                allLetters.Add(currentLetter);
            }

            return allLetters;
        }

        /// <summary>
        /// Set red color to all used letters. 
        /// </summary>
        private void SetColorToTheUsedLetters()
        {
            for (int i = 0; i < ALLLETTERSIZE; i++)
            {
                var currentLetter = this.AllLetters[i];
                if (this.UsedLetters.Contains(currentLetter.Sign) && currentLetter.Color != REDCOLOR)
                {
                    this.AllLetters[i].Color = REDCOLOR;
                }
            }
        }

        /// <summary>
        /// Print all used letters in red and the rest in default color.
        /// </summary>
        private void PrintAllLetters()
        {
            for (int i = 0; i < this.AllLetters.Count; i++)
            {
                Console.ForegroundColor = this.AllLetters[i].Color;
                this.AllLetters[i].Print();
            }

            Console.ForegroundColor = DEFAULTCOLOR;
            Console.WriteLine();
        }
    }
}
