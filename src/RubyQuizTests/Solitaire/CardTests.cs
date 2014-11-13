using NUnit.Framework;
using RubyQuiz.Solitaire;

namespace RubyQuizTests.Solitaire
{
    [TestFixture]
    public class CardTests
    {
        [Test]
        public void HasValueBasedOnSuitAndFaceWhereClubsIsBase()
        {
            Assert.That(new Card(Suit.Clubs, Face.Ace).Value, Is.EqualTo(1));
            Assert.That(new Card(Suit.Clubs, Face.King).Value, Is.EqualTo(13));
        }

        [Test]
        public void HasValueBasedOnSuitAndFaceWhereSuitIsSpades()
        {
            Assert.That(new Card(Suit.Spades, Face.Ace).Value, Is.EqualTo(40));
            Assert.That(new Card(Suit.Spades, Face.King).Value, Is.EqualTo(52));
        }

        [Test]
        public void EitherJokerHasValueOf53()
        {
            Assert.That(Card.RedJoker.Value, Is.EqualTo(53));
            Assert.That(Card.BlackJoker.Value, Is.EqualTo(53));
        }

        [Test]
        public void TheTwoJokesDontEvaluateEqual()
        {
            Assert.That(Card.RedJoker, Is.Not.EqualTo(Card.BlackJoker));
        }
    }
}
