using System;
using System.Collections.Generic;
using System.Linq;

using NFluent;

using NUnit.Framework;

using RubyQuiz.Core.Solitaire;

namespace RubyQuiz.Tests.Solitaire
{
    [TestFixture]
    public class CharacterConverterTests
    {
        [Test]
        public void SmokeTestAlphaToNumber()
        {
            const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            var convertedValues = alphabet.Select(CharacterConverter.EncodeChar);

            Check.That(convertedValues).ContainsExactly(new byte[]
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26
            });
        }

    }
}
