using System.Collections.Generic;
using System.Linq;

namespace RubyQuiz.Solitaire
{
    public static class MessageSanitizer
    {
        public static IEnumerable<char> Sanitize(string message)
        {
            return message.Select(char.ToUpperInvariant).Where(isLetter);
        }

        private static bool isLetter(char c)
        {
            return c >= 'A' && c <= 'Z';
        }
    }
}
