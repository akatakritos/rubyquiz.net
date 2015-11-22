using System;
using System.Collections.Generic;
using System.Linq;

using NFluent;

using RubyQuiz.Core.Santa;

using Xunit;

namespace RubyQuiz.Tests.Santa
{
    public class PersonTests
    {
        [Fact]
        public void CantGiveToSomeOneInTheSameFamily()
        {
            const string LAST_NAME = "Burke";
            var mom = new Person(Faker.Name.First(), LAST_NAME, Faker.Internet.Email());
            var dad = new Person(Faker.Name.First(), LAST_NAME, Faker.Internet.Email());

            Check.That(mom.CanGiveTo(dad)).IsFalse();
            Check.That(dad.CanGiveTo(mom)).IsFalse();
        }

        [Fact]
        public void CanGiveToSomeoneInADifferentFamily()
        {
            var me = new Person("Matt", "Burke", "mburke@example.com");
            var mark = new Person("Mark", "Bernardo", "mbernardo@example.com");

            Check.That(me.CanGiveTo(mark)).IsTrue();
            Check.That(mark.CanGiveTo(me)).IsTrue();
        }
    }
}
