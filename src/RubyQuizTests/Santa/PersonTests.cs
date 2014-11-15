using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

using RubyQuiz.Santa;

namespace RubyQuizTests.Santa
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void CantGiveToSomeOneInTheSameFamily()
        {
            var mom = new Person("Alyce", "Burke", "aburke@example.com");
            var dad = new Person("Steve", "Burke", "sburke@example.com");

            Assert.That(mom.CanGiveTo(dad), Is.False);
            Assert.That(dad.CanGiveTo(mom), Is.False);
        }

        [Test]
        public void CanGiveToSomeoneInADifferentFamily()
        {
            var me = new Person("Matt", "Burke", "mburke@example.com");
            var mark = new Person("Mark", "Bernardo", "mbernardo@example.com");

            Assert.That(me.CanGiveTo(mark), Is.True);
            Assert.That(mark.CanGiveTo(me), Is.True);
        }
    }
}
