using System;

namespace RubyQuiz.Solitaire
{
    public class DeckKeystream
    {
        private readonly Deck _deck;

        public DeckKeystream(Deck deck)
        {
            if (deck == null) throw new ArgumentNullException("deck");
                
            _deck = deck.Clone();
        }

        public char GetNext()
        {
            var nextNonJoker = getNextNonJoker(_deck);

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
