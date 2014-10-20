namespace HangmanSix
{
    using System;

    /// <summary>
    /// Performing the Prototype Design Pattern
    /// </summary>
    public class Letter : ICloneable
    {
        private const ConsoleColor DEFAULTLETTERCOLOR = ConsoleColor.Gray;
        private const char DEFAULTSIGN = 'a';

        public Letter()
        {
            this.Sign = DEFAULTSIGN;
            this.Color = DEFAULTLETTERCOLOR;
        }

        public char Sign { get; set; }

        public ConsoleColor Color { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public void Print()
        {
            Console.Write("{0} ", this.Sign);
        }
    }
}
