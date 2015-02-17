using System;
using System.Collections.Generic;
using System.Linq;

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
            Assert.That(result, Is.EqualTo("ABCDEFG"));
        }

        [Test]
        public void ItUpperCasesThemAll()
        {
            var result = MessageSanitizer.Sanitize("abcdefg");
            Assert.That(result, Is.EqualTo("ABCDEFG"));
        }
    }
}
