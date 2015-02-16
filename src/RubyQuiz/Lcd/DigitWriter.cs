using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RubyQuiz.Lcd
{
    public class DigitWriter
    {
        private readonly TextWriter _output;
        private const char Space = ' ';
        private const char VerticalSegment = '|';
        private const char HorizontalSegment = '-';

        public DigitWriter(TextWriter output)
        {
            _output = output;
        }

        public void Write(string digits)
        {
            var digit = Digit.FromChar(digits[0]);

            WriteLine1(digit); _output.WriteLine();
            WriteLine2(digit); _output.WriteLine();
            WriteLine3(digit); _output.WriteLine();
            WriteLine4(digit); _output.WriteLine();
            WriteLine5(digit); _output.WriteLine();
            WriteLine6(digit); _output.WriteLine();
            WriteLine7(digit); _output.WriteLine();
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
            for (var i = 0; i < 2; i++)
                _output.Write(c);
        }



    }
}
