using System;
using System.Collections.Generic;
using System.Linq;

namespace RubyQuiz.Core.Solitaire
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
}