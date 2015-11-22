using System;
using System.Collections.Generic;
using System.Linq;

using RubyQuiz.Core.Santa;

namespace RubyQuiz.Tests.Santa
{
    public class BruteForceRandomizerTests : ResultsTests
    {
        private readonly BruteForceRandomizer _assigner;
        public BruteForceRandomizerTests()
        {
            _assigner = new BruteForceRandomizer();
        }

        protected override ISantaAssigner Assigner => _assigner;
    }
}
