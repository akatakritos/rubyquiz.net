using System;
using System.Collections.Generic;
using System.Linq;

using NFluent;

using NUnit.Framework;

using RubyQuiz.Core.Solitaire;

namespace RubyQuiz.Tests.Solitaire
{
    [TestFixture]
    public class NumberGroupTests
    {
        [Test]
        public void ConstructorBitPacksThingsRight()
        {
            var group = new NumberGroup(1, 2, 3, 4, 5);
            Check.That(group.ToString()).IsEqualTo("1 2 3 4 5");
        }

        [Test]
        public void ItHasAnIndexer()
        {
            var group = new NumberGroup(1, 2, 3, 4, 5);
            Check.That(group[0]).IsEqualTo((byte)1);
            Check.That(group[1]).IsEqualTo((byte)2);
            Check.That(group[2]).IsEqualTo((byte)3);
            Check.That(group[3]).IsEqualTo((byte)4);
            Check.That(group[4]).IsEqualTo((byte)5);
        }

        [Test]
        public void ItCanConvertToACharacterGroup()
        {
            var characterGroup = new NumberGroup(1, 2, 3, 4, 5).ToCharacterGroup();
            Check.That(characterGroup).IsEqualTo(new CharacterGroup("ABCDE"));
        }

        [Test]
        public void CombiningWithAnotherNumberGroupAddsTheValuesTogether()
        {
            var a = new NumberGroup(1, 2, 3, 4, 5);
            var b = new NumberGroup(5, 4, 3, 2, 1);

            var result = a.Add(b);

            Check.That(result).IsEqualTo(new NumberGroup(6, 6, 6, 6, 6));
        }

        [Test]
        public void CombiningBiggerNumbersWrapAround()
        {
            var a = new NumberGroup(22, 23, 24, 25, 26);
            var b = new NumberGroup(10, 10, 10, 10, 10);

            var result = a.Add(b);

            Check.That(result).IsEqualTo(new NumberGroup(6, 7, 8, 9, 10));
        }

        [Test]
        public void SubtractingWithAnotherNumberGroupsSubtractsTheValues()
        {
            var a = new NumberGroup(10, 11, 12, 13, 14);
            var b = new NumberGroup(1, 2, 3, 4, 5);

            var result = a.Subtract(b);

            Check.That(result).IsEqualTo(new NumberGroup(9, 9, 9, 9, 9));
        }

        [Test]
        public void IfTheFirstIsLessThanTheSecondItAdds26First()
        {
            var a = new NumberGroup(1, 2, 3, 4, 5);
            var b = new NumberGroup(10, 11, 12, 13, 14);

            var result = a.Subtract(b);

            Check.That(result).IsEqualTo(new NumberGroup(17, 17, 17, 17, 17));
        }
    }
}
