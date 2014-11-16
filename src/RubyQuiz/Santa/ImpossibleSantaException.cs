using System;
using System.Collections.Generic;
using System.Linq;

namespace RubyQuiz.Santa
{
    public class ImpossibleSantaException : Exception
    {
        public ImpossibleSantaException()
            : base("Its not possible to assign santas correctly")
        {

        }

    }
}