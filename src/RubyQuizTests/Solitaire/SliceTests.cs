using System.Linq;
using NUnit.Framework;
using RubyQuiz.Solitaire;

namespace RubyQuizTests.Solitaire
{
    [TestFixture]
    public class SliceTests
    {
        [Test]
        public void ItEnumeratesTheValuesBetween()
        {
            var source = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var slice = new Slice<int>(source, 2, 3);

            Assert.That(slice.Items, Is.EqualTo(new[] {3, 4, 5}));
        }

        [Test]
        public void SliceOfLengthOneStillWorks()
        {
            var source = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var slice = new Slice<int>(source, 2, 1);

            Assert.That(slice.Items, Is.EqualTo(new[] {3}));
        }

        [Test]
        public void CanMakeEmptySlice()
        {
            var source = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var slice = new Slice<int>(source, 2, 0);

            Assert.That(slice.Items.Count(), Is.EqualTo(0));
        }

        [Test]
        public void SliceToTheEndWorksCorrectly()
        {
            var source = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var slice = source.Slice(8);

            Assert.That(slice.Items.ToArray(), Is.EqualTo(new[] {9, 10}));
        }
    }
}
