using System;
using System.Collections.Generic;
using System.Linq;

using NFluent;

using NUnit.Framework;

using RubyQuiz.Core.Solitaire;

namespace RubyQuiz.Tests.Solitaire
{
    [TestFixture]
    public class SolitaireCipherTests
    {
        [Test]
        public void TestEncryptionSample1()
        {
            var cipher = new SolitaireCipher();
            var encryted = cipher.Encrypt(new Deck(), "YOUR CIPHER IS WORKING");
            Check.That(encryted).IsEqualTo("CLEPKHHNIYCFPWHFDFEH");
        }

        [Test]
        public void TestEncryiptionSample2()
        {
            var cipher = new SolitaireCipher();
            var encryted = cipher.Encrypt(new Deck(), "WELCOME TO RUBY QUIZ");
            Check.That(encryted).IsEqualTo("ABVAWLWZSYOORYKDUPVH");
        }

        [Test]
        public void TestDecryptionSample1()
        {
            var cipher = new SolitaireCipher();
            var encryted = cipher.Decrypt(new Deck(), "CLEPKHHNIYCFPWHFDFEH");
            Check.That(encryted).IsEqualTo("YOURCIPHERISWORKINGX");
        }

        [Test]
        public void TestDecryptionSample2()
        {
            var cipher = new SolitaireCipher();
            var encryted = cipher.Decrypt(new Deck(), "ABVAWLWZSYOORYKDUPVH");
            Check.That(encryted).IsEqualTo("WELCOMETORUBYQUIZXXX");
        }
    }
}
