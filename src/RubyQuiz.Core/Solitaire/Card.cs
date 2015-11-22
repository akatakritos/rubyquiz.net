using System;
using System.Collections.Generic;
using System.Linq;

namespace RubyQuiz.Core.Solitaire
{
    public struct Card : IEquatable<Card>
    {
        public static readonly Card RedJoker = new Card(Suit.None, Face.RedJoker);
        public static readonly Card BlackJoker = new Card(Suit.None, Face.BlackJoker);

        public Card(Suit suit, Face face)
        {
            if (suit != Suit.None && (face == Face.RedJoker || face == Face.BlackJoker))
                throw new ArgumentOutOfRangeException(nameof(suit), "Joker face cards must be paired with Suit.None");
            if (suit == Suit.None && (face != Face.RedJoker && face != Face.BlackJoker))
                throw new ArgumentOutOfRangeException(nameof(suit), "Suit.None can only be paired with Joker faces");

            Suit = suit;
            Face = face;
        }

        public Suit Suit { get; }
        public Face Face { get; }

        public byte Value
        {
            get
            {
                if (isJoker(Face))
                    return 53;

                return (byte)((byte) Suit + (byte) Face);
            }
        }

        public override string ToString()
        {
            if (isJoker(Face))
                return Face.ToString();

            return $"{Face} of {Suit}";
        }

        public bool IsJoker => isJoker(Face);

        private static bool isJoker(Face face)
        {
            return face == Face.RedJoker || face == Face.BlackJoker;
        }

        public bool Equals(Card other)
        {
            return Suit == other.Suit && Face == other.Face;
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
                return ((int) Suit*397) ^ (int) Face;
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
