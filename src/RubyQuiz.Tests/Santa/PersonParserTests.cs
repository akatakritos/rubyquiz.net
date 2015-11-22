using System;
using System.Collections.Generic;
using System.Linq;

using NFluent;

using RubyQuiz.Core.Santa;

using Xunit;

namespace RubyQuiz.Tests.Santa
{
    public class PersonParserTests
    {
        [Fact]
        public void TestItParsesFirstName()
        {
            var person = PersonParser.Parse("Luke Skywalker <luke@theforce.net>");
            Check.That(person.FirstName).IsEqualTo("Luke");
        }

        [Fact]
        public void TestItParsesLastName()
        {
            var person = PersonParser.Parse("Leia Skywalker <leia@therebellion.org>");
            Check.That(person.LastName).IsEqualTo("Skywalker");
        }

        [Fact]
        public void ItParsesEmailAddresses()
        {
            var person = PersonParser.Parse("Bruce Wayne <bruce@imbatman.com>");
            Check.That(person.Email).IsEqualTo("bruce@imbatman.com");
        }

        [Fact]
        public void ThrowFormatExceptionOnBadString()
        {
            Check.ThatCode(() => PersonParser.Parse("THIS IS A BAD STRING")).Throws<FormatException>();

            Check.ThatCode(() => PersonParser.Parse("first last email@somethingnotinbrackets")).Throws<FormatException>();
        }

        [Fact]
        public void ThrowsOnNullParameter()
        {
            Check.ThatCode(() => PersonParser.Parse(null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void MultipleWhiteSpaceIsPermitted()
        {
            var p = PersonParser.Parse("Bob   Johnson  \t<bob@johnson.com>");
            Check.That(p).IsEqualTo(new Person("Bob", "Johnson", "bob@johnson.com"));
        }
    }
}
