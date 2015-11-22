using System;
using System.Collections.Generic;
using System.Linq;

using NFluent;

using NUnit.Framework;

using RubyQuiz.Core.Solitaire;

namespace RubyQuiz.Tests.Solitaire
{
    [TestFixture]
    public class MessageSanitizerTests
    {
        [Test]
        public void ItRemovesNonAtoZCharacters()
        {
            var result = MessageSanitizer.Sanitize("12ABC%^DEFG123");
            Check.That(string.Join("", result)).IsEqualTo("ABCDEFG");
        }

        [Test]
        public void ItUpperCasesThemAll()
        {
            var result = MessageSanitizer.Sanitize("abcdefg");
            Check.That(string.Join("", result)).IsEqualTo("ABCDEFG");
        }
    }
}
