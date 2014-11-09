using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RubyQuiz.Solitaire;

namespace RubyQuizTests.Solitaire
{
    [TestFixture]
    public class NumberGroupTests
    {
        [Test]
        public void ConstructorBitPacksThingsRight()
        {
            var group = new NumberGroup(1, 2, 3, 4, 5);
            Assert.That(group.ToString(), Is.EqualTo("1 2 3 4 5"));
        }

        [Test]
        public void ItHasAnIndexer()
        {
            var group = new NumberGroup(1, 2, 3, 4, 5);
            Assert.That(group[0], Is.EqualTo(1));
            Assert.That(group[1], Is.EqualTo(2));
            Assert.That(group[2], Is.EqualTo(3));
            Assert.That(group[3], Is.EqualTo(4));
            Assert.That(group[4], Is.EqualTo(5));
        }

        [Test]
        public void ItCanConvertToACharacterGroup()
        {
            var characterGroup = new NumberGroup(1, 2, 3, 4, 5).ToCharacterGroup();
            Assert.That(characterGroup, Is.EqualTo(new CharacterGroup("ABCDE")));

        }
    }
}
