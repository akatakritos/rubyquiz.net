using System;
using System.Collections.Generic;
using System.Linq;

namespace RubyQuiz.Core.Santa
{
    public class ImpossibleSantaException : Exception
    {
        public ImpossibleSantaException()
            : base("Its not possible to assign santas correctly")
        {

        }

    }
}