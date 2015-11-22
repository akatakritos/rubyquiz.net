using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using NFluent;

using NUnit.Framework;

using RubyQuiz.Core.Lcd;

namespace RubyQuiz.Tests.Lcd
{
    [TestFixture]
    public class DigitWriterTests
    {

        [TestCaseSource(typeof(DigitFixtures), nameof(DigitFixtures.AllDigitsWithWidthTwo))]
        public void SingleDigits(string digit, string expected)
        {
            var output = new StringWriter();
            var writer = new DigitWriter(output);

            writer.Write(digit);

            Check.That(output.ToString()).IsEqualTo(expected);
        }

        [Test]
        public void ItDefaultsToWidthTwo()
        {
            var output = new StringWriter();

            var writer = new DigitWriter(output);

            Check.That(writer.Width).IsEqualTo(2);
        }

        [TestCaseSource(typeof(DigitFixtures), "AllDigitsWithWidthThree")]
        public void SingleDigitsWide(string digit, string expected)
        {
            var output = new StringWriter();
            var writer = new DigitWriter(output, 3);

            writer.Write(digit);

            Check.That(output.ToString()).IsEqualTo(expected);
        }

        [Test]
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

        [Test]
        public void ThrowsIfPassedNonDigits()
        {
            var _ = new StringWriter();
            var writer = new DigitWriter(_);

            Check.ThatCode(() => writer.Write("0123a")).Throws<ArgumentException>();
        }

    }
}
