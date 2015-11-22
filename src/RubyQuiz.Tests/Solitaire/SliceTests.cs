using System;
using System.Collections.Generic;
using System.Linq;

using NFluent;


using RubyQuiz.Core.Solitaire;

using Xunit;

namespace RubyQuiz.Tests.Solitaire
{
    public class SliceTests
    {
        [Fact]
        public void ItEnumeratesTheValuesBetween()
        {
            var source = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var slice = new Slice<int>(source, 2, 3);

            Check.That(slice.Items).ContainsExactly(3, 4, 5);
        }

        [Fact]
        public void SliceOfLengthOneStillWorks()
        {
            var source = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var slice = new Slice<int>(source, 2, 1);

            Check.That(slice.Items).ContainsExactly(3);
        }

        [Fact]
        public void CanMakeEmptySlice()
        {
            var source = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var slice = new Slice<int>(source, 2, 0);

            Check.That(slice.Items).IsEmpty();
        }

        [Fact]
        public void SliceToTheEndWorksCorrectly()
        {
            var source = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var slice = source.Slice(8);

            Check.That(slice.Items).ContainsExactly(9, 10);
        }
    }
}
