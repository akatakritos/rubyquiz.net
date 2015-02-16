using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace RubyQuizTests.Lcd
{
    internal static class DigitFixtures
    {
        internal static string CreateDigit(params string[] lines)
        {
            return string.Join(Environment.NewLine, lines) + Environment.NewLine;
        }

        internal static IEnumerable<TestCaseData> AllDigitsWithWidthTwo()
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

        internal static IEnumerable<TestCaseData> AllDigitsWithWidthThree()
        {
            yield return new TestCaseData("0", CreateDigit(
                " --- ",
                "|   |",
                "|   |",
                "     ",
                "|   |",
                "|   |",
                " --- "));
            yield return new TestCaseData("1", CreateDigit(
                "     ",
                "    |",
                "    |",
                "     ",
                "    |",
                "    |",
                "     "));
            yield return new TestCaseData("2", CreateDigit(
                " --- ",
                "    |",
                "    |",
                " --- ",
                "|    ",
                "|    ",
                " --- "));
            yield return new TestCaseData("3", CreateDigit(
                " --- ",
                "    |",
                "    |",
                " --- ",
                "    |",
                "    |",
                " --- "));
            yield return new TestCaseData("4", CreateDigit(
                "     ",
                "|   |",
                "|   |",
                " --- ",
                "    |",
                "    |",
                "     "));
            yield return new TestCaseData("5", CreateDigit(
                " --- ",
                "|    ",
                "|    ",
                " --- ",
                "    |",
                "    |",
                " --- "));
            yield return new TestCaseData("6", CreateDigit(
                " --- ",
                "|    ",
                "|    ",
                " --- ",
                "|   |",
                "|   |",
                " --- "));
            yield return new TestCaseData("7", CreateDigit(
                " --- ",
                "    |",
                "    |",
                "     ",
                "    |",
                "    |",
                "     "));
            yield return new TestCaseData("8", CreateDigit(
                " --- ",
                "|   |",
                "|   |",
                " --- ",
                "|   |",
                "|   |",
                " --- "));
            yield return new TestCaseData("9", CreateDigit(
                " --- ",
                "|   |",
                "|   |",
                " --- ",
                "    |",
                "    |",
                "     "));
        }
    }
}
