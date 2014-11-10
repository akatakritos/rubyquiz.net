using System.Collections;
using NUnit.Framework;
using RubyQuiz.Solitaire;

namespace RubyQuizTests.Solitaire
{
    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void TheDefaultStateIsOrdered()
        {
            var deck = new Deck();

            Assert.That(deck[0], Is.EqualTo(new Card(Suit.Clubs, Face.Ace)));
            Assert.That(deck[13], Is.EqualTo(new Card(Suit.Diamonds, Face.Ace)));
            Assert.That(deck[52], Is.EqualTo(new Card(Suit.None, Face.RedJoker)));
            Assert.That(deck[53], Is.EqualTo(new Card(Suit.None, Face.BlackJoker)));
        }

        [Test]
        public void MoveRedJokerDownOneGetsItToTheEnd()
        {
            var deck = new Deck();

            deck.MoveCardDown(new Card(Suit.None, Face.RedJoker), 1);

            Assert.That(deck[53], Is.EqualTo(new Card(Suit.None, Face.RedJoker)));
        }

        [Test]
        public void MovingtheBlackJokerNextWrapsItToTheTop()
        {
            var deck = new Deck();
            deck.MoveCardDown(new Card(Suit.None, Face.RedJoker), 1);

            deck.MoveCardDown(new Card(Suit.None, Face.BlackJoker), 2);

            Assert.That(deck[0], Is.EqualTo(new Card(Suit.Clubs, Face.Ace)));
            Assert.That(deck[1], Is.EqualTo(new Card(Suit.None, Face.BlackJoker)));
        }

        [Test]
        public void TripleCutAroundPivots()
        {
            //set up according to quiz description
            var deck = new Deck();
            deck.MoveCardDown(Card.RedJoker, 1);
            deck.MoveCardDown(Card.BlackJoker, 2);

            deck.TripleCutAround(Card.RedJoker, Card.BlackJoker);

            Assert.That(deck[0], Is.EqualTo(Card.BlackJoker));
            Assert.That(deck[1], Is.EqualTo(new Card(Suit.Clubs, Face.Two)));
            Assert.That(deck[51], Is.EqualTo(new Card(Suit.Spades, Face.King)));
            Assert.That(deck[52], Is.EqualTo(Card.RedJoker));
            Assert.That(deck[53], Is.EqualTo(new Card(Suit.Clubs, Face.Ace)));
        }
    }
}
