namespace HangmanSixTest
{
    using System;
    using System.IO;
    using HangmanSix;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CheckManagerClassTest
    {
        private Player player = Player.Instance;

        [TestInitialize]
        public void Initialize()
        {
            this.player.Name = "Milena";
        }

        [TestMethod]
        public void CheckWordPrintViewAfterProcessingTheHelpCommandTest()
        {
            this.player.AttemptsToGuess = 0;

            var checkManager = new CheckManager(this.player);
            IWord word = new ProxyWord("test");
            checkManager.DefineCommands(word);
            checkManager.CheckCommand("Help", word);

            Assert.AreEqual(word.PrintView, "t---");
        }

        [TestMethod]
        public void IsTheHasHelpUsedStateTrueWhenUsingHelpOptionTest()
        {
            this.player.AttemptsToGuess = 0;

            var checkManager = new CheckManager(this.player);
            IWord word = new ProxyWord("test");
            checkManager.DefineCommands(word);
            checkManager.CheckCommand("Help", word);

            Assert.IsTrue(checkManager.HasHelpUsed);
        }

        [TestMethod]
        public void IsTheHasHelpUsedStateFalseWhenUsingHelpOptionTest()
        {
            this.player.AttemptsToGuess = 0;

            var checkManager = new CheckManager(this.player);
            IWord word = new ProxyWord("test");
            checkManager.DefineCommands(word);
            checkManager.HasHelpUsed = true;

            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                checkManager.CheckCommand("Help", word);

                writer.Flush();

                string result = writer.GetStringBuilder().ToString();
                string expected = "You have already used your help option!\r\n" +
                          "The secret word is:----\r\n";

                Assert.AreEqual(expected, result);
            }
        }

        [TestMethod]
        public void AddLetterInUsedMethodTest()
        {
            this.player.AttemptsToGuess = 5;
            var checkManager = new CheckManager(this.player);

            char guessedChar = 't';

            checkManager.AddLetterInUsed(guessedChar);

            Assert.IsTrue(checkManager.UsedLetters.Contains(guessedChar));
        }

        [TestMethod]
        public void CheckWordPrintViewAfterProcessingWithCharWhichIsPartOfTheWordTest()
        {
            this.player.AttemptsToGuess = 5;

            var checkManager = new CheckManager(this.player);
            IWord word = new ProxyWord("test");
            char guessedChar = 't';

            checkManager.CheckLetterAccordance(word, guessedChar);

            bool checkProcessedWordPrintView = word.PrintView == "t--t";
            Assert.IsTrue(checkProcessedWordPrintView);
        }

        [TestMethod]
        public void CheckWordPrintViewAfterProcessingWithCharWhichIsNotPartOfTheWordTest()
        {
            this.player.AttemptsToGuess = 5;

            var checkManager = new CheckManager(this.player);
            IWord word = new ProxyWord("test");
            char guessedChar = 'r';

            checkManager.CheckLetterAccordance(word, guessedChar);

            bool checkProcessedWordPrintView = word.PrintView == "----";
            Assert.IsTrue(checkProcessedWordPrintView);
        }

        [TestMethod]
        public void CheckWhenTheGuessIsWrongIfThePlayerAttemptsToGuessAreIncreasedTest()
        {
            this.player.AttemptsToGuess = 0;

            var checkManager = new CheckManager(this.player);
            IWord word = new ProxyWord("test");
            char guessedChar = 'r';

            checkManager.CheckLetterAccordance(word, guessedChar);
            int expectedPlayerAttemptsToGuess = 1;

            Assert.AreEqual(expectedPlayerAttemptsToGuess, this.player.AttemptsToGuess);
        }
    }
}