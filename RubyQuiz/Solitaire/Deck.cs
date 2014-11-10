using System;
using System.Collections.Generic;

namespace RubyQuiz.Solitaire
{
    public class Deck
    {
        private readonly Card[] _cards;

        public Deck()
        {
            _cards = generateDefaultDeck();
        }

        /// <summary>
        /// Moves a given card down a number of places. If it goes off the bottom,
        /// it cycles around to the top.
        /// </summary>
        /// <param name="card"></param>
        /// <param name="positions"></param>
        public void MoveCardDown(Card card, int positions)
        {
            var oldIndex = Array.IndexOf(_cards, card);
            var newIndex = wrap(oldIndex + positions);

            var buffer = new List<Card>(_cards.Length);
            if (newIndex < oldIndex)
            {
                newIndex++; //because of wrapping around
                buffer.AddRange(_cards.Slice(0, newIndex).Items);
                buffer.Add(card);
                buffer.AddRange(_cards.Slice(newIndex, oldIndex - newIndex).Items);
                buffer.AddRange(_cards.Slice(oldIndex + 1).Items);
            }
            else
            {
                buffer.AddRange(_cards.Slice(0, oldIndex).Items);
                buffer.AddRange(_cards.Slice(oldIndex + 1, positions).Items);
                buffer.Add(card);
                buffer.AddRange(_cards.Slice(newIndex + 1).Items);
            }

            buffer.CopyTo(_cards);
        }

        private int wrap(int index)
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

        public Card BottomCard
        {
            get { return _cards[_cards.Length - 1]; }
        }

        public Card TopCard
        {
            get { return _cards[0]; }
        }

        public Card this[int index]
        {
            get
            {
                if (index < 0 || index >= _cards.Length)
                    throw new ArgumentOutOfRangeException("index", "Index must be between 0 and 51");

                return _cards[index];
            }
        }


        private Card[] generateDefaultDeck()
        {
            var cards = new Card[54];
            int index = 0;
            foreach (var suit in new Suit[] {Suit.Clubs, Suit.Diamonds, Suit.Hearts, Suit.Spades})
            {
                for (var i = 1; i <= 13; i++)
                {
                    cards[index++] = new Card(suit, (Face) i);
                }
            }

            cards[index++] = new Card(Suit.None, Face.RedJoker);
            cards[index++] = new Card(Suit.None, Face.BlackJoker);

            return cards;
        }
    }
}
