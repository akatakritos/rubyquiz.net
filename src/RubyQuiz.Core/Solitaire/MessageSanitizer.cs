using System;
using System.Collections.Generic;
using System.Linq;

namespace RubyQuiz.Core.Solitaire
{
    public static class MessageSanitizer
    {
        public static IEnumerable<char> Sanitize(string message)
        {
            if (message == null) throw new ArgumentNullException("message");

            return message.Select(char.ToUpperInvariant).Where(IsUpperCaseLetter);
        }

        private static bool IsUpperCaseLetter(char c)
        {
            return c >= 'A' && c <= 'Z';
        }
    }
}
