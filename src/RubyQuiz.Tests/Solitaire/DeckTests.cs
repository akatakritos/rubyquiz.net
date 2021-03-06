﻿using System;
using System.Collections.Generic;
using System.Linq;

using NFluent;

using RubyQuiz.Core.Solitaire;

using Xunit;

namespace RubyQuiz.Tests.Solitaire
{
    public class DeckTests
    {
        [Fact]
        public void TheDefaultStateIsOrdered()
        {
            var deck = new Deck();

            Check.That(deck[0]).IsEqualTo(new Card(Suit.Clubs, Face.Ace));
            Check.That(deck[13]).IsEqualTo(new Card(Suit.Diamonds, Face.Ace));
            Check.That(deck[52]).IsEqualTo(Card.RedJoker);
            Check.That(deck[53]).IsEqualTo(Card.BlackJoker);
        }

        [Fact]
        public void MoveRedJokerDownOneGetsItToTheEnd()
        {
            var deck = new Deck();

            deck.MoveCardDown(Card.RedJoker, 1);

            Check.That(deck[53]).IsEqualTo(Card.RedJoker);
        }

        [Fact]
        public void MovingtheBlackJokerNextWrapsItToTheTop()
        {
            var deck = new Deck();
            deck.MoveCardDown(Card.RedJoker, 1);

            deck.MoveCardDown(Card.BlackJoker, 2);

            Check.That(deck[0]).IsEqualTo(new Card(Suit.Clubs, Face.Ace));
            Check.That(deck[1]).IsEqualTo(Card.BlackJoker);
        }

        [Fact]
        public void TripleCutAroundPivots()
        {
            //set up according to quiz description
            var deck = new Deck();
            deck.MoveCardDown(Card.RedJoker, 1);
            deck.MoveCardDown(Card.BlackJoker, 2);

            deck.TripleCutAround(Card.RedJoker, Card.BlackJoker);

            Check.That(deck[0]).IsEqualTo(Card.BlackJoker);
            Check.That(deck[1]).IsEqualTo(new Card(Suit.Clubs, Face.Two));
            Check.That(deck[51]).IsEqualTo(new Card(Suit.Spades, Face.King));
            Check.That(deck[52]).IsEqualTo(Card.RedJoker);
            Check.That(deck[53]).IsEqualTo(new Card(Suit.Clubs, Face.Ace));
        }

        [Fact]
        public void CountCutMovesSomeCardsAccordingToTheQuizDescription()
        {
            //set up according to quiz description
            var deck = new Deck();
            deck.MoveCardDown(Card.RedJoker, 1);
            deck.MoveCardDown(Card.BlackJoker, 2);
            deck.TripleCutAround(Card.RedJoker, Card.BlackJoker);

            deck.CountCut(1);

            Check.That(deck[0]).IsEqualTo(new Card(Suit.Clubs, Face.Two));
            Check.That(deck[51]).IsEqualTo(Card.RedJoker);
            Check.That(deck[52]).IsEqualTo(Card.BlackJoker);
            Check.That(deck[53]).IsEqualTo(new Card(Suit.Clubs, Face.Ace));
        }

        [Fact]
        public void EachCardInDefaultDeckIsUnique()
        {
            var deck = new Deck();
            Check.That(deck.Cards.Distinct()).HasSize(Deck.CardsInDeck);
        }

    }
}
