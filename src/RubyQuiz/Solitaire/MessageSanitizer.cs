using System;
using System.Collections.Generic;
using System.Linq;

namespace RubyQuiz.Solitaire
{
    public static class MessageSanitizer
    {
        public static IEnumerable<char> Sanitize(string message)
        {
            if (message == null) throw new ArgumentNullException("message");

            return message.Select(char.ToUpperInvariant).Where(isUpperCaseLetter);
        }

        private static bool isUpperCaseLetter(char c)
        {
            return c >= 'A' && c <= 'Z';
        }
    }
}
