using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HangmanGame;

namespace Hangman.Tests
{
    [TestClass]
    public class PersonsInScoreboardTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ConstructorTestWithNullForName()
        {
            PersonInScoreboard person = new PersonInScoreboard(null, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorTestWithMistakenumberLessThanZero()
        {
            PersonInScoreboard person = new PersonInScoreboard("Genadi", -5);
        }

        [TestMethod]
        public void ConstructorTestWithCorrectData()
        {
            PersonInScoreboard person = new PersonInScoreboard("Genadi", 5);

            Assert.AreEqual(person.Name, "Genadi");
            Assert.AreEqual(person.MistakeNumber, 5);
        }

        [TestMethod]
        public void CompareTestExpecteZero()
        {
            PersonInScoreboard person = new PersonInScoreboard("Genadi", 5);
            PersonInScoreboard otherPerson = new PersonInScoreboard("Genadi", 5);

            int compareResult = person.CompareTo(otherPerson);

            Assert.AreEqual(0, compareResult);
        }

        [TestMethod]
        public void CompareTestExpecteOne()
        {
            PersonInScoreboard person = new PersonInScoreboard("Genadi", 5);
            PersonInScoreboard otherPerson = new PersonInScoreboard("Genadi",1);

            int compareResult = person.CompareTo(otherPerson);

            Assert.AreEqual(1, compareResult);
        }

        [TestMethod]
        public void CompareTestExpecteMinusOne()
        {
            PersonInScoreboard person = new PersonInScoreboard("Genadi", 1);
            PersonInScoreboard otherPerson = new PersonInScoreboard("Genadi", 5);

            int compareResult = person.CompareTo(otherPerson);

            Assert.AreEqual(-1, compareResult);
        }
    }
}
