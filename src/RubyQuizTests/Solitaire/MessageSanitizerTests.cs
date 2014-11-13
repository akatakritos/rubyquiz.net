using NUnit.Framework;
using RubyQuiz.Solitaire;

namespace RubyQuizTests.Solitaire
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
