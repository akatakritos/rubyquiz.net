using System;
using System.Collections.Generic;

namespace RubyQuiz.Solitaire
{
    public static class SliceExtensions
    {
        public static Slice<T> Slice<T>(this T[] source, int start, int count)
        {
            return new Slice<T>(source, start, count);
        }

        public static Slice<T> Slice<T>(this T[] source, int start)
        {
            return new Slice<T>(source, start, source.Length - start);
        }
    }

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

        public T[] Concat(params Slice<T>[] slices)
        {
            var buffer = new List<T>();

            buffer.AddRange(this.Items);

            foreach(var slice in slices)
                buffer.AddRange(slice.Items);

            return buffer.ToArray();
        }

        private IEnumerable<T> enumerate()
        {
            for(var i = 0; i < _count; i++)
                yield return _source[_start + i];
        }

    }
}