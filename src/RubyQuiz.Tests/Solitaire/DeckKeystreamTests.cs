using System;
using System.Collections.Generic;
using System.Linq;

using NFluent;

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

            Check.That(firstLetter).IsEqualTo('D');
        }

        [Test]
        public void ItSkipsJokers()
        {
            var stream = new DeckKeystream(new Deck());

            stream.GetNext();
            stream.GetNext();
            stream.GetNext();

            var fourthLetter = stream.GetNext();

            Check.That(fourthLetter).IsEqualTo('X');
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

            Check.That(firstTenKeyChars).ContainsExactly(new[]{ 'D', 'W', 'J', 'X', 'H', 'Y', 'R', 'F', 'D', 'G'});
        }
    }
}
