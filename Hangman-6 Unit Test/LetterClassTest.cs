namespace HangmanSixTest
{
    using System;
    using System.IO;
    using HangmanSix;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LetterClassTest
    {
        private Letter currentLetter = new Letter();

        [TestMethod]
        public void DefaultLetterSignTest()
        {
            char expectedDefaultSign = 'a';

            Assert.AreEqual(expectedDefaultSign, this.currentLetter.Sign);
        }

        [TestMethod]
        public void LetterSignTest()
        {
            this.currentLetter.Sign = 'h';
            char expectedSign = 'h';

            Assert.AreEqual(expectedSign, this.currentLetter.Sign);
        }

        [TestMethod]

        public void DefaultLetterColorTest()
        {
            ConsoleColor expectedColor = ConsoleColor.Gray;

            Assert.AreEqual(expectedColor, this.currentLetter.Color);
        }

        [TestMethod]
        public void LetterColorTest()
        {
            this.currentLetter.Color = ConsoleColor.Yellow;
            ConsoleColor expectedColor = ConsoleColor.Yellow;

            Assert.AreEqual(expectedColor, this.currentLetter.Color);
        }

        [TestMethod]
        public void PrintLetterTest()
        {
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);

                this.currentLetter.Print();

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "a ";

                Assert.AreEqual(expected, result);
            }
        }
    }
}
