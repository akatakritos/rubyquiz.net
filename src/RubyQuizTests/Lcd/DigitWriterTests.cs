using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using NUnit.Framework;

using RubyQuiz.Lcd;

namespace RubyQuizTests.Lcd
{
    [TestFixture]
    public class DigitWriterTests
    {
        static string CreateDigit(params string[] lines)
        {
            return string.Join(Environment.NewLine, lines) + Environment.NewLine;
        }

        [TestCaseSource(typeof(DigitWriterTests), "DigitsData")]
        public void SingleDigits(string digit, string expected)
        {
            var output = new StringWriter();
            var writer = new DigitWriter(output);

            writer.Write(digit);

            Assert.That(output.ToString(), Is.EqualTo(expected));
        }

        private static IEnumerable<TestCaseData> DigitsData()
        {
            yield return new TestCaseData("0", CreateDigit(
                " -- ",
                "|  |",
                "|  |",
                "    ",
                "|  |",
                "|  |",
                " -- "));
            yield return new TestCaseData("1", CreateDigit(
                "    ",
                "   |",
                "   |",
                "    ",
                "   |",
                "   |",
                "    "));
            yield return new TestCaseData("2", CreateDigit(
                " -- ",
                "   |",
                "   |",
                " -- ",
                "|   ",
                "|   ",
                " -- "));
            yield return new TestCaseData("3", CreateDigit(
                " -- ",
                "   |",
                "   |",
                " -- ",
                "   |",
                "   |",
                " -- "));
            yield return new TestCaseData("4", CreateDigit(
                "    ",
                "|  |",
                "|  |",
                " -- ",
                "   |",
                "   |",
                "    "));
            yield return new TestCaseData("5", CreateDigit(
                " -- ",
                "|   ",
                "|   ",
                " -- ",
                "   |",
                "   |",
                " -- "));
            yield return new TestCaseData("6", CreateDigit(
                " -- ",
                "|   ",
                "|   ",
                " -- ",
                "|  |",
                "|  |",
                " -- "));
            yield return new TestCaseData("7", CreateDigit(
                " -- ",
                "   |",
                "   |",
                "    ",
                "   |",
                "   |",
                "    "));
            yield return new TestCaseData("8", CreateDigit(
                " -- ",
                "|  |",
                "|  |",
                " -- ",
                "|  |",
                "|  |",
                " -- "));
            yield return new TestCaseData("9", CreateDigit(
                " -- ",
                "|  |",
                "|  |",
                " -- ",
                "   |",
                "   |",
                "    "));
        }
    }
}
