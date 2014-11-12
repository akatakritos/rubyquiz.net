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

        [Test]
        public void CombiningWithAnotherNumberGroupAddsTheValuesTogether()
        {
            var a = new NumberGroup(1, 2, 3, 4, 5);
            var b = new NumberGroup(5, 4, 3, 2, 1);

            var result = a.Add(b);

            Assert.That(result, Is.EqualTo(new NumberGroup(6, 6, 6, 6, 6)));
        }

        [Test]
        public void CombiningBiggerNumbersWrapAround()
        {
            var a = new NumberGroup(22, 23, 24, 25, 26);
            var b = new NumberGroup(10, 10, 10, 10, 10);

            var result = a.Add(b);

            Assert.That(result, Is.EqualTo(new NumberGroup(6, 7, 8, 9, 10)));
        }

        [Test]
        public void SubtractingWithAnotherNumberGroupsSubtractsTheValues()
        {
            var a = new NumberGroup(10, 11, 12, 13, 14);
            var b = new NumberGroup(1, 2, 3, 4, 5);

            var result = a.Subtract(b);

            Assert.That(result, Is.EqualTo(new NumberGroup(9, 9, 9, 9, 9)));
        }

        [Test]
        public void IfTheFirstIsLessThanTheSecondItAdds26First()
        {
            var a = new NumberGroup(1, 2, 3, 4, 5);
            var b = new NumberGroup(10, 11, 12, 13, 14);

            var result = a.Subtract(b);

            Assert.That(result, Is.EqualTo(new NumberGroup(17, 17, 17, 17, 17)));
        }
    }
}
