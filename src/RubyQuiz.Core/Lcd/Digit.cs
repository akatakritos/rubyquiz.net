using System;
using System.Collections.Generic;
using System.Linq;

namespace RubyQuiz.Core.Lcd
{
    internal static class Digit
    {
        private static readonly Segments[] _digits = new[]
        {
            Segments.Zero, Segments.One, Segments.Two, Segments.Three, Segments.Four,
            Segments.Five, Segments.Six, Segments.Seven, Segments.Eight, Segments.Nine
        };

        public static Segments FromChar(char digit)
        {
            var index = digit - '0';
            return _digits[index];
        }

        public static Segments[] FromString(string digits)
        {
            return digits.Select(FromChar).ToArray();
        }
    }

}
