using System;
using System.Collections.Generic;
using System.Linq;

using NFluent;

using NUnit.Framework;

using RubyQuiz.Core.Solitaire;

namespace RubyQuiz.Tests.Solitaire
{
    [TestFixture]
    public class CardTests
    {
        [Test]
        public void HasValueBasedOnSuitAndFaceWhereClubsIsBase()
        {
            Check.That(new Card(Suit.Clubs, Face.Ace).Value).IsEqualTo((byte)1);
            Check.That(new Card(Suit.Clubs, Face.King).Value).IsEqualTo((byte)13);
        }

        [Test]
        public void HasValueBasedOnSuitAndFaceWhereSuitIsSpades()
        {
            Check.That(new Card(Suit.Spades, Face.Ace).Value).IsEqualTo((byte)40);
            Check.That(new Card(Suit.Spades, Face.King).Value).IsEqualTo((byte)52);
        }

        [Test]
        public void EitherJokerHasValueOf53()
        {
            Check.That(Card.RedJoker.Value).IsEqualTo((byte)53);
            Check.That(Card.BlackJoker.Value).IsEqualTo((byte)53);
        }

        [Test]
        public void TheTwoJokesDontEvaluateEqual()
        {
            Check.That(Card.RedJoker).IsNotEqualTo(Card.BlackJoker);
        }
    }
}
