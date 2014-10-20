﻿namespace HangmanSixTest
{
    using System;
    using System.Collections.Generic;
    using HangmanSix;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class ChoiceRandomClassTest
    {
        [TestMethod]
        public void GetRandomWordFromListTest()
        {
            ChoiceStrategy randomStrategy = new ChoiceRandom();
            List<string> testWords = new List<string>();
            testWords.Add("firstWord");
            testWords.Add("secondWord");
            testWords.Add("thirdWord");
            testWords.Add("fourthWord");

            bool result = testWords.Contains(randomStrategy.Choice(testWords));

            Assert.IsTrue(result);
        }
    }
}
