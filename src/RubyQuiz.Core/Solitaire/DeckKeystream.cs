﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace RubyQuiz.Core.Solitaire
{
    public class DeckKeystream
    {
        private readonly Deck _deck;

        public DeckKeystream(Deck deck)
        {
            if (deck == null) throw new ArgumentNullException(nameof(deck));

            _deck = deck.Clone();
        }

        public char GetNext()
        {
            var nextNonJoker = GetNextNonJoker(_deck);

            var value = nextNonJoker.Value;
            if (value > 26)
                value -= 26;

            return CharacterConverter.DecodeChar(value);
        }

        private static Card GetNextNonJoker(Deck deck)
        {
            Card c;
            while ((c = GetNextCardFromDeck(deck)).IsJoker)
            {
                //noop
            }

            return c;
        }

        private static Card GetNextCardFromDeck(Deck deck)
        {
            deck.MoveCardDown(Card.RedJoker, 1);
            deck.MoveCardDown(Card.BlackJoker, 2);
            deck.TripleCutAround(Card.RedJoker, Card.BlackJoker);
            deck.CountCut(deck.BottomCard.Value);
            return deck[deck.TopCard.Value];
        }
    }
}
