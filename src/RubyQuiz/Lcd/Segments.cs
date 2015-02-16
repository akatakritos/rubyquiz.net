using System;
using System.Collections.Generic;
using System.Linq;

namespace RubyQuiz.Lcd
{
    [Flags]
    public enum Segments : byte
    {
        Top         = 0x01,
        TopLeft     = 0x02,
        TopRight    = 0x04,
        Middle      = 0x08,
        BottomLeft  = 0x10,
        BottomRight = 0x20,
        Bottom      = 0x40,
        All         = 0x7F,

        Zero = Top | TopLeft | TopRight | BottomLeft | BottomRight | Bottom,
        One = TopRight | BottomRight,
        Two = Top | TopRight | Middle | BottomLeft | Bottom,
        Three = Top | TopRight | Middle | BottomRight | Bottom,
        Four = TopLeft | TopRight | Middle | BottomRight,
        Five = Top | TopLeft | Middle | BottomRight | Bottom,
        Six = Top | TopLeft | Middle | BottomRight | Bottom | BottomLeft,
        Seven = Top | TopRight | BottomRight,
        Eight = All,
        Nine = Top | TopLeft | TopRight | Middle | BottomRight
    }
}