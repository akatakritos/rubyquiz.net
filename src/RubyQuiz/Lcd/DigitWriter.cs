using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RubyQuiz.Lcd
{
    public class DigitWriter
    {
        private readonly TextWriter _output;
        private readonly int _width;

        private const char Space = ' ';
        private const char VerticalSegment = '|';
        private const char HorizontalSegment = '-';

        public DigitWriter(TextWriter output, int width = 2)
        {
            if (output == null) throw new ArgumentException("output");
            if (width <= 0) throw new ArgumentOutOfRangeException("width", string.Format("width must be > 0, '{0}' given.", width));

            _output = output;
            _width = width;
        }

        public int Width { get { return _width; } }

        public void Write(string digits)
        {
            EnsureAllDigits(digits, "digits");
            var segments = Digit.FromString(digits);

            PrintForEachDigit(segments, WriteLine1);
            PrintForEachDigit(segments, WriteLine2);
            PrintForEachDigit(segments, WriteLine3);
            PrintForEachDigit(segments, WriteLine4);
            PrintForEachDigit(segments, WriteLine5);
            PrintForEachDigit(segments, WriteLine6);
            PrintForEachDigit(segments, WriteLine7);
        }

        private static void EnsureAllDigits(string s, string paramName)
        {
            if (s.Any(c => !char.IsDigit(c)))
                throw new ArgumentException("string must contain only digit characters", paramName);
        }

        private void PrintForEachDigit(IList<Segments> digits, Action<Segments> print)
        {
            for (int i = 0; i < digits.Count; i++)
            {
                var digit = digits[i];

                // if not first, output a space before
                if (i > 0)
                    _output.Write(' ');

                print(digit);
            }

            _output.WriteLine();
        }


        private void WriteLine1(Segments digit)
        {
            _output.Write(Space);
            Scale(digit.HasFlag(Segments.Top) ? HorizontalSegment : Space);
            _output.Write(Space);
        }

        private void WriteLine2(Segments digit)
        {
            _output.Write(digit.HasFlag(Segments.TopLeft) ? VerticalSegment : Space);
            Scale(Space);
            _output.Write(digit.HasFlag(Segments.TopRight) ? VerticalSegment : Space);
        }

        private void WriteLine3(Segments digit)
        {
            WriteLine2(digit);
        }

        private void WriteLine4(Segments digit)
        {
            _output.Write(Space);
            Scale(digit.HasFlag(Segments.Middle) ? HorizontalSegment : Space);
            _output.Write(Space);
        }

        private void WriteLine5(Segments digit)
        {
            _output.Write(digit.HasFlag(Segments.BottomLeft) ? VerticalSegment : Space);
            Scale(Space);
            _output.Write(digit.HasFlag(Segments.BottomRight) ? VerticalSegment : Space);
        }

        private void WriteLine6(Segments digit)
        {
            WriteLine5(digit);
        }

        private void WriteLine7(Segments digit)
        {
            _output.Write(Space);
            Scale(digit.HasFlag(Segments.Bottom) ? HorizontalSegment : Space);
            _output.Write(Space);
        }


        private void Scale(char c)
        {
            for (var i = 0; i < _width; i++)
                _output.Write(c);
        }



    }
}
