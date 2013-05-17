using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangmanGame;

namespace Hangman.Tests
{
    [TestClass]
    public class ScoreboardTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void AddInScoreboardTestWithNullForName()
        {
            Scoreboard scoreboard = new Scoreboard();
            scoreboard.AddInScoreboard(null, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddInScoreboardTestWithMistakenumberLessThanZero()
        {
            Scoreboard scoreboard = new Scoreboard();
            scoreboard.AddInScoreboard("Genadi", -5);
        }

        [TestMethod]
        public void AddInScoreboardTestWithCorrectData()
        {
            Scoreboard scoreboard = new Scoreboard();
            scoreboard.AddInScoreboard("Genadi", 5);

            Assert.AreEqual(1, scoreboard.Players.Count);
        }

        [TestMethod]
        public void AddInScoreboardTestWithCorrectDataWithTwoPlayers()
        {
            Scoreboard scoreboard = new Scoreboard();
            scoreboard.AddInScoreboard("Genadi", 5);
            scoreboard.AddInScoreboard("Genadi", 4);

            Assert.AreEqual(2, scoreboard.Players.Count);
        }

        [TestMethod]
        public void AddInScoreboardTestWithCorrectDataWithSixPlayers()
        {
            Scoreboard scoreboard = new Scoreboard();
            scoreboard.AddInScoreboard("Genadi", 5);
            scoreboard.AddInScoreboard("Genadi", 4);
            scoreboard.AddInScoreboard("Genadi", 6);
            scoreboard.AddInScoreboard("Genadi", 7);
            scoreboard.AddInScoreboard("Genadi", 10);
            scoreboard.AddInScoreboard("Bai Ivan", 0);

            Assert.AreEqual(5, scoreboard.Players.Count);
        }

        [TestMethod]
        public void QalifiesForScoreboardFailTest()
        {
            Scoreboard scoreboard = new Scoreboard();
            scoreboard.AddInScoreboard("Genadi", 5);
            scoreboard.AddInScoreboard("Genadi", 4);
            scoreboard.AddInScoreboard("Genadi", 6);
            scoreboard.AddInScoreboard("Genadi", 7);
            scoreboard.AddInScoreboard("Genadi", 10);
            scoreboard.AddInScoreboard("Bai Ivan", 0);

            bool isQalified = scoreboard.QalifiesForScoreboard(11);

            Assert.AreEqual(false, isQalified);
        }

        [TestMethod]
        public void QalifiesForScoreboardSuccesTest()
        {
            Scoreboard scoreboard = new Scoreboard();
            scoreboard.AddInScoreboard("Genadi", 5);
            scoreboard.AddInScoreboard("Genadi", 4);
            scoreboard.AddInScoreboard("Genadi", 6);
            scoreboard.AddInScoreboard("Genadi", 7);
            scoreboard.AddInScoreboard("Genadi", 10);
            scoreboard.AddInScoreboard("Bai Ivan", 0);

            bool isQalified = scoreboard.QalifiesForScoreboard(0);

            Assert.AreEqual(true, isQalified);
        }

        [TestMethod]
        public void ToStringTest()
        {
            Scoreboard scoreboard = new Scoreboard();
            scoreboard.AddInScoreboard("Genadi", 5);
            scoreboard.AddInScoreboard("Genadi", 4);
            scoreboard.AddInScoreboard("Genadi", 6);
            scoreboard.AddInScoreboard("Genadi", 7);
            scoreboard.AddInScoreboard("Genadi", 10);
            scoreboard.AddInScoreboard("Bai Ivan", 0);

            string scoreboardToString = scoreboard.ToString();

            Assert.AreEqual("Scoreboard:\r\n1. Bai Ivan --> 0 mistake\r\n2. Genadi --> 4 mistake\r\n3. Genadi --> 5 mistake\r\n4. Genadi --> 6 mistake\r\n5. Genadi --> 7 mistake\r\n", scoreboardToString);
        }
    }
}
