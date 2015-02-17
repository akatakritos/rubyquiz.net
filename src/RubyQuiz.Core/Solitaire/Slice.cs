using System;
using System.Collections.Generic;
using System.Linq;

namespace RubyQuiz.Core.Solitaire
{
    public struct Slice<T>
    {
        private readonly int _start;
        private readonly int _count;
        private readonly T[] _source;

        public Slice(T[] source, int start, int count)
        {
            if (start < 0) throw new ArgumentOutOfRangeException("start", "start must be greater than 0");
            if(start + count > source.Length) throw new ArgumentOutOfRangeException("count", "start + count must be within the range of the source array");

            _source = source;
            _start = start;
            _count = count;
        }

        public IEnumerable<T> Items
        {
            get { return enumerate(); }
        }

        private IEnumerable<T> enumerate()
        {
            for(var i = 0; i < _count; i++)
                yield return _source[_start + i];
        }

    }
}