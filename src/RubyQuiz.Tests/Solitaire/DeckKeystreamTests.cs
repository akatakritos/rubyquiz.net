using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using RubyQuiz.Core.Solitaire;

namespace RubyQuiz.Tests.Solitaire
{
    [TestFixture]
    public class DeckKeystreamTests
    {
        [Test]
        public void FirstLetterInUnkeyedDeckIsD()
        {
            var stream = new DeckKeystream(new Deck());

            var firstLetter = stream.GetNext();

            Assert.That(firstLetter, Is.EqualTo('D'));
        }

        [Test]
        public void ItSkipsJokers()
        {
            var stream = new DeckKeystream(new Deck());

            stream.GetNext();
            stream.GetNext();
            stream.GetNext();

            var fourthLetter = stream.GetNext();

            Assert.That(fourthLetter, Is.EqualTo('X'));
        }

        [Test]
        public void SmokeTest()
        {
            var stream = new DeckKeystream(new Deck());

            var firstTenKeyChars = new char[]
            {
                stream.GetNext(),
                stream.GetNext(),
                stream.GetNext(),
                stream.GetNext(),
                stream.GetNext(),
                stream.GetNext(),
                stream.GetNext(),
                stream.GetNext(),
                stream.GetNext(),
                stream.GetNext(),
            };

            foreach (var c in firstTenKeyChars)
                Console.WriteLine(c);

            Assert.That(firstTenKeyChars, Is.EqualTo(new char[]{ 'D', 'W', 'J', 'X', 'H', 'Y', 'R', 'F', 'D', 'G'}));
        }
    }
}
