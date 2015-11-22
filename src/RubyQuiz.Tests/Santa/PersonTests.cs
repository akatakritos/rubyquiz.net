using System;
using System.Collections.Generic;
using System.Linq;

using NFluent;

using NUnit.Framework;

using RubyQuiz.Core.Santa;

namespace RubyQuiz.Tests.Santa
{
    [TestFixture]
    public class PersonTests
    {
        [Test]
        public void CantGiveToSomeOneInTheSameFamily()
        {
            const string LAST_NAME = "Burke";
            var mom = new Person(Faker.Name.First(), LAST_NAME, Faker.Internet.Email());
            var dad = new Person(Faker.Name.First(), LAST_NAME, Faker.Internet.Email());

            Check.That(mom.CanGiveTo(dad)).IsFalse();
            Check.That(dad.CanGiveTo(mom)).IsFalse();
        }

        [Test]
        public void CanGiveToSomeoneInADifferentFamily()
        {
            var me = new Person("Matt", "Burke", "mburke@example.com");
            var mark = new Person("Mark", "Bernardo", "mbernardo@example.com");

            Check.That(me.CanGiveTo(mark)).IsTrue();
            Check.That(mark.CanGiveTo(me)).IsTrue();
        }
    }
}
