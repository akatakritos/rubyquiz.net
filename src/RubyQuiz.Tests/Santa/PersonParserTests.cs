using System;
using System.Collections.Generic;
using System.Linq;

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
            Assert.That(person.FirstName, Is.EqualTo("Luke"));
        }

        [Test]
        public void TestItParsesLastName()
        {
            var person = PersonParser.Parse("Leia Skywalker <leia@therebellion.org>");
            Assert.That(person.LastName, Is.EqualTo("Skywalker"));
        }

        [Test]
        public void ItParsesEmailAddresses()
        {
            var person = PersonParser.Parse("Bruce Wayne <bruce@imbatman.com>");
            Assert.That(person.Email, Is.EqualTo("bruce@imbatman.com"));
        }

        [Test]
        public void ThrowFormatExceptionOnBadString()
        {
            Assert.Throws<FormatException>(() => PersonParser.Parse("THIS IS A BAD STRING"));

            Assert.Throws<FormatException>(() => PersonParser.Parse("first last email@somethingnotinbrackets"));
        }

        [Test]
        public void ThrowsOnNullParameter()
        {
            Assert.Throws<ArgumentNullException>(() => PersonParser.Parse(null));
        }

        [Test]
        public void MultipleWhiteSpaceIsPermitted()
        {
            var p = PersonParser.Parse("Bob   Johnson  \t<bob@johnson.com>");
            Assert.That(p, Is.EqualTo(new Person("Bob", "Johnson", "bob@johnson.com")));
        }
    }
}
