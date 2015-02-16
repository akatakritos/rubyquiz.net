using System;
using System.Collections.Generic;
using System.Linq;

namespace RubyQuiz.Lcd
{
    public static class Digit
    {
        private static Segments[] Digits = new[]
        {
            Segments.Zero, Segments.One, Segments.Two, Segments.Three, Segments.Four,
            Segments.Five, Segments.Six, Segments.Seven, Segments.Eight, Segments.Nine
        };

        public static Segments FromChar(char digit)
        {
            var index = digit - '0';
            return Digits[index];
        }
    }

}
