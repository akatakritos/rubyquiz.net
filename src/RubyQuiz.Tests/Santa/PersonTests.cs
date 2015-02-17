using System;
using System.Collections.Generic;
using System.Linq;

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
