using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace RubyQuiz.Solitaire
{
    public class DeckKeystream
    {
        private readonly Deck _deck;

        public DeckKeystream(Deck deck)
        {
            _deck = deck;
        }

        public char GetNext()
        {
            Card nextNonJoker = getNextNonJoker(_deck);

            var value = nextNonJoker.Value;
            if (value > 26)
                value -= 26;

            return CharacterConverter.DecodeChar(value);
        }

        private Card getNextNonJoker(Deck deck)
        {
            Card c;
            while (Card.IsJoker(c = getNextCardFromDeck(deck)))
            { 
                //noop
            }

            return c;
        }

        private Card getNextCardFromDeck(Deck deck)
        {
            deck.MoveCardDown(Card.RedJoker, 1);
            deck.MoveCardDown(Card.BlackJoker, 2);
            deck.TripleCutAround(Card.RedJoker, Card.BlackJoker);
            deck.CountCut(deck.BottomCard.Value);
            return deck[deck.TopCard.Value];
        }
    }
}
