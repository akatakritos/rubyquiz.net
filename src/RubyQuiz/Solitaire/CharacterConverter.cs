using System;

namespace RubyQuiz.Solitaire
{
    public static class CharacterConverter
    {
        public static byte EncodeChar(char c)
        {
            if (c < 'A' || c > 'Z') throw new ArgumentOutOfRangeException("c", "character should be upper case alphabet");

            return (byte) (c - 64);
        }

        public static char DecodeChar(byte b)
        {
            if (b < 1 || b > 26) throw new ArgumentOutOfRangeException("b", "value should be in range of [1,26]");

            return (char) (b + 64);
        }
    }
}
