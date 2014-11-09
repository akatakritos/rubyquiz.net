using System;

namespace RubyQuiz.Solitaire
{
    public struct NumberGroup : IEquatable<NumberGroup>
    {
        private readonly ulong _contents;

        public NumberGroup(byte b1, byte b2, byte b3, byte b4, byte b5)
        {
            _contents = 0;
            _contents = b1;
            _contents = (_contents << 8) | b2;
            _contents = (_contents << 8) | b3;
            _contents = (_contents << 8) | b4;
            _contents = (_contents << 8) | b5;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3} {4}",
                this[0], this[1], this[2], this[3], this[4]);
        }

        public byte this[int index]
        {
            get
            {
                if (index < 0 || index > 4) throw new ArgumentOutOfRangeException("index", "Index must be between 0 and 4 inclusive");

                return (byte) ((_contents >> (4-index)*8) & 0xFF);
            }
        }

        public CharacterGroup ToCharacterGroup()
        {
            return new CharacterGroup(
                CharacterConverter.DecodeChar(this[0]),
                CharacterConverter.DecodeChar(this[1]),
                CharacterConverter.DecodeChar(this[2]),
                CharacterConverter.DecodeChar(this[3]),
                CharacterConverter.DecodeChar(this[4])
            );
        }


        public bool Equals(NumberGroup other)
        {
            return _contents == other._contents;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is NumberGroup && Equals((NumberGroup) obj);
        }

        public override int GetHashCode()
        {
            return _contents.GetHashCode();
        }

        public static bool operator ==(NumberGroup left, NumberGroup right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(NumberGroup left, NumberGroup right)
        {
            return !left.Equals(right);
        }

    }
}
