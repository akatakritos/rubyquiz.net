using System;
using System.Collections.Generic;
using System.Linq;

using NFluent;

using RubyQuiz.Core.Solitaire;

using Xunit;

namespace RubyQuiz.Tests.Solitaire
{
    public class DeckKeystreamTests
    {
        [Fact]
        public void FirstLetterInUnkeyedDeckIsD()
        {
            var stream = new DeckKeystream(new Deck());

            var firstLetter = stream.GetNext();

            Check.That(firstLetter).IsEqualTo('D');
        }

        [Fact]
        public void ItSkipsJokers()
        {
            var stream = new DeckKeystream(new Deck());

            stream.GetNext();
            stream.GetNext();
            stream.GetNext();

            var fourthLetter = stream.GetNext();

            Check.That(fourthLetter).IsEqualTo('X');
        }

        [Fact]
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
