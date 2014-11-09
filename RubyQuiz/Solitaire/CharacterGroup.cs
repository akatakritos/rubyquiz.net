using System;
using System.Collections.Generic;
using System.Text;

namespace RubyQuiz.Solitaire
{
    public struct CharacterGroup : IEquatable<CharacterGroup>
    {
        private readonly string _contents;

        public CharacterGroup(string initialContents)
        {
            if (initialContents == null) throw new ArgumentNullException("initialContents");
            if (initialContents.Length == 0) throw new ArgumentException("Empty intial value", "initialContents");
            if (initialContents.Length > 5) throw new ArgumentException("Too many initial characters", "initialContents");

            _contents = initialContents.PadRight(5, 'X');
        }

        public CharacterGroup(char c1, char c2, char c3, char c4, char c5)
        {
            var buffer = new StringBuilder(5);
            buffer.Append(c1);
            buffer.Append(c2);
            buffer.Append(c3);
            buffer.Append(c4);
            buffer.Append(c5);
            _contents = buffer.ToString();
        }

        public override string ToString()
        {
            return _contents;
        }

        public char this[int index]
        {
            get
            {
                if (index < 0 || index > 4)
                    throw new ArgumentOutOfRangeException("index", "index must be between 0 and 4 inclusive.");
                return _contents[index];
            }
        }
       

        public static IEnumerable<CharacterGroup> CreateSequence(IEnumerable<char> stream)
        {
            if (stream == null)
                throw new ArgumentNullException("stream");

            return createSequence(stream);
        }

        private static IEnumerable<CharacterGroup> createSequence(IEnumerable<char> stream)
        {
            var buffer = new StringBuilder(5);
            foreach (char c in stream)
            {
                buffer.Append(c);

                if (buffer.Length == 5)
                {
                    yield return new CharacterGroup(buffer.ToString());
                    buffer.Clear();
                }
            }

            if(buffer.Length > 0)
                yield return new CharacterGroup(buffer.ToString());
        }

        public NumberGroup ToNumberGroup()
        {
            return new NumberGroup(
                CharacterConverter.EncodeChar(this[0]),
                CharacterConverter.EncodeChar(this[1]),
                CharacterConverter.EncodeChar(this[2]),
                CharacterConverter.EncodeChar(this[3]),
                CharacterConverter.EncodeChar(this[4])
            );
        }

        public bool Equals(CharacterGroup other)
        {
            return string.Equals(_contents, other._contents);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CharacterGroup)obj);
        }

        public override int GetHashCode()
        {
            return (_contents != null ? _contents.GetHashCode() : 0);
        }

        public static bool operator ==(CharacterGroup left, CharacterGroup right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CharacterGroup left, CharacterGroup right)
        {
            return !Equals(left, right);
        }
    }
}
