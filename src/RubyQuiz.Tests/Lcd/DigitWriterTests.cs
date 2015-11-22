using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using NFluent;

using RubyQuiz.Core.Lcd;

using Xunit;

namespace RubyQuiz.Tests.Lcd
{
    public class DigitWriterTests
    {
        [Theory]
        [MemberData(nameof(AllDigitsWithWidthTwo))]
        public void SingleDigits(string digit, string expected)
        {
            var output = new StringWriter();
            var writer = new DigitWriter(output);

            writer.Write(digit);

            Check.That(output.ToString()).IsEqualTo(expected);
        }

        public static IEnumerable<object[]> AllDigitsWithWidthTwo()
        {
            return DigitFixtures.AllDigitsWithWidthTwo()
                .Select(d => new object[] { d.Input, d.Expected });
        }

        public static IEnumerable<object[]> AllDigitsWithWidthThree()
        {
            return DigitFixtures.AllDigitsWithWidthThree()
                .Select(d => new object[] { d.Input, d.Expected });
        }

        [Fact]
        public void ItDefaultsToWidthTwo()
        {
            var output = new StringWriter();

            var writer = new DigitWriter(output);

            Check.That(writer.Width).IsEqualTo(2);
        }

        [Theory]
        [MemberData(nameof(AllDigitsWithWidthThree))]
        public void SingleDigitsWide(string digit, string expected)
        {
            var output = new StringWriter();
            var writer = new DigitWriter(output, 3);

            writer.Write(digit);

            Check.That(output.ToString()).IsEqualTo(expected);
        }

        [Fact]
        public void MultipleDigitsInALine()
        {
            var output = new StringWriter();
            var writer = new DigitWriter(output);

            writer.Write("012345");

            Check.That(output.ToString()).IsEqualTo(DigitFixtures.Create(
                " --        --   --        -- ",
                "|  |    |    |    | |  | |   ",
                "|  |    |    |    | |  | |   ",
                "           --   --   --   -- ",
                "|  |    | |       |    |    |",
                "|  |    | |       |    |    |",
                " --        --   --        -- "));
        }

        [Fact]
        public void ThrowsIfPassedNonDigits()
        {
            var _ = new StringWriter();
            var writer = new DigitWriter(_);

            Check.ThatCode(() => writer.Write("0123a")).Throws<ArgumentException>();
        }

    }
}
