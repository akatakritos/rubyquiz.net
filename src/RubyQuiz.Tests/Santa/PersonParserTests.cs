using System;
using System.Collections.Generic;
using System.Linq;

using NFluent;

using NUnit.Framework;

using RubyQuiz.Core.Santa;

namespace RubyQuiz.Tests.Santa
{
    [TestFixture]
    public class PersonParserTests
    {
        [Test]
        public void TestItParsesFirstName()
        {
            var person = PersonParser.Parse("Luke Skywalker <luke@theforce.net>");
            Check.That(person.FirstName).IsEqualTo("Luke");
        }

        [Test]
        public void TestItParsesLastName()
        {
            var person = PersonParser.Parse("Leia Skywalker <leia@therebellion.org>");
            Check.That(person.LastName).IsEqualTo("Skywalker");
        }

        [Test]
        public void ItParsesEmailAddresses()
        {
            var person = PersonParser.Parse("Bruce Wayne <bruce@imbatman.com>");
            Check.That(person.Email).IsEqualTo("bruce@imbatman.com");
        }

        [Test]
        public void ThrowFormatExceptionOnBadString()
        {
            Check.ThatCode(() => PersonParser.Parse("THIS IS A BAD STRING")).Throws<FormatException>();

            Check.ThatCode(() => PersonParser.Parse("first last email@somethingnotinbrackets")).Throws<FormatException>();
        }

        [Test]
        public void ThrowsOnNullParameter()
        {
            Check.ThatCode(() => PersonParser.Parse(null)).Throws<ArgumentNullException>();
        }

        [Test]
        public void MultipleWhiteSpaceIsPermitted()
        {
            var p = PersonParser.Parse("Bob   Johnson  \t<bob@johnson.com>");
            Check.That(p).IsEqualTo(new Person("Bob", "Johnson", "bob@johnson.com"));
        }
    }
}
