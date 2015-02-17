using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using NUnit.Framework;

using RubyQuiz.Core.Lcd;

namespace RubyQuiz.Tests.Lcd
{
    [TestFixture]
    public class DigitWriterTests
    {

        [TestCaseSource(typeof(DigitFixtures), "AllDigitsWithWidthTwo")]
        public void SingleDigits(string digit, string expected)
        {
            var output = new StringWriter();
            var writer = new DigitWriter(output);

            writer.Write(digit);

            Assert.That(output.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void ItDefaultsToWidthTwo()
        {
            var output = new StringWriter();

            var writer = new DigitWriter(output);

            Assert.That(writer.Width, Is.EqualTo(2));
        }

        [TestCaseSource(typeof(DigitFixtures), "AllDigitsWithWidthThree")]
        public void SingleDigitsWide(string digit, string expected)
        {
            var output = new StringWriter();
            var writer = new DigitWriter(output, 3);

            writer.Write(digit);

            Assert.That(output.ToString(), Is.EqualTo(expected));
        }

        [Test]
        public void MultipleDigitsInALine()
        {
            var output = new StringWriter();
            var writer = new DigitWriter(output);

            writer.Write("012345");

            Assert.That(output.ToString(), Is.EqualTo(DigitFixtures.Create(
                " --        --   --        -- ",
                "|  |    |    |    | |  | |   ",
                "|  |    |    |    | |  | |   ",
                "           --   --   --   -- ",
                "|  |    | |       |    |    |",
                "|  |    | |       |    |    |",
                " --        --   --        -- ")));
        }

        [Test]
        public void ThrowsIfPassedNonDigits()
        {
            var _ = new StringWriter();
            var writer = new DigitWriter(_);

            Assert.Throws<ArgumentException>(() => writer.Write("0123a"));
        }

    }
}
