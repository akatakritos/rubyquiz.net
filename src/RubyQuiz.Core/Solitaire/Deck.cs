﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace RubyQuiz.Core.Solitaire
{
    public class Deck
    {
        private readonly Card[] _cards;
        private readonly List<Card> _buffer;
        public const int CardsInDeck = 54; //52 plus 2 jokers

        public Deck()
        {
            _cards = GenerateDefaultDeck();
            _buffer = new List<Card>(_cards.Length);
        }

        public Deck(Card[] keyedDeck)
        {
            if (keyedDeck == null) throw new ArgumentNullException("keyedDeck");
            if (keyedDeck.Length != CardsInDeck) throw new ArgumentOutOfRangeException("keyedDeck", "Key should have 52 cards");
            if(keyedDeck.Distinct().Count() != CardsInDeck) throw new ArgumentException("Key should have one of each character", "keyedDeck");

            _cards = new Card[CardsInDeck];
            _buffer = new List<Card>(_cards.Length);
            Array.Copy(keyedDeck, _cards, CardsInDeck);
        }

        public Deck Clone()
        {
            return new Deck(_cards);
        }

        public IEnumerable<Card> Cards => _cards;

        /// <summary>
        /// Moves a given card down a number of places. If it goes off the bottom,
        /// it cycles around to the top.
        /// </summary>
        /// <param name="card"></param>
        /// <param name="positions"></param>
        public void MoveCardDown(Card card, int positions)
        {
            var oldIndex = Array.IndexOf(_cards, card);
            var newIndex = Wrap(oldIndex + positions);

            _buffer.Clear();
            if (newIndex < oldIndex)
            {
                newIndex++; //because of wrapping around
                _buffer.AddRange(_cards.Slice(0, newIndex).Items);
                _buffer.Add(card);
                _buffer.AddRange(_cards.Slice(newIndex, oldIndex - newIndex).Items);
                _buffer.AddRange(_cards.Slice(oldIndex + 1).Items);
            }
            else
            {
                _buffer.AddRange(_cards.Slice(0, oldIndex).Items);
                _buffer.AddRange(_cards.Slice(oldIndex + 1, positions).Items);
                _buffer.Add(card);
                _buffer.AddRange(_cards.Slice(newIndex + 1).Items);
            }

            _buffer.CopyTo(_cards);
        }

        private int Wrap(int index)
        {
            return index % (_cards.Length);
        }

        /// <summary>
        /// Triple cuts around two pivot cards. Cut the deck twice so that the pivot cards and
        /// all those inbetween are in one pile, then swap the two remaining piles
        /// </summary>
        /// <param name="pivot1"></param>
        /// <param name="pivot2"></param>
        public void TripleCutAround(Card pivot1, Card pivot2)
        {
            var index1 = Array.IndexOf(_cards, pivot1);
            var index2 = Array.IndexOf(_cards, pivot2);

            var pivotPoint1 = Math.Min(index1, index2);
            var pivotPoint2 = Math.Max(index1, index2);

            var slice1 = _cards.Slice(0, pivotPoint1);
            var slice2 = _cards.Slice(pivotPoint1, pivotPoint2 - pivotPoint1 + 1);
            var slice3 = _cards.Slice(pivotPoint2 + 1);

            var buffer = new List<Card>(_cards.Length);
            buffer.AddRange(slice3.Items);
            buffer.AddRange(slice2.Items);
            buffer.AddRange(slice1.Items);

            buffer.CopyTo(_cards);
        }

        public void CountCut(int count)
        {
            var slice1 = _cards.Slice(0, count);
            var slice2 = _cards.Slice(count, _cards.Length - count - 1);
            var slice3 = _cards.Slice(_cards.Length - 1); //should be one!

            var buffer = new List<Card>(_cards.Length);
            buffer.AddRange(slice2.Items);
            buffer.AddRange(slice1.Items);
            buffer.AddRange(slice3.Items);

            buffer.CopyTo(_cards);
        }

        public Card BottomCard => _cards[_cards.Length - 1];
        public Card TopCard => _cards[0];

        public Card this[int index]
        {
            get
            {
                if (index < 0 || index >= _cards.Length)
                    throw new ArgumentOutOfRangeException(nameof(index),
                        $"Index must be between 0 and {_cards.Length - 1}");

                return _cards[index];
            }
        }


        public static Card[] GenerateDefaultDeck()
        {
            var cards = new Card[CardsInDeck];
            int index = 0;
            foreach (var suit in new[] {Suit.Clubs, Suit.Diamonds, Suit.Hearts, Suit.Spades})
            {
                for (var i = 1; i <= 13; i++)
                {
                    cards[index++] = new Card(suit, (Face) i);
                }
            }

            cards[index++] = Card.RedJoker;
            // ReSharper disable once RedundantAssignment
            cards[index++] = Card.BlackJoker;

            return cards;
        }
    }
}
