using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using RubyQuiz.Core.Solitaire;

namespace RubyQuiz.Tests.Solitaire
{
    [TestFixture]
    public class CharacterGroupTests
    {
        [Test]
        public void ItPadsWithXWhenNecessary()
        {
            var group = new CharacterGroup("MATT");
            Assert.That(group.ToString(), Is.EqualTo("MATTX"));
        }

        [Test]
        public void ItThrowsIfThereAreMoreThan5InitialCharacters()
        {
            Assert.Throws<ArgumentException>(() => new CharacterGroup("TOOLONG"));
        }

        [Test]
        public void ItThrowsIfTheInitialStringIsEmptyOrNull()
        {
            Assert.Throws<ArgumentNullException>(() => new CharacterGroup(null));
            Assert.Throws<ArgumentException>(() => new CharacterGroup(""));
        }

        [Test]
        public void ItCanCreateASequenceFromAnInputStream()
        {
            var sequence = CharacterGroup.CreateSequence("ABCDEFGHIJK");
            Assert.That(sequence, Is.EqualTo(new CharacterGroup[]
            {
                new CharacterGroup("ABCDE"),
                new CharacterGroup("FGHIJ"),
                new CharacterGroup("K"), 
            }));
        }

        [Test]
        public void ItHasAnIndexer()
        {
            var group = new CharacterGroup("ABCDE");

            Assert.That(group[0], Is.EqualTo('A'));
        }

        [Test]
        public void ItCanConvertToANumberGroup()
        {
            var numberGroup = new CharacterGroup("ABCDE").ToNumberGroup();
            Assert.That(numberGroup, Is.EqualTo(new NumberGroup(1, 2, 3, 4, 5)));
        }
    }
}
