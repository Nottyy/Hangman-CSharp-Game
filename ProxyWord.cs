﻿namespace HangmanSix
{
    using System;
    using System.Linq;
    using System.Text;

    public class ProxyWord : Word
    {
        private const char UnrevealedLetterChar = '-';

        public ProxyWord(string word)
            : base(word)
        {
            this.RealWord = new RealWord(word);
            this.WordLength = this.Content.Length;
            this.RevealedCharacters = new bool[this.WordLength];
            this.PrintView = new string(UnrevealedLetterChar, this.WordLength);
        }
        
        public override string PrintView { get; set; }

        private IWord RealWord { get; set; }

        public override string Print()
        {
            if (this.RevealedCharacters.Contains(false))
            {
                this.FormPrintView();
                return this.PrintView;
            }

            return this.RealWord.Print();
        }

        /// <summary>
        /// Form the current guessed and not guessed letters of the secret word.
        /// </summary>
        private void FormPrintView()
        {
            StringBuilder printView = new StringBuilder();
            for (int currentChar = 0; currentChar < this.WordLength; currentChar++)
            {
                if (this.RevealedCharacters[currentChar])
                {
                    printView.Append(this.Content[currentChar]);
                }
                else
                {
                    printView.Append(UnrevealedLetterChar);
                }
            }

            this.PrintView = printView.ToString();
        }
    }
}
