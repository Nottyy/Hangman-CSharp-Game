namespace HangmanSixTest
{
    using System;
    using System.Collections.Generic;
    using HangmanSix;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ChoiceByNumberClassTest
    {
        [TestMethod]
        public void NumberChoiceTest()
        {
            ChoiceStrategy numberStrategy = new ChoiceByIndex(5);
            List<string> testWords = new List<string>();
            testWords.Add("firstWord");
            testWords.Add("secondWord");
            testWords.Add("thirdWord");
            testWords.Add("fourthWord");
            testWords.Add("fifthhWord");
            testWords.Add("sixthhWord");
            string result = numberStrategy.Choice(testWords);
            string expectedValue = testWords[5];

            Assert.AreEqual(result, expectedValue);
        }
    }
}