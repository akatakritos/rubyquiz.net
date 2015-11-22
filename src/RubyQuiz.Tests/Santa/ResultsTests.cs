﻿using System;
using System.Collections.Generic;
using System.Linq;

using Faker.Extensions;

using NFluent;

using NUnit.Framework;

using RubyQuiz.Core.Santa;

namespace RubyQuiz.Tests.Santa
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

            Check.ThatCode(() => Assigner.Assign(people)).Throws<ImpossibleSantaException>();
        }

        [Test]
        public void AssignerDoesntAssignPeopleInTheSameFamily()
        {
            var people = 10.Times(i => new Person(Faker.Name.First(), Faker.Name.Last(), Faker.Internet.Email()));

            var assignments = Assigner.Assign(people);

            foreach (var a in assignments)
            {
                Check.That(a.Santa.CanGiveTo(a.Receiver));
            }
        }
    }
}
