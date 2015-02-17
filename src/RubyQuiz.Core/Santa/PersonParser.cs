using System;
using System.Collections.Generic;
using System.Linq;

namespace RubyQuiz.Core.Santa
{
    public static class PersonParser
    {
        private const string FormatExceptionMessage = "Input not in expected format 'Firstname Lastname <email@domain.com>'";

        public static Person Parse(string input)
        {
            if (input == null) throw new ArgumentNullException("input");

            var parts = input.Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);

            validateInput(parts);

            var firstName = parts[0];
            var lastName = parts[1];
            var email = parts[2].Substring(1, parts[2].Length - 2);

            return new Person(firstName, lastName, email);
        }

        // ReSharper disable once UnusedParameter.Local
        private static void validateInput(string[] parts)
        {
            if (parts.Length != 3)
            {
                throw new FormatException(FormatExceptionMessage);
            }
            if (!parts[2].StartsWith("<", StringComparison.Ordinal) || !parts[2].EndsWith(">", StringComparison.Ordinal))
            {
                throw new FormatException(FormatExceptionMessage);
            }
            
            if (parts[2].Length < 7)
                throw new FormatException(FormatExceptionMessage);
        }
    }
}
