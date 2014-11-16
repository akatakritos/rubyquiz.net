using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using RubyQuiz.Santa;
using Faker.Extensions;

namespace RubyQuizTests.Santa
{
    public abstract class ResultsTests
    {
        protected abstract ISantaAssigner Assigner { get; }

        [Test]
        public void AssignerThrowImpossibleExceptionWhenImpossible()
        {
            const string LAST_NAME = "Burke";
            var people = new[]
            {
                new Person(Faker.Name.First(), LAST_NAME, Faker.Internet.Email()),
                new Person(Faker.Name.First(), LAST_NAME, Faker.Internet.Email())
            };
            Assert.Throws<ImpossibleSantaException>(() => Assigner.Assign(people));
        }

        [Test]
        public void AssignerDoesntAssignPeopleInTheSameFamily()
        {
            var people = 10.Times(i => new Person(Faker.Name.First(), Faker.Name.Last(), Faker.Internet.Email()));

            var assignments = Assigner.Assign(people);

            foreach (var a in assignments)
            {
                Assert.That(a.Santa.CanGiveTo(a.Receiver));
            }
        }
    }
}
