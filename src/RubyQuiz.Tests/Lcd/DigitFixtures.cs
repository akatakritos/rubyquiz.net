using System;
using System.Collections.Generic;
using System.Linq;


namespace RubyQuiz.Tests.Lcd
{
    internal class TestCaseData
    {
        public string Input { get; }
        public string Expected { get; }

        public TestCaseData(string input, string expected)
        {
            Input = input;
            Expected = expected;
        }
    }

    internal static class DigitFixtures
    {
        internal static string Create(params string[] lines)
        {
            return string.Join(Environment.NewLine, lines) + Environment.NewLine;
        }

        internal static IEnumerable<TestCaseData> AllDigitsWithWidthTwo()
        {
            yield return new TestCaseData("0", Create(
                " -- ",
                "|  |",
                "|  |",
                "    ",
                "|  |",
                "|  |",
                " -- "));
            yield return new TestCaseData("1", Create(
                "    ",
                "   |",
                "   |",
                "    ",
                "   |",
                "   |",
                "    "));
            yield return new TestCaseData("2", Create(
                " -- ",
                "   |",
                "   |",
                " -- ",
                "|   ",
                "|   ",
                " -- "));
            yield return new TestCaseData("3", Create(
                " -- ",
                "   |",
                "   |",
                " -- ",
                "   |",
                "   |",
                " -- "));
            yield return new TestCaseData("4", Create(
                "    ",
                "|  |",
                "|  |",
                " -- ",
                "   |",
                "   |",
                "    "));
            yield return new TestCaseData("5", Create(
                " -- ",
                "|   ",
                "|   ",
                " -- ",
                "   |",
                "   |",
                " -- "));
            yield return new TestCaseData("6", Create(
                " -- ",
                "|   ",
                "|   ",
                " -- ",
                "|  |",
                "|  |",
                " -- "));
            yield return new TestCaseData("7", Create(
                " -- ",
                "   |",
                "   |",
                "    ",
                "   |",
                "   |",
                "    "));
            yield return new TestCaseData("8", Create(
                " -- ",
                "|  |",
                "|  |",
                " -- ",
                "|  |",
                "|  |",
                " -- "));
            yield return new TestCaseData("9", Create(
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
            yield return new TestCaseData("0", Create(
                " --- ",
                "|   |",
                "|   |",
                "     ",
                "|   |",
                "|   |",
                " --- "));
            yield return new TestCaseData("1", Create(
                "     ",
                "    |",
                "    |",
                "     ",
                "    |",
                "    |",
                "     "));
            yield return new TestCaseData("2", Create(
                " --- ",
                "    |",
                "    |",
                " --- ",
                "|    ",
                "|    ",
                " --- "));
            yield return new TestCaseData("3", Create(
                " --- ",
                "    |",
                "    |",
                " --- ",
                "    |",
                "    |",
                " --- "));
            yield return new TestCaseData("4", Create(
                "     ",
                "|   |",
                "|   |",
                " --- ",
                "    |",
                "    |",
                "     "));
            yield return new TestCaseData("5", Create(
                " --- ",
                "|    ",
                "|    ",
                " --- ",
                "    |",
                "    |",
                " --- "));
            yield return new TestCaseData("6", Create(
                " --- ",
                "|    ",
                "|    ",
                " --- ",
                "|   |",
                "|   |",
                " --- "));
            yield return new TestCaseData("7", Create(
                " --- ",
                "    |",
                "    |",
                "     ",
                "    |",
                "    |",
                "     "));
            yield return new TestCaseData("8", Create(
                " --- ",
                "|   |",
                "|   |",
                " --- ",
                "|   |",
                "|   |",
                " --- "));
            yield return new TestCaseData("9", Create(
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
