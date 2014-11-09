using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubyQuiz.Solitaire
{
    internal static class CharacterConverter
    {
        public static byte EncodeChar(char c)
        {
            return (byte) (c - 64);
        }

        public static char DecodeChar(byte b)
        {
            return (char) (b + 64);
        }
    }
}
