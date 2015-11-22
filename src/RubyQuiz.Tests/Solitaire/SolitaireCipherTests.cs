using System;
using System.Collections.Generic;
using System.Linq;

using NFluent;


using RubyQuiz.Core.Solitaire;

using Xunit;

namespace RubyQuiz.Tests.Solitaire
{
    public class SolitaireCipherTests
    {
        [Fact]
        public void TestEncryptionSample1()
        {
            var cipher = new SolitaireCipher();
            var encryted = cipher.Encrypt(new Deck(), "YOUR CIPHER IS WORKING");
            Check.That(encryted).IsEqualTo("CLEPKHHNIYCFPWHFDFEH");
        }

        [Fact]
        public void TestEncryiptionSample2()
        {
            var cipher = new SolitaireCipher();
            var encryted = cipher.Encrypt(new Deck(), "WELCOME TO RUBY QUIZ");
            Check.That(encryted).IsEqualTo("ABVAWLWZSYOORYKDUPVH");
        }

        [Fact]
        public void TestDecryptionSample1()
        {
            var cipher = new SolitaireCipher();
            var encryted = cipher.Decrypt(new Deck(), "CLEPKHHNIYCFPWHFDFEH");
            Check.That(encryted).IsEqualTo("YOURCIPHERISWORKINGX");
        }

        [Fact]
        public void TestDecryptionSample2()
        {
            var cipher = new SolitaireCipher();
            var encryted = cipher.Decrypt(new Deck(), "ABVAWLWZSYOORYKDUPVH");
            Check.That(encryted).IsEqualTo("WELCOMETORUBYQUIZXXX");
        }
    }
}
