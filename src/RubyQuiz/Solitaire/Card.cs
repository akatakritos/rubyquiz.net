using System;

namespace RubyQuiz.Solitaire
{
    public struct Card : IEquatable<Card>
    {
        private readonly Suit _suit;
        private readonly Face _face;

        public static readonly Card RedJoker = new Card(Suit.None, Face.RedJoker);
        public static readonly Card BlackJoker = new Card(Suit.None, Face.BlackJoker);

        public Card(Suit suit, Face face)
        {
            if (suit != Suit.None && (face == Face.RedJoker || face == Face.BlackJoker))
                throw new ArgumentOutOfRangeException("suit", "Joker face cards must be paired with Suit.None");
            if (suit == Suit.None && (face != Face.RedJoker && face != Face.BlackJoker))
                throw new ArgumentOutOfRangeException("suit", "Suit.None can only be paired with Joker faces");

            _suit = suit;
            _face = face;
        }

        public Suit Suit
        {
            get { return _suit; }
        }

        public Face Face
        {
            get { return _face; }
        }

        public byte Value
        {
            get
            {
                if (isJoker(_face))
                    return 53;

                return (byte)((byte) _suit + (byte) _face);
            }
        }

        public override string ToString()
        {
            if (isJoker(_face))
                return _face.ToString();

            return string.Format("{0} of {1}", _face, _suit);
        }

        public static bool IsJoker(Card card)
        {
            return isJoker(card.Face);
        }

        private static bool isJoker(Face face)
        {
            return face == Face.RedJoker || face == Face.BlackJoker;
        }

        public bool Equals(Card other)
        {
            return _suit == other._suit && _face == other._face;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Card && Equals((Card) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) _suit*397) ^ (int) _face;
            }
        }

        public static bool operator ==(Card left, Card right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Card left, Card right)
        {
            return !left.Equals(right);
        }
    }
}
