using System;
using System.Collections.Generic;
using System.Linq;

using CommandLine;

namespace RubyQuiz.Runner
{
    class Options
    {
        [VerbOption("lcd")]
        public LcdSubOptions LcdVerb { get; set; }
    }

    class LcdSubOptions
    {
        public LcdSubOptions()
        {
            Size = 2;
        }

        [Option('s', "size", DefaultValue = 2, HelpText = "Sets the width of the digits")]
        public int Size { get; set; }

        [ValueOption(0)]
        public string Message { get; set; }
    }
}