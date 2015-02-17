using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

using RubyQuiz.Core.Santa;

namespace RubyQuiz.Tests.Santa
{
    [TestFixture]
    public class BruteForceRandomizerTests : ResultsTests
    {
        private readonly BruteForceRandomizer _assigner;
        public BruteForceRandomizerTests()
        {
            _assigner = new BruteForceRandomizer();
        }

        protected override ISantaAssigner Assigner { get { return _assigner; }}
    }
}
