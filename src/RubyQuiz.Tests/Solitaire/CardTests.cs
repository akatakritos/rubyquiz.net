using System;
using System.Collections.Generic;
using System.Linq;

using NFluent;


using RubyQuiz.Core.Solitaire;

using Xunit;

namespace RubyQuiz.Tests.Solitaire
{
    public class CardTests
    {
        [Fact]
        public void HasValueBasedOnSuitAndFaceWhereClubsIsBase()
        {
            Check.That(new Card(Suit.Clubs, Face.Ace).Value).IsEqualTo((byte)1);
            Check.That(new Card(Suit.Clubs, Face.King).Value).IsEqualTo((byte)13);
        }

        [Fact]
        public void HasValueBasedOnSuitAndFaceWhereSuitIsSpades()
        {
            Check.That(new Card(Suit.Spades, Face.Ace).Value).IsEqualTo((byte)40);
            Check.That(new Card(Suit.Spades, Face.King).Value).IsEqualTo((byte)52);
        }

        [Fact]
        public void EitherJokerHasValueOf53()
        {
            Check.That(Card.RedJoker.Value).IsEqualTo((byte)53);
            Check.That(Card.BlackJoker.Value).IsEqualTo((byte)53);
        }

        [Fact]
        public void TheTwoJokesDontEvaluateEqual()
        {
            Check.That(Card.RedJoker).IsNotEqualTo(Card.BlackJoker);
        }
    }
}
