using System;
using System.Collections.Generic;
using System.Linq;

using NFluent;


using RubyQuiz.Core.Solitaire;

using Xunit;

namespace RubyQuiz.Tests.Solitaire
{
    public class CharacterGroupTests
    {
        [Fact]
        public void ItPadsWithXWhenNecessary()
        {
            var group = new CharacterGroup("MATT");
            Check.That(group.ToString()).IsEqualTo("MATTX");
        }

        [Fact]
        public void ItThrowsIfThereAreMoreThan5InitialCharacters()
        {
            Check.ThatCode(() => new CharacterGroup("TOOLONG")).Throws<ArgumentException>();
        }

        [Fact]
        public void ItThrowsIfTheInitialStringIsEmptyOrNull()
        {
            Check.ThatCode(() => new CharacterGroup(null)).Throws<ArgumentNullException>();
            Check.ThatCode(() => new CharacterGroup("")).Throws<ArgumentException>();
        }

        [Fact]
        public void ItCanCreateASequenceFromAnInputStream()
        {
            var sequence = CharacterGroup.CreateSequence("ABCDEFGHIJK");
            Check.That(sequence).ContainsExactly(new[]
            {
                new CharacterGroup("ABCDE"),
                new CharacterGroup("FGHIJ"),
                new CharacterGroup("K"), 
            });
        }

        [Fact]
        public void ItHasAnIndexer()
        {
            var group = new CharacterGroup("ABCDE");

            Check.That(group[0]).IsEqualTo('A');
        }

        [Fact]
        public void ItCanConvertToANumberGroup()
        {
            var numberGroup = new CharacterGroup("ABCDE").ToNumberGroup();
            Check.That(numberGroup).IsEqualTo(new NumberGroup(1, 2, 3, 4, 5));
        }
    }
}
