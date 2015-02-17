using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

using CommandLine;

using RubyQuiz.Lcd;

namespace Runner
{
    public static class Program
    {
        static void Main(string[] args)
        {

            var options = new Options();
            if (!Parser.Default.ParseArguments(args, options, (verb, suboption) =>
            {
                if (options.LcdVerb != null)
                    PerformLcd(options.LcdVerb);
            }))
            {
                Environment.Exit(Parser.DefaultExitCodeFail);
            }

        }

        static void PerformLcd(LcdSubOptions options)
        {
            var writer = new DigitWriter(Console.Out, options.Size);
            writer.Write(options.Message);
        }

    }

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
