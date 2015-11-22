using System;
using System.Collections.Generic;
using System.Linq;

using NFluent;

using RubyQuiz.Core.Solitaire;

using Xunit;

namespace RubyQuiz.Tests.Solitaire
{
    public class MessageSanitizerTests
    {
        [Fact]
        public void ItRemovesNonAtoZCharacters()
        {
            var result = MessageSanitizer.Sanitize("12ABC%^DEFG123");
            Check.That(string.Join("", result)).IsEqualTo("ABCDEFG");
        }

        [Fact]
        public void ItUpperCasesThemAll()
        {
            var result = MessageSanitizer.Sanitize("abcdefg");
            Check.That(string.Join("", result)).IsEqualTo("ABCDEFG");
        }
    }
}
