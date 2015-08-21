using System;
using System.Collections.Generic;
using System.Linq;

namespace RubyQuiz.Core.Santa
{
    public interface ISantaAssigner
    {
        IEnumerable<Assignment> Assign(IEnumerable<Person> people);
    }
}
