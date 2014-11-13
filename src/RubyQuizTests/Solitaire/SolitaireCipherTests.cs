using NUnit.Framework;
using RubyQuiz.Solitaire;

namespace RubyQuizTests.Solitaire
{
    [TestFixture]
    public class SolitaireCipherTests
    {
        [Test]
        public void TestEncryptionSample1()
        {
            var cipher = new SolitaireCipher();
            var encryted = cipher.Encrypt(new Deck(), "YOUR CIPHER IS WORKING");
            Assert.That(encryted, Is.EqualTo("CLEPKHHNIYCFPWHFDFEH"));
        }

        [Test]
        public void TestEncryiptionSample2()
        {
            var cipher = new SolitaireCipher();
            var encryted = cipher.Encrypt(new Deck(), "WELCOME TO RUBY QUIZ");
            Assert.That(encryted, Is.EqualTo("ABVAWLWZSYOORYKDUPVH"));
        }

        [Test]
        public void TestDecryptionSample1()
        {
            var cipher = new SolitaireCipher();
            var encryted = cipher.Decrypt(new Deck(), "CLEPKHHNIYCFPWHFDFEH");
            Assert.That(encryted, Is.EqualTo("YOURCIPHERISWORKINGX"));
        }

        [Test]
        public void TestDecryptionSample2()
        {
            var cipher = new SolitaireCipher();
            var encryted = cipher.Decrypt(new Deck(), "ABVAWLWZSYOORYKDUPVH");
            Assert.That(encryted, Is.EqualTo("WELCOMETORUBYQUIZXXX"));
        }
    }
}
